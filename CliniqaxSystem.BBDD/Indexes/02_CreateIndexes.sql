SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =========================================================================
-- 1. ÍNDICES DE SEGURIDAD Y USUARIOS
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Users_Username]
ON [dbo].[Users] ([Username] ASC);
GO

-- Garantiza un único Administrador principal activo
CREATE UNIQUE NONCLUSTERED INDEX [UQ_Users_SingleActiveAdmin]
ON [dbo].[Users] ([RoleId] ASC)
WHERE ([RoleId] = 1 AND [IsDeleted] = 0);
GO

CREATE NONCLUSTERED INDEX [IX_Users_RoleId]
ON [dbo].[Users] ([RoleId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Users_ProfessionalId]
ON [dbo].[Users] ([ProfessionalId] ASC);
GO

-- =========================================================================
-- 2. ÍNDICES DE ESPECIALIDADES Y OBRAS SOCIALES
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Specialties_ActiveName]
ON [dbo].[Specialties] ([Name] ASC)
WHERE ([IsDeleted] = 0);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_HealthInsurances_ActiveName]
ON [dbo].[HealthInsurances] ([Name] ASC)
WHERE ([IsDeleted] = 0);
GO

-- =========================================================================
-- 3. ÍNDICES DE PACIENTES
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Patients_ActiveDocumentNumber]
ON [dbo].[Patients] ([DocumentNumber] ASC)
WHERE ([IsDeleted] = 0);
GO

CREATE NONCLUSTERED INDEX [IX_Patients_HealthInsuranceId]
ON [dbo].[Patients] ([HealthInsuranceId] ASC);
GO

-- =========================================================================
-- 4. ÍNDICES DE PROFESIONALES Y HORARIOS
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Professionals_ActiveDocumentNumber]
ON [dbo].[Professionals] ([DocumentNumber] ASC)
WHERE ([IsDeleted] = 0);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Professionals_ActiveLicenseNumber]
ON [dbo].[Professionals] ([LicenseNumber] ASC)
WHERE ([IsDeleted] = 0);
GO

CREATE NONCLUSTERED INDEX [IX_ProfessionalSchedules_ProfessionalId]
ON [dbo].[ProfessionalSchedules] ([ProfessionalId] ASC);
GO

-- =========================================================================
-- 5. ÍNDICES DE HISTORIA CLÍNICA Y GESTIÓN MÉDICA
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [UQ_MedicalRecords_PatientId]
ON [dbo].[MedicalRecords] ([PatientId] ASC)
WHERE ([IsDeleted] = 0);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_MedicalRecords_RecordNumber]
ON [dbo].[MedicalRecords] ([RecordNumber] ASC)
WHERE ([IsDeleted] = 0);
GO

CREATE NONCLUSTERED INDEX [IX_Consultations_Record_Date]
ON [dbo].[Consultations] ([MedicalRecordId] ASC, [ConsultationDate] DESC)
WHERE ([IsDeleted] = 0);
GO

CREATE NONCLUSTERED INDEX [IX_MedicalAttachments_Record]
ON [dbo].[MedicalAttachments] ([MedicalRecordId] ASC, [CreatedAt] DESC)
WHERE ([IsDeleted] = 0);
GO

-- =========================================================================
-- 6. ÍNDICES DE ALTO RENDIMIENTO PARA LA AGENDA MÉDICA
-- =========================================================================

-- Optimiza el cálculo de franjas y la carga diaria/semanal por médico
CREATE NONCLUSTERED INDEX [IX_Appointments_AgendaLookup]
ON [dbo].[Appointments] ([ProfessionalId] ASC, [AppointmentDate] ASC, [Status] ASC)
INCLUDE ([PatientId], [SpecialtyId], [StartTime], [EndTime], [HasClinicalHistory])
WHERE ([IsDeleted] = 0);
GO

-- Optimiza la consulta del historial de turnos de un paciente
CREATE NONCLUSTERED INDEX [IX_Appointments_PatientHistory]
ON [dbo].[Appointments] ([PatientId] ASC, [AppointmentDate] ASC)
INCLUDE ([ProfessionalId], [SpecialtyId], [Status])
WHERE ([IsDeleted] = 0);
GO

CREATE NONCLUSTERED INDEX [IX_Appointments_SpecialtyId]
ON [dbo].[Appointments] ([SpecialtyId] ASC);
GO

-- =========================================================================
-- 7. ÍNDICES DE CAJA DIARIA, MOVIMIENTOS Y COBROS
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [UQ_CashSessions_SingleActivePerStation]
ON [dbo].[CashSessions] ([StationName] ASC, [Status] ASC)
WHERE ([Status] = 'Abierta');
GO

CREATE NONCLUSTERED INDEX [IX_CashSessions_UserId]
ON [dbo].[CashSessions] ([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_CashMovements_CashSessionId]
ON [dbo].[CashMovements] ([CashSessionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ConsultationPayments_AppointmentId]
ON [dbo].[ConsultationPayments] ([AppointmentId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ConsultationPayments_CashSessionId]
ON [dbo].[ConsultationPayments] ([CashSessionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ConsultationPayments_PaymentMethodId]
ON [dbo].[ConsultationPayments] ([PaymentMethodId] ASC);
GO
CREATE NONCLUSTERED INDEX [IX_CashMovements_UserId]
ON [dbo].[CashMovements] ([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_ConsultationPayments_UserId]
ON [dbo].[ConsultationPayments] ([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Notifications_Queue_Processing]
ON [dbo].[Notifications] ([StatusId] ASC, [ScheduledAt] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_AuditLogs_Entity_Date]
ON [dbo].[AuditLogs] ([EntityName] ASC, [Timestamp] DESC);
GO