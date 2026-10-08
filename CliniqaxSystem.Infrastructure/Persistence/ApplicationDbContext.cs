using CliniqaxSystem.Application.Interfaces.Services;
using CliniqaxSystem.Domain.Common;
using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CliniqaxSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
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
    public DbSet<ProfessionalSpecialty> ProfessionalSpecialties => Set<ProfessionalSpecialty>();
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

    // ==========================================
    // 6. GESTIÓN CLÍNICA Y EXPEDIENTE DIGITAL
    // ==========================================
    public DbSet<DiagnosisType> DiagnosisTypes => Set<DiagnosisType>();
    public DbSet<ConsultationStatus> ConsultationStatuses => Set<ConsultationStatus>();
    public DbSet<AttachmentCategory> AttachmentCategories => Set<AttachmentCategory>();

    public DbSet<MedicalRecord> MedicalRecords => Set<MedicalRecord>();
    public DbSet<Consultation> Consultations => Set<Consultation>();
    public DbSet<ClinicalEvolution> ClinicalEvolutions => Set<ClinicalEvolution>();
    public DbSet<ClinicalDiagnosis> ClinicalDiagnoses => Set<ClinicalDiagnosis>();
    public DbSet<MedicalInstruction> MedicalInstructions => Set<MedicalInstruction>();
    public DbSet<MedicalAttachment> MedicalAttachments => Set<MedicalAttachment>();

    // ==========================================
    // 7. AUTOMATIZACIÓN, COMUNICACIÓN Y AUDITORÍA
    // ==========================================
    public DbSet<NotificationChannel> NotificationChannels => Set<NotificationChannel>();
    public DbSet<NotificationStatus> NotificationStatuses => Set<NotificationStatus>();
    public DbSet<NotificationTemplate> NotificationTemplates => Set<NotificationTemplate>();
    public DbSet<ReminderRuleConfig> ReminderRuleConfigs => Set<ReminderRuleConfig>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<BackupExecutionLog> BackupExecutionLogs => Set<BackupExecutionLog>();

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
        modelBuilder.Entity<ProfessionalSpecialty>(entity =>
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
        // I. GESTIÓN CLÍNICA Y EXPEDIENTE DIGITAL
        // =========================================================================
        modelBuilder.Entity<DiagnosisType>(entity =>
        {
            entity.ToTable("DiagnosisTypes");
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Name).IsRequired().HasMaxLength(50);
            entity.Property(d => d.Description).HasMaxLength(150);
        });

        modelBuilder.Entity<ConsultationStatus>(entity =>
        {
            entity.ToTable("ConsultationStatuses");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<AttachmentCategory>(entity =>
        {
            entity.ToTable("AttachmentCategories");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Name).IsRequired().HasMaxLength(50);
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.ToTable("MedicalRecords");
            entity.HasKey(m => m.Id);
            entity.Property(m => m.RecordNumber).IsRequired().HasMaxLength(30);
            entity.Property(m => m.BloodType).HasMaxLength(10);
            entity.Property(m => m.Allergies).HasMaxLength(500);

            entity.HasIndex(m => m.PatientId).IsUnique().HasFilter("[IsDeleted] = 0").HasDatabaseName("UQ_MedicalRecords_PatientId");
            entity.HasIndex(m => m.RecordNumber).IsUnique().HasFilter("[IsDeleted] = 0").HasDatabaseName("UQ_MedicalRecords_RecordNumber");

            entity.HasOne(m => m.Patient)
                  .WithOne()
                  .HasForeignKey<MedicalRecord>(m => m.PatientId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.ToTable("Consultations");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.ReasonForConsultation).IsRequired().HasMaxLength(500);
            entity.Property(c => c.ConsultationDate).HasColumnType("datetime2").IsRequired();

            entity.HasIndex(c => new { c.MedicalRecordId, c.ConsultationDate }).HasFilter("[IsDeleted] = 0").HasDatabaseName("IX_Consultations_Record_Date");

            entity.HasOne(c => c.MedicalRecord)
                  .WithMany(m => m.Consultations)
                  .HasForeignKey(c => c.MedicalRecordId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Professional)
                  .WithMany()
                  .HasForeignKey(c => c.ProfessionalId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Specialty)
                  .WithMany()
                  .HasForeignKey(c => c.SpecialtyId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.ConsultationStatus)
                  .WithMany()
                  .HasForeignKey(c => c.ConsultationStatusId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Appointment)
                  .WithMany()
                  .HasForeignKey(c => c.AppointmentId)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ClinicalEvolution>(entity =>
        {
            entity.ToTable("ClinicalEvolutions");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired();
            entity.HasOne(e => e.Consultation).WithMany(c => c.ClinicalEvolutions).HasForeignKey(e => e.ConsultationId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ClinicalDiagnosis>(entity =>
        {
            entity.ToTable("ClinicalDiagnoses");
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Description).IsRequired().HasMaxLength(250);
            entity.Property(d => d.DiagnosticCode).HasMaxLength(20);
            entity.Property(d => d.Notes).HasMaxLength(500);

            entity.HasOne(d => d.Consultation).WithMany(c => c.ClinicalDiagnoses).HasForeignKey(d => d.ConsultationId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(d => d.DiagnosisType).WithMany().HasForeignKey(d => d.DiagnosisTypeId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MedicalInstruction>(entity =>
        {
            entity.ToTable("MedicalInstructions");
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Instructions).IsRequired();
            entity.Property(i => i.FollowUpNotes).HasMaxLength(500);
            entity.HasOne(i => i.Consultation).WithMany(c => c.MedicalInstructions).HasForeignKey(i => i.ConsultationId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<MedicalAttachment>(entity =>
        {
            entity.ToTable("MedicalAttachments");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.OriginalFileName).IsRequired().HasMaxLength(255);
            entity.Property(a => a.StoredFileName).IsRequired().HasMaxLength(255);
            entity.Property(a => a.RelativePath).IsRequired().HasMaxLength(500);
            entity.Property(a => a.FileExtension).IsRequired().HasMaxLength(20);
            entity.Property(a => a.ContentType).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Notes).HasMaxLength(500);

            entity.HasOne(a => a.MedicalRecord).WithMany(m => m.MedicalAttachments).HasForeignKey(a => a.MedicalRecordId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(a => a.Consultation).WithMany(c => c.MedicalAttachments).HasForeignKey(a => a.ConsultationId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(a => a.AttachmentCategory).WithMany().HasForeignKey(a => a.AttachmentCategoryId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        });

        // =========================================================================
        // J.NOTIFICACIONES, REGLAS, AUDITORÍA Y BACKUPS
        // =========================================================================
        modelBuilder.Entity<NotificationChannel>(entity => { entity.ToTable("NotificationChannels"); entity.HasKey(c => c.Id); entity.Property(c => c.Name).IsRequired().HasMaxLength(50); });
        modelBuilder.Entity<NotificationStatus>(entity => { entity.ToTable("NotificationStatuses"); entity.HasKey(s => s.Id); entity.Property(s => s.Name).IsRequired().HasMaxLength(50); });

        modelBuilder.Entity<NotificationTemplate>(entity =>
        {
            entity.ToTable("NotificationTemplates");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Code).IsRequired().HasMaxLength(50);
            entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            entity.Property(t => t.SubjectTemplate).HasMaxLength(200);
            entity.Property(t => t.BodyTemplate).IsRequired();
            entity.HasIndex(t => new { t.Code, t.ChannelId }).IsUnique().HasDatabaseName("UQ_NotificationTemplates_Code_Channel");
            entity.HasOne(t => t.Channel).WithMany().HasForeignKey(t => t.ChannelId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ReminderRuleConfig>(entity =>
        {
            entity.ToTable("ReminderRuleConfigs");
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
            entity.HasOne(r => r.Channel).WithMany().HasForeignKey(r => r.ChannelId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(r => r.Template).WithMany().HasForeignKey(r => r.TemplateId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notifications");
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Recipient).IsRequired().HasMaxLength(150);
            entity.Property(n => n.Subject).HasMaxLength(200);
            entity.Property(n => n.MessageBody).IsRequired();
            entity.Property(n => n.TemplateCode).HasMaxLength(50);

            entity.HasIndex(n => new { n.StatusId, n.ScheduledAt }).HasDatabaseName("IX_Notifications_Queue_Processing");

            entity.HasOne(n => n.Appointment).WithMany().HasForeignKey(n => n.AppointmentId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(n => n.Patient).WithMany().HasForeignKey(n => n.PatientId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(n => n.Channel).WithMany().HasForeignKey(n => n.ChannelId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(n => n.Status).WithMany().HasForeignKey(n => n.StatusId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLogs");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Username).IsRequired().HasMaxLength(50);
            entity.Property(a => a.UserRole).IsRequired().HasMaxLength(50);
            entity.Property(a => a.Action).IsRequired().HasMaxLength(50);
            entity.Property(a => a.EntityName).IsRequired().HasMaxLength(50);
            entity.Property(a => a.EntityId).HasMaxLength(50);
            entity.Property(a => a.IpAddress).HasMaxLength(50);
            entity.HasIndex(a => new { a.EntityName, a.Timestamp }).HasDatabaseName("IX_AuditLogs_Entity_Date");
        });

        modelBuilder.Entity<BackupExecutionLog>(entity =>
        {
            entity.ToTable("BackupExecutionLogs");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.BackupType).IsRequired().HasMaxLength(50);
            entity.Property(b => b.DestinationPath).IsRequired().HasMaxLength(500);
            entity.Property(b => b.FileName).IsRequired().HasMaxLength(255);
            entity.Property(b => b.ExecutedBy).IsRequired().HasMaxLength(50);
        });

        // =========================================================================
        // K. FILTROS GLOBALES DE BORRADO LÓGICO
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