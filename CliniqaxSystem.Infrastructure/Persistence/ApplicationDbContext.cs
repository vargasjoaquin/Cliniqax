using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CliniqaxSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    // ==========================================
    // 1. SEGURIDAD Y ACCESO
    // ==========================================
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    // ==========================================
    // 2. DOMINIO MÉDICO Y PACIENTES
    // ==========================================
    public DbSet<Specialty> Specialties => Set<Specialty>();
    public DbSet<HealthInsurance> HealthInsurances => Set<HealthInsurance>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Professional> Professionals => Set<Professional>();
    public DbSet<ProfessionalSpeciality> ProfessionalSpecialties => Set<ProfessionalSpeciality>();
    public DbSet<ProfessionalSchedule> ProfessionalSchedules => Set<ProfessionalSchedule>();

    // ==========================================
    // 3. AGENDA Y ATENCIÓN
    // ==========================================
    public DbSet<Appointment> Appointments => Set<Appointment>();

    // ==========================================
    // 4. CAJA Y FINANZAS
    // ==========================================
    public DbSet<CashSession> CashSessions => Set<CashSession>();
    public DbSet<CashMovement> CashMovements => Set<CashMovement>();
    public DbSet<ConsultationPayment> ConsultationPayments => Set<ConsultationPayment>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

    // ==========================================
    // 5. CONFIGURACIÓN
    // ==========================================
    public DbSet<ClinicSettings> ClinicSettings => Set<ClinicSettings>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =========================================================================
        // A. CONCURRENCIA OPTIMISTA GLOBAL
        // =========================================================================
        var entitiesWithRowVersion = modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType));

        foreach (var entity in entitiesWithRowVersion)
        {
            modelBuilder.Entity(entity.ClrType)
                .Property(nameof(BaseEntity.RowVersion))
                .IsRowVersion()
                .IsRequired();
        }

        // =========================================================================
        // B. SEGURIDAD Y USUARIOS
        // =========================================================================
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);
            entity.HasIndex(u => u.Username).IsUnique();

            entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            entity.Property(u => u.Email).HasMaxLength(100);
            entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
            entity.Property(u => u.Photo).HasColumnType("varbinary(max)").IsRequired(false);

            // Garantiza a nivel de base de datos que haya un único Admin activo
            entity.HasIndex(u => u.RoleId)
                  .IsUnique()
                  .HasFilter($"[RoleId] = {RoleConstants.ADMINISTRATOR_ROLE_ID} AND [IsDeleted] = 0")
                  .HasDatabaseName("UQ_Users_SingleActiveAdmin");

            entity.HasOne(u => u.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(u => u.RoleId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(u => u.Professional)
                  .WithMany()
                  .HasForeignKey(u => u.ProfessionalId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // =========================================================================
        // C. ESPECIALIDADES Y OBRAS SOCIALES
        // =========================================================================
        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.ToTable("Specialties");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s => s.Description).HasMaxLength(250);

            entity.HasIndex(s => s.Name)
                  .IsUnique()
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("UQ_Specialties_ActiveName");
        });

        modelBuilder.Entity<HealthInsurance>(entity =>
        {
            entity.ToTable("HealthInsurances");
            entity.HasKey(h => h.Id);
            entity.Property(h => h.Name).IsRequired().HasMaxLength(100);
            entity.Property(h => h.Cuit).HasMaxLength(20);
            entity.Property(h => h.Phone).HasMaxLength(30);
            entity.Property(h => h.Email).HasMaxLength(100);

            entity.HasIndex(h => h.Name)
                  .IsUnique()
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("UQ_HealthInsurances_ActiveName");
        });

        // =========================================================================
        // D. PACIENTES
        // =========================================================================
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patients");
            entity.HasKey(p => p.Id);

            entity.HasIndex(p => p.DocumentNumber)
                  .IsUnique()
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("UQ_Patients_ActiveDocumentNumber");

            entity.Property(p => p.DocumentNumber).IsRequired().HasMaxLength(20);
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            entity.Property(p => p.BirthDate).HasColumnType("date").IsRequired();
            entity.Property(p => p.Phone).IsRequired().HasMaxLength(30);
            entity.Property(p => p.Email).HasMaxLength(100);
            entity.Property(p => p.Address).HasMaxLength(150);
            entity.Property(p => p.City).HasMaxLength(80);
            entity.Property(p => p.AffiliateNumber).HasMaxLength(50);
            entity.Property(p => p.AdministrativeNotes).HasMaxLength(500);

            entity.HasOne(p => p.HealthInsurance)
                  .WithMany(h => h.Patients)
                  .HasForeignKey(p => p.HealthInsuranceId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // =========================================================================
        // E. PROFESIONALES Y HORARIOS
        // =========================================================================
        modelBuilder.Entity<Professional>(entity =>
        {
            entity.ToTable("Professionals");
            entity.HasKey(p => p.Id);

            entity.HasIndex(p => p.DocumentNumber)
                  .IsUnique()
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("UQ_Professionals_ActiveDocumentNumber");

            entity.HasIndex(p => p.LicenseNumber)
                  .IsUnique()
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("UQ_Professionals_ActiveLicenseNumber");

            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(50);
            entity.Property(p => p.DocumentNumber).IsRequired().HasMaxLength(20);
            entity.Property(p => p.LicenseNumber).IsRequired().HasMaxLength(30);
            entity.Property(p => p.Phone).HasMaxLength(30);
            entity.Property(p => p.Email).HasMaxLength(100);
            entity.Property(p => p.Observations).HasMaxLength(500);
        });

        // Relación Muchos a Muchos: Profesional <-> Especialidad
        modelBuilder.Entity<ProfessionalSpeciality>(entity =>
        {
            entity.ToTable("ProfessionalSpecialties");
            entity.HasKey(ps => new { ps.ProfessionalId, ps.SpecialtyId });

            entity.HasOne(ps => ps.Professional)
                  .WithMany(p => p.ProfessionalSpecialties)
                  .HasForeignKey(ps => ps.ProfessionalId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ps => ps.Specialty)
                  .WithMany(s => s.ProfessionalSpecialties)
                  .HasForeignKey(ps => ps.SpecialtyId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ProfessionalSchedule>(entity =>
        {
            entity.ToTable("ProfessionalSchedules");
            entity.HasKey(ps => ps.Id);

            entity.Property(ps => ps.DayOfWeek).HasConversion<int>();
            entity.Property(ps => ps.StartTime).HasColumnType("time").IsRequired();
            entity.Property(ps => ps.EndTime).HasColumnType("time").IsRequired();

            entity.HasOne(ps => ps.Professional)
                  .WithMany(p => p.Schedules)
                  .HasForeignKey(ps => ps.ProfessionalId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // =========================================================================
        // F. MOTOR DE TURNOS Y AGENDA
        // =========================================================================
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(a => a.Id);

            entity.Property(a => a.AppointmentDate).HasColumnType("date").IsRequired();
            entity.Property(a => a.StartTime).HasColumnType("time").IsRequired();
            entity.Property(a => a.EndTime).HasColumnType("time").IsRequired();
            entity.Property(a => a.Status).HasConversion<int>().IsRequired();
            entity.Property(a => a.CancellationReason).HasMaxLength(250);
            entity.Property(a => a.Observations).HasMaxLength(500);

            entity.HasOne(a => a.Patient)
                  .WithMany(p => p.Appointments)
                  .HasForeignKey(a => a.PatientId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Professional)
                  .WithMany(p => p.Appointments)
                  .HasForeignKey(a => a.ProfessionalId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Specialty)
                  .WithMany(s => s.Appointments)
                  .HasForeignKey(a => a.SpecialtyId)
                  .OnDelete(DeleteBehavior.Restrict);

            // =====================================================================
            // ÍNDICES DE ALTO RENDIMIENTO PARA LA AGENDA VISUAL
            // =====================================================================
            // Optimiza la consulta diaria/semanal por médico filtrando no borrados
            entity.HasIndex(a => new { a.ProfessionalId, a.AppointmentDate, a.Status })
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("IX_Appointments_AgendaLookup");

            // Optimiza el historial de turnos del paciente
            entity.HasIndex(a => new { a.PatientId, a.AppointmentDate })
                  .HasFilter("[IsDeleted] = 0")
                  .HasDatabaseName("IX_Appointments_PatientHistory");
        });

        // =========================================================================
        // G. CAJA DIARIA Y COBROS
        // =========================================================================
        modelBuilder.Entity<CashSession>(entity =>
        {
            entity.ToTable("CashSessions");
            entity.HasKey(cs => cs.Id);

            entity.Property(cs => cs.StationName).IsRequired().HasMaxLength(50);
            entity.Property(cs => cs.InitialCash).HasPrecision(18, 2);
            entity.Property(cs => cs.RealCash).HasPrecision(18, 2);
            entity.Property(cs => cs.ExpectedCash).HasPrecision(18, 2);
            entity.Property(cs => cs.Difference).HasPrecision(18, 2);

            entity.Property(cs => cs.TotalCashIncome).HasPrecision(18, 2);
            entity.Property(cs => cs.TotalDebitIncome).HasPrecision(18, 2);
            entity.Property(cs => cs.TotalCreditIncome).HasPrecision(18, 2);
            entity.Property(cs => cs.TotalTransferIncome).HasPrecision(18, 2);
            entity.Property(cs => cs.TotalQrIncome).HasPrecision(18, 2);

            entity.Property(cs => cs.TotalManualCashIn).HasPrecision(18, 2);
            entity.Property(cs => cs.TotalManualCashOut).HasPrecision(18, 2);

            entity.Property(cs => cs.Status).IsRequired().HasMaxLength(20);
            entity.Property(cs => cs.ClosingNotes).HasMaxLength(250);

            // Solo puede haber una sesión abierta a la vez por puesto/recepción
            entity.HasIndex(cs => new { cs.StationName, cs.Status })
                  .IsUnique()
                  .HasFilter($"[Status] = '{CashSessionStatusesConstants.OPEN}'")
                  .HasDatabaseName("UQ_CashSessions_SingleActivePerStation");

            entity.HasOne(cs => cs.User)
                  .WithMany(u => u.CashSessions)
                  .HasForeignKey(cs => cs.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(cs => cs.CashMovements)
                  .WithOne(cm => cm.CashSession)
                  .HasForeignKey(cm => cm.CashSessionId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CashMovement>(entity =>
        {
            entity.ToTable("CashMovements");
            entity.HasKey(cm => cm.Id);

            entity.Property(cm => cm.Amount).HasPrecision(18, 2);
            entity.Property(cm => cm.Description).IsRequired().HasMaxLength(200);
            entity.Property(cm => cm.MovementType).HasConversion<int>();

            entity.HasOne(cm => cm.User)
                  .WithMany()
                  .HasForeignKey(cm => cm.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ConsultationPayment>(entity =>
        {
            entity.ToTable("ConsultationPayments");
            entity.HasKey(cp => cp.Id);

            entity.Property(cp => cp.Amount).HasPrecision(18, 2);
            entity.Property(cp => cp.CopayAmount).HasPrecision(18, 2);
            entity.Property(cp => cp.PaymentReceived).HasPrecision(18, 2);
            entity.Property(cp => cp.PaymentChange).HasPrecision(18, 2);
            entity.Property(cp => cp.ReceiptNumber).IsRequired().HasMaxLength(50);
            entity.Property(cp => cp.Observations).HasMaxLength(250);

            entity.HasOne(cp => cp.Appointment)
                  .WithMany(a => a.Payments)
                  .HasForeignKey(cp => cp.AppointmentId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(cp => cp.CashSession)
                  .WithMany(cs => cs.Payments)
                  .HasForeignKey(cp => cp.CashSessionId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(cp => cp.PaymentMethod)
                  .WithMany()
                  .HasForeignKey(cp => cp.PaymentMethodId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(cp => cp.User)
                  .WithMany()
                  .HasForeignKey(cp => cp.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.ToTable("PaymentMethods");
            entity.HasKey(pm => pm.Id);
            entity.Property(pm => pm.Name).IsRequired().HasMaxLength(50);
        });

        // =========================================================================
        // H. CONFIGURACIÓN DEL CONSULTORIO
        // =========================================================================
        modelBuilder.Entity<ClinicSettings>(entity =>
        {
            entity.ToTable("ClinicSettings");
            entity.HasKey(cs => cs.Id);

            entity.Property(cs => cs.ClinicName).IsRequired().HasMaxLength(100);
            entity.Property(cs => cs.Cuit).HasMaxLength(20);
            entity.Property(cs => cs.Address).HasMaxLength(150);
            entity.Property(cs => cs.Phone).HasMaxLength(30);
            entity.Property(cs => cs.Email).HasMaxLength(100);
            entity.Property(cs => cs.ReceiptFormat).HasMaxLength(20);
            entity.Property(cs => cs.ReceiptFooterMessage).HasMaxLength(250);
            entity.Property(cs => cs.ThermalPrinterName).HasMaxLength(100);
            entity.Property(cs => cs.Logo).HasColumnType("varbinary(max)").IsRequired(false);
        });

        // =========================================================================
        // I. FILTROS GLOBALES DE BORRADO LÓGICO
        // =========================================================================
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(GenerateIsDeletedFilter(entityType.ClrType));
            }
        }
    }

    private static LambdaExpression GenerateIsDeletedFilter(Type type)
    {
        var parameter = Expression.Parameter(type, "it");
        var property = Expression.Property(parameter, nameof(AuditableEntity.IsDeleted));
        var falseConstant = Expression.Constant(false);
        var comparison = Expression.Equal(property, falseConstant);
        return Expression.Lambda(comparison, parameter);
    }

    // =========================================================================
    // J. INTERCEPTOR AUTOMÁTICO DE AUDITORÍA
    // =========================================================================
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();
        var currentUsername = _currentUserService.Username ?? RoleConstants.DEFAULT_ADMIN_USERNAME;

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = currentUsername;
                    entry.Entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastUpdatedAt = DateTime.UtcNow;
                    entry.Entity.LastUpdatedBy = currentUsername;

                    entry.Property(x => x.CreatedAt).IsModified = false;
                    entry.Property(x => x.CreatedBy).IsModified = false;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}