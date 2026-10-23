using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqaxSystem.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // 1. Roles del Sistema
            if (!await context.Roles.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Roles] ON;");
                    
                    await context.Roles.AddRangeAsync(
                        new Role { Id = RoleConstants.ADMINISTRATOR_ROLE_ID, Name = RoleConstants.ADMINISTRATOR },
                        new Role { Id = RoleConstants.RECEPTIONIST_ROLE_ID, Name = RoleConstants.RECEPTIONIST },
                        new Role { Id = RoleConstants.PROFESSIONAL_ROLE_ID, Name = RoleConstants.PROFESSIONAL }
                    );

                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Roles] OFF;");
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            // 2. Usuario Administrador por Defecto
            var adminUser = await context.Users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Username == RoleConstants.DEFAULT_ADMIN_USERNAME);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    Username = RoleConstants.DEFAULT_ADMIN_USERNAME,
                    Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    FirstName = "Administrador",
                    LastName = "General",
                    Email = "admin@cliniqax.com",
                    RoleId = RoleConstants.ADMINISTRATOR_ROLE_ID,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };
                await context.Users.AddAsync(adminUser);
                await context.SaveChangesAsync();
            }

            // 3. Medios de Pago
            if (!await context.PaymentMethods.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[PaymentMethods] ON;");
                    
                    await context.PaymentMethods.AddRangeAsync(
                        new PaymentMethod { Id = PaymentMethodConstants.CASH_ID, Name = PaymentMethodConstants.CASH, IsActive = true },
                        new PaymentMethod { Id = PaymentMethodConstants.DEBIT_CARD_ID, Name = PaymentMethodConstants.DEBIT_CARD, IsActive = true },
                        new PaymentMethod { Id = PaymentMethodConstants.CREDIT_CARD_ID, Name = PaymentMethodConstants.CREDIT_CARD, IsActive = true },
                        new PaymentMethod { Id = PaymentMethodConstants.BANK_TRANSFER_ID, Name = PaymentMethodConstants.BANK_TRANSFER, IsActive = true },
                        new PaymentMethod { Id = PaymentMethodConstants.MERCADO_PAGO_QR_ID, Name = PaymentMethodConstants.MERCADO_PAGO_QR, IsActive = true }
                    );

                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF;");
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            // 4. Especialidades Médicas de Base
            if (!await context.Specialties.AnyAsync())
            {
                await context.Specialties.AddRangeAsync(
                    new Specialty { Name = "Clínica Médica", Description = "Medicina general de adultos", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Specialty { Name = "Pediatría", Description = "Atención integral de niños y adolescentes", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Specialty { Name = "Cardiología", Description = "Salud cardiovascular", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Specialty { Name = "Dermatología", Description = "Cuidado y diagnóstico de la piel", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Specialty { Name = "Traumatología", Description = "Aparato locomotor y lesiones", IsActive = true, CreatedAt = DateTime.UtcNow },
                    new Specialty { Name = "Odontología", Description = "Salud bucal general", IsActive = true, CreatedAt = DateTime.UtcNow }
                );
                await context.SaveChangesAsync();
            }

            // 5. Configuración Inicial del Consultorio
            if (!await context.ClinicSettings.AnyAsync())
            {
                await context.ClinicSettings.AddAsync(new ClinicSettings
                {
                    ClinicName = "Consultorio Médico Cliniqax",
                    Cuit = "30-11223344-5",
                    Address = "Av. Central 1234",
                    Phone = "011-4567-8900",
                    Email = "contacto@cliniqax.com",
                    ReceiptFormat = "80mm",
                    ReceiptFooterMessage = "Gracias por confiar en nuestros profesionales de la salud.",
                    ShowLogoOnReceipt = true,
                    AutoPrintReceipt = false
                });
                await context.SaveChangesAsync();
            }

            // 6. Tipos de Diagnostico
            if (!await context.DiagnosisTypes.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[DiagnosisTypes] ON;");
                    await context.DiagnosisTypes.AddRangeAsync(
                        new DiagnosisType { Id = DiagnosisTypeConstants.PRESUMPTIVE, Name = "Presuntivo", Description = "Diagnostico preliminar", IsActive = true },
                        new DiagnosisType { Id = DiagnosisTypeConstants.DEFINITIVE, Name = "Definitivo", Description = "Diagnostico confirmado", IsActive = true },
                        new DiagnosisType { Id = DiagnosisTypeConstants.DIFFERENTIAL, Name = "Diferencial", Description = "Diagnostico alternativo", IsActive = true }
                    );
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[DiagnosisTypes] OFF;");
                    await transaction.CommitAsync();
                }
                catch 
                {
                    await transaction.RollbackAsync();
                    throw; 
                }
            }

            // 7. Estados de Consulta Medica
            if (!await context.ConsultationStatuses.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[ConsultationStatuses] ON;");
                    await context.ConsultationStatuses.AddRangeAsync(
                        new ConsultationStatus { Id = ConsultationStatusConstants.IN_PROGRESS, Name = "En Curso", IsActive = true },
                        new ConsultationStatus { Id = ConsultationStatusConstants.COMPLETED, Name = "Finalizada", IsActive = true },
                        new ConsultationStatus { Id = ConsultationStatusConstants.CANCELLED, Name = "Anulada", IsActive = true }
                    );
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[ConsultationStatuses] OFF;");
                    await transaction.CommitAsync();
                }
                catch 
                {
                    await transaction.RollbackAsync(); 
                    throw; 
                }
            }

            // 8. Categorias de Archivos y Estudios
            if (!await context.AttachmentCategories.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[AttachmentCategories] ON;");
                    await context.AttachmentCategories.AddRangeAsync(
                        new AttachmentCategory { Id = AttachmentCategoryConstants.LABORATORY, Name = "Laboratorio / Analisis Clinicos", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.IMAGING, Name = "Diagnostico por Imagenes", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.CARDIOLOGY, Name = "Cardiologia / Trazados", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.SURGICAL_REPORTS, Name = "Informes Quirurgicos / Biopsias", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.EXTERNAL_DOCS, Name = "Certificados y Documentacion Externa", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.OTHER, Name = "Otros Estudios", IsActive = true }
                    );
                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[AttachmentCategories] OFF;");
                    await transaction.CommitAsync();
                }
                catch 
                {
                    await transaction.RollbackAsync();
                    throw; 
                }
            }
        }
    }
}