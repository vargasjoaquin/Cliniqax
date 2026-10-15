using CliniqaxSystem.Domain.Constants;
using CliniqaxSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

            // 6. Tipos de Diagnóstico
            if (!await context.DiagnosisTypes.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[DiagnosisTypes] ON;");

                    await context.DiagnosisTypes.AddRangeAsync(
                        new DiagnosisType { Id = DiagnosisTypeConstants.PRESUMPTIVE, Name = "Presuntivo", Description = "Diagnóstico preliminar basado en la sospecha clínica inicial", IsActive = true },
                        new DiagnosisType { Id = DiagnosisTypeConstants.DEFINITIVE, Name = "Definitivo", Description = "Diagnóstico confirmado mediante evaluación o estudios complementarios", IsActive = true },
                        new DiagnosisType { Id = DiagnosisTypeConstants.DIFFERENTIAL, Name = "Diferencial", Description = "Diagnóstico alternativo evaluado para descartar otras patologías", IsActive = true }
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

            // 7. Estados de Consulta Médica
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

            // 8. Categorías de Estudios y Archivos Adjuntos
            if (!await context.AttachmentCategories.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[AttachmentCategories] ON;");

                    await context.AttachmentCategories.AddRangeAsync(
                        new AttachmentCategory { Id = AttachmentCategoryConstants.LABORATORY, Name = "Laboratorio / Análisis Clínicos", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.IMAGING, Name = "Diagnóstico por Imágenes (Rayos, Eco, RMN)", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.CARDIOLOGY, Name = "Cardiología / Trazados (ECG, Holter)", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.SURGICAL_REPORTS, Name = "Informes Quirúrgicos / Biopsias", IsActive = true },
                        new AttachmentCategory { Id = AttachmentCategoryConstants.EXTERNAL_DOCS, Name = "Certificados y Documentación Externa", IsActive = true },
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

            // 9 Canales de Notificación
            if (!await context.NotificationChannels.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[NotificationChannels] ON;");

                    await context.NotificationChannels.AddRangeAsync(
                        new NotificationChannel { Id = NotificationChannelConstants.EMAIL, Name = NotificationChannelConstants.EMAIL_NAME, IsActive = true },
                        new NotificationChannel { Id = NotificationChannelConstants.WHATSAPP, Name = NotificationChannelConstants.WHATSAPP_NAME, IsActive = true }
                    );

                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[NotificationChannels] OFF;");
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            // 10. Estados de Notificación
            if (!await context.NotificationStatuses.AnyAsync())
            {
                using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[NotificationStatuses] ON;");

                    await context.NotificationStatuses.AddRangeAsync(
                        new NotificationStatus { Id = NotificationStatusConstants.PENDING, Name = "Pendiente", IsActive = true },
                        new NotificationStatus { Id = NotificationStatusConstants.PROCESSING, Name = "Procesando", IsActive = true },
                        new NotificationStatus { Id = NotificationStatusConstants.SENT, Name = "Enviada", IsActive = true },
                        new NotificationStatus { Id = NotificationStatusConstants.FAILED, Name = "Fallida", IsActive = true },
                        new NotificationStatus { Id = NotificationStatusConstants.RETRYING, Name = "Reintentando", IsActive = true },
                        new NotificationStatus { Id = NotificationStatusConstants.CANCELLED, Name = "Cancelada", IsActive = true }
                    );

                    await context.SaveChangesAsync();
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[NotificationStatuses] OFF;");
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

            // 11.Plantillas Dinámicas de Comunicación
            if (!await context.NotificationTemplates.AnyAsync())
            {
                await context.NotificationTemplates.AddRangeAsync(
                    new NotificationTemplate
                    {
                        Code = NotificationTemplateCodes.REMINDER_APPOINTMENT,
                        ChannelId = NotificationChannelConstants.EMAIL,
                        Name = "Recordatorio de Turno (Email)",
                        SubjectTemplate = "Recordatorio de Turno Médico — {ClinicaNombre}",
                        BodyTemplate = "Hola {PacienteNombre}, le recordamos que tiene un turno programado con el/la Dr/a. {ProfesionalNombre} ({Especialidad}) para el día {FechaTurno} a las {HoraTurno} hs en {ClinicaDireccion}. Por favor, confirme su asistencia.",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new NotificationTemplate
                    {
                        Code = NotificationTemplateCodes.REMINDER_APPOINTMENT,
                        ChannelId = NotificationChannelConstants.WHATSAPP,
                        Name = "Recordatorio de Turno (WhatsApp)",
                        SubjectTemplate = null,
                        BodyTemplate = "Hola *{PacienteNombre}*. Te recordamos tu turno médico en *{ClinicaNombre}*:\n- Profesional: Dr/a. {ProfesionalNombre}\n- Especialidad: {Especialidad}\n- Fecha: {FechaTurno}\n- Hora: {HoraTurno} hs\nPor favor, confirmá tu asistencia.",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new NotificationTemplate
                    {
                        Code = NotificationTemplateCodes.APPOINTMENT_CONFIRMED,
                        ChannelId = NotificationChannelConstants.WHATSAPP,
                        Name = "Confirmación de Turno (WhatsApp)",
                        SubjectTemplate = null,
                        BodyTemplate = "Hola *{PacienteNombre}*, tu turno del día {FechaTurno} a las {HoraTurno} hs con Dr/a. {ProfesionalNombre} ha sido *CONFIRMADO* exitosamente.",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    },
                    new NotificationTemplate
                    {
                        Code = NotificationTemplateCodes.APPOINTMENT_CANCELLED,
                        ChannelId = NotificationChannelConstants.WHATSAPP,
                        Name = "Cancelación de Turno (WhatsApp)",
                        SubjectTemplate = null,
                        BodyTemplate = "Hola *{PacienteNombre}*, te informamos que tu turno del día {FechaTurno} a las {HoraTurno} hs con Dr/a. {ProfesionalNombre} ha sido *CANCELADO*.",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    }
                );
                await context.SaveChangesAsync();
            }

            // 12. Reglas de Recordatorios Automáticos
            if (!await context.ReminderRuleConfigs.AnyAsync())
            {
                var templateWhatsApp = await context.NotificationTemplates
                    .FirstOrDefaultAsync(t => t.Code == NotificationTemplateCodes.REMINDER_APPOINTMENT && t.ChannelId == NotificationChannelConstants.WHATSAPP);

                var templateEmail = await context.NotificationTemplates
                    .FirstOrDefaultAsync(t => t.Code == NotificationTemplateCodes.REMINDER_APPOINTMENT && t.ChannelId == NotificationChannelConstants.EMAIL);

                var rules = new List<ReminderRuleConfig>();

                if (templateWhatsApp != null)
                {
                    rules.Add(new ReminderRuleConfig
                    {
                        Name = "Recordatorio WhatsApp (24 horas antes)",
                        AdvanceHours = 24,
                        ChannelId = NotificationChannelConstants.WHATSAPP,
                        TemplateId = templateWhatsApp.Id,
                        IsEnabled = true
                    });

                    rules.Add(new ReminderRuleConfig
                    {
                        Name = "Recordatorio WhatsApp (2 horas antes)",
                        AdvanceHours = 2,
                        ChannelId = NotificationChannelConstants.WHATSAPP,
                        TemplateId = templateWhatsApp.Id,
                        IsEnabled = true
                    });
                }

                if (templateEmail != null)
                {
                    rules.Add(new ReminderRuleConfig
                    {
                        Name = "Recordatorio Email (24 horas antes)",
                        AdvanceHours = 24,
                        ChannelId = NotificationChannelConstants.EMAIL,
                        TemplateId = templateEmail.Id,
                        IsEnabled = true
                    });
                }

                if (rules.Any())
                {
                    await context.ReminderRuleConfigs.AddRangeAsync(rules);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}