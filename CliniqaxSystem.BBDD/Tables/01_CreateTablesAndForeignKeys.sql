SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =========================================================================
-- 1. TABLAS MAESTRAS Y CATÁLOGOS BASE
-- =========================================================================

CREATE TABLE [dbo].[Roles] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)       NOT NULL,
    [RowVersion] ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Specialties] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)      NOT NULL,
    [Description]   NVARCHAR (250)      NULL,
    [IsActive]      BIT                 NOT NULL DEFAULT 1,
    [CreatedAt]     DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]     NVARCHAR (50)       NULL,
    [LastUpdatedAt] DATETIME2 (7)       NULL,
    [LastUpdatedBy] NVARCHAR (50)       NULL,
    [IsDeleted]     BIT                 NOT NULL DEFAULT 0,
    [RowVersion]    ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[HealthInsurances] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100)      NOT NULL,
    [Cuit]          NVARCHAR (20)       NULL,
    [Phone]         NVARCHAR (30)       NULL,
    [Email]         NVARCHAR (100)      NULL,
    [IsActive]      BIT                 NOT NULL DEFAULT 1,
    [CreatedAt]     DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]     NVARCHAR (50)       NULL,
    [LastUpdatedAt] DATETIME2 (7)       NULL,
    [LastUpdatedBy] NVARCHAR (50)       NULL,
    [IsDeleted]     BIT                 NOT NULL DEFAULT 0,
    [RowVersion]    ROWVERSION          NOT NULL,
    CONSTRAINT [PK_HealthInsurances] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[PaymentMethods] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)       NOT NULL,
    [IsActive] BIT                 NOT NULL DEFAULT 1,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[ClinicSettings] (
    [Id]                   INT IDENTITY (1, 1) NOT NULL,
    [ClinicName]           NVARCHAR (100)      NOT NULL,
    [Cuit]                 NVARCHAR (20)       NULL,
    [Address]              NVARCHAR (150)      NULL,
    [Phone]                NVARCHAR (30)       NULL,
    [Email]                NVARCHAR (100)      NULL,
    [Logo]                 VARBINARY (MAX)     NULL,
    [ReceiptFormat]        NVARCHAR (20)       NOT NULL DEFAULT '80mm',
    [ReceiptFooterMessage] NVARCHAR (250)      NULL,
    [ShowLogoOnReceipt]    BIT                 NOT NULL DEFAULT 1,
    [AutoPrintReceipt]     BIT                 NOT NULL DEFAULT 0,
    [ThermalPrinterName]   NVARCHAR (100)      NULL,
    [RowVersion]           ROWVERSION          NOT NULL,
    CONSTRAINT [PK_ClinicSettings] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- =========================================================================
-- 2. CATÁLOGOS CLÍNICOS
-- =========================================================================

CREATE TABLE [dbo].[DiagnosisTypes] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)       NOT NULL,
    [Description] NVARCHAR (150)      NULL,
    [IsActive]    BIT                 NOT NULL DEFAULT 1,
    CONSTRAINT [PK_DiagnosisTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[ConsultationStatuses] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)       NOT NULL,
    [IsActive] BIT                 NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ConsultationStatuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[AttachmentCategories] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)       NOT NULL,
    [IsActive] BIT                 NOT NULL DEFAULT 1,
    CONSTRAINT [PK_AttachmentCategories] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- =========================================================================
-- 3. PROFESIONALES Y HORARIOS
-- =========================================================================

CREATE TABLE [dbo].[Professionals] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [FirstName]           NVARCHAR (50)       NOT NULL,
    [LastName]            NVARCHAR (50)       NOT NULL,
    [DocumentNumber]      NVARCHAR (20)       NOT NULL,
    [LicenseNumber]       NVARCHAR (30)       NOT NULL, -- Matrícula profesional
    [Phone]               NVARCHAR (30)       NULL,
    [Email]               NVARCHAR (100)      NULL,
    [AppointmentDuration] INT                 NOT NULL DEFAULT 30,
    [IsActive]            BIT                 NOT NULL DEFAULT 1,
    [Observations]        NVARCHAR (500)      NULL,
    [CreatedAt]           DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]           NVARCHAR (50)       NULL,
    [LastUpdatedAt]       DATETIME2 (7)       NULL,
    [LastUpdatedBy]       NVARCHAR (50)       NULL,
    [IsDeleted]           BIT                 NOT NULL DEFAULT 0,
    [RowVersion]          ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Professionals] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[ProfessionalSpecialties] (
    [ProfessionalId] INT NOT NULL,
    [SpecialtyId]    INT NOT NULL,
    CONSTRAINT [PK_ProfessionalSpecialties] PRIMARY KEY CLUSTERED ([ProfessionalId] ASC, [SpecialtyId] ASC),
    CONSTRAINT [FK_ProfSpec_Professional] FOREIGN KEY ([ProfessionalId]) REFERENCES [dbo].[Professionals] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProfSpec_Specialty]    FOREIGN KEY ([SpecialtyId])    REFERENCES [dbo].[Specialties] ([Id])    ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[ProfessionalSchedules] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [ProfessionalId] INT                 NOT NULL,
    [DayOfWeek]      INT                 NOT NULL,
    [StartTime]      TIME (7)            NOT NULL,
    [EndTime]        TIME (7)            NOT NULL,
    [IsActive]       BIT                 NOT NULL DEFAULT 1,
    [RowVersion]     ROWVERSION          NOT NULL,
    CONSTRAINT [PK_ProfessionalSchedules] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ProfSchedules_Professional] FOREIGN KEY ([ProfessionalId]) REFERENCES [dbo].[Professionals] ([Id]) ON DELETE CASCADE
);
GO

-- =========================================================================
-- 4. USUARIOS Y PACIENTES
-- =========================================================================

CREATE TABLE [dbo].[Users] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [Username]       NVARCHAR (50)       NOT NULL,
    [Password]       NVARCHAR (255)      NOT NULL,
    [FirstName]      NVARCHAR (50)       NOT NULL,
    [LastName]       NVARCHAR (50)       NOT NULL,
    [Email]          NVARCHAR (100)      NULL,
    [RoleId]         INT                 NOT NULL,
    [ProfessionalId] INT                 NULL,
    [IsActive]       BIT                 NOT NULL DEFAULT 1,
    [Photo]          VARBINARY (MAX)     NULL,
    [CreatedAt]      DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]      NVARCHAR (50)       NULL,
    [LastUpdatedAt]  DATETIME2 (7)       NULL,
    [LastUpdatedBy]  NVARCHAR (50)       NULL,
    [IsDeleted]      BIT                 NOT NULL DEFAULT 0,
    [RowVersion]     ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles]         FOREIGN KEY ([RoleId])         REFERENCES [dbo].[Roles] ([Id]),
    CONSTRAINT [FK_Users_Professionals] FOREIGN KEY ([ProfessionalId]) REFERENCES [dbo].[Professionals] ([Id]) ON DELETE SET NULL
);
GO

CREATE TABLE [dbo].[Patients] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [DocumentNumber]      NVARCHAR (20)       NOT NULL,
    [FirstName]           NVARCHAR (50)       NOT NULL,
    [LastName]            NVARCHAR (50)       NOT NULL,
    [BirthDate]           DATE                NOT NULL,
    [Phone]               NVARCHAR (30)       NOT NULL,
    [Email]               NVARCHAR (100)      NULL,
    [Address]             NVARCHAR (150)      NULL,
    [City]                NVARCHAR (80)       NULL,
    [HealthInsuranceId]   INT                 NULL,
    [AffiliateNumber]     NVARCHAR (50)       NULL,
    [AdministrativeNotes] NVARCHAR (500)      NULL,
    [IsActive]            BIT                 NOT NULL DEFAULT 1,
    [CreatedAt]           DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]           NVARCHAR (50)       NULL,
    [LastUpdatedAt]       DATETIME2 (7)       NULL,
    [LastUpdatedBy]       NVARCHAR (50)       NULL,
    [IsDeleted]           BIT                 NOT NULL DEFAULT 0,
    [RowVersion]          ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Patients_HealthInsurances] FOREIGN KEY ([HealthInsuranceId]) REFERENCES [dbo].[HealthInsurances] ([Id])
);
GO

-- =========================================================================
-- 5. HISTORIA CLÍNICA Y GESTIÓN MÉDICA
-- =========================================================================

CREATE TABLE [dbo].[MedicalRecords] (
    [Id]                     INT IDENTITY (1, 1) NOT NULL,
    [PatientId]              INT                 NOT NULL,
    [RecordNumber]           NVARCHAR (30)       NOT NULL,
    [BloodType]              NVARCHAR (10)       NULL,
    [Allergies]              NVARCHAR (500)      NULL,
    [PathologicalHistory]    NVARCHAR (MAX)      NULL,
    [NonPathologicalHistory] NVARCHAR (MAX)      NULL,
    [SurgicalHistory]        NVARCHAR (MAX)      NULL,
    [FamilyHistory]          NVARCHAR (MAX)      NULL,
    [GeneralObservations]    NVARCHAR (MAX)      NULL,
    [CreatedAt]              DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]              NVARCHAR (50)       NULL,
    [LastUpdatedAt]          DATETIME2 (7)       NULL,
    [LastUpdatedBy]          NVARCHAR (50)       NULL,
    [IsDeleted]              BIT                 NOT NULL DEFAULT 0,
    [RowVersion]             ROWVERSION          NOT NULL,
    CONSTRAINT [PK_MedicalRecords] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MedicalRecords_Patients] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patients] ([Id]) ON DELETE NO ACTION
);
GO

-- =========================================================================
-- 6. TURNOS Y ATENCIÓN
-- =========================================================================

CREATE TABLE [dbo].[Appointments] (
    [Id]                 INT IDENTITY (1, 1) NOT NULL,
    [PatientId]          INT                 NOT NULL,
    [ProfessionalId]     INT                 NOT NULL,
    [SpecialtyId]        INT                 NOT NULL,
    [AppointmentDate]    DATE                NOT NULL,
    [StartTime]          TIME (7)            NOT NULL,
    [EndTime]            TIME (7)            NOT NULL,
    [Status]             INT                 NOT NULL, -- 1= Pendiente, 2= Confirmado, 3= En espera, 4= Atendido, 5= Cancelado, 6= Ausente, 7= Reprogramado
    [CancellationReason] NVARCHAR (250)      NULL,
    [Observations]       NVARCHAR (500)      NULL,
    [HasClinicalHistory] BIT                 NOT NULL DEFAULT 0,
    [CreatedAt]          DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]          NVARCHAR (50)       NULL,
    [LastUpdatedAt]      DATETIME2 (7)       NULL,
    [LastUpdatedBy]      NVARCHAR (50)       NULL,
    [IsDeleted]          BIT                 NOT NULL DEFAULT 0,
    [RowVersion]         ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Appointments_Patients]      FOREIGN KEY ([PatientId])      REFERENCES [dbo].[Patients] ([Id]),
    CONSTRAINT [FK_Appointments_Professionals] FOREIGN KEY ([ProfessionalId]) REFERENCES [dbo].[Professionals] ([Id]),
    CONSTRAINT [FK_Appointments_Specialties]   FOREIGN KEY ([SpecialtyId])    REFERENCES [dbo].[Specialties] ([Id])
);
GO

-- =========================================================================
-- 7. CONSULTAS MÉDICAS, EVOLUCIONES, DIAGNÓSTICOS Y ADJUNTOS
-- =========================================================================

CREATE TABLE [dbo].[Consultations] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [MedicalRecordId]       INT                 NOT NULL,
    [ProfessionalId]        INT                 NOT NULL,
    [SpecialtyId]           INT                 NOT NULL,
    [ConsultationStatusId]  INT                 NOT NULL DEFAULT 2,
    [AppointmentId]         INT                 NULL,
    [ConsultationDate]      DATETIME2 (7)       NOT NULL,
    [ReasonForConsultation] NVARCHAR (500)       NOT NULL,
    [PhysicalExamination]   NVARCHAR (MAX)      NULL,
    [Notes]                 NVARCHAR (MAX)      NULL,
    [CreatedAt]             DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]             NVARCHAR (50)       NULL,
    [LastUpdatedAt]         DATETIME2 (7)       NULL,
    [LastUpdatedBy]         NVARCHAR (50)       NULL,
    [IsDeleted]             BIT                 NOT NULL DEFAULT 0,
    [RowVersion]            ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Consultations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Consultations_MedicalRecords]      FOREIGN KEY ([MedicalRecordId])      REFERENCES [dbo].[MedicalRecords] ([Id])       ON DELETE NO ACTION,
    CONSTRAINT [FK_Consultations_Professionals]       FOREIGN KEY ([ProfessionalId])       REFERENCES [dbo].[Professionals] ([Id])        ON DELETE NO ACTION,
    CONSTRAINT [FK_Consultations_Specialties]         FOREIGN KEY ([SpecialtyId])          REFERENCES [dbo].[Specialties] ([Id])          ON DELETE NO ACTION,
    CONSTRAINT [FK_Consultations_ConsultationStatuses]FOREIGN KEY ([ConsultationStatusId]) REFERENCES [dbo].[ConsultationStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Consultations_Appointments]        FOREIGN KEY ([AppointmentId])        REFERENCES [dbo].[Appointments] ([Id])        ON DELETE SET NULL
);
GO

CREATE TABLE [dbo].[ClinicalEvolutions] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [ConsultationId] INT                 NOT NULL,
    [Description]    NVARCHAR (MAX)      NOT NULL,
    [EvolutionDate]  DATETIME2 (7)       NOT NULL,
    [CreatedAt]      DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]      NVARCHAR (50)       NULL,
    [RowVersion]     ROWVERSION          NOT NULL,
    CONSTRAINT [PK_ClinicalEvolutions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClinicalEvolutions_Consultations] FOREIGN KEY ([ConsultationId]) REFERENCES [dbo].[Consultations] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[ClinicalDiagnoses] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [ConsultationId]  INT                 NOT NULL,
    [DiagnosisTypeId] INT                 NOT NULL DEFAULT 2,
    [Description]     NVARCHAR (250)      NOT NULL,
    [DiagnosticCode]  NVARCHAR (20)       NULL,
    [Notes]           NVARCHAR (500)      NULL,
    [CreatedAt]       DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]       NVARCHAR (50)       NULL,
    [RowVersion]      ROWVERSION          NOT NULL,
    CONSTRAINT [PK_ClinicalDiagnoses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClinicalDiagnoses_Consultations]  FOREIGN KEY ([ConsultationId])  REFERENCES [dbo].[Consultations] ([Id])  ON DELETE CASCADE,
    CONSTRAINT [FK_ClinicalDiagnoses_DiagnosisTypes] FOREIGN KEY ([DiagnosisTypeId]) REFERENCES [dbo].[DiagnosisTypes] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [dbo].[MedicalInstructions] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [ConsultationId]    INT                 NOT NULL,
    [Instructions]      NVARCHAR (MAX)      NOT NULL,
    [MedicationDetails] NVARCHAR (MAX)      NULL,
    [FollowUpNotes]     NVARCHAR (500)      NULL,
    [CreatedAt]         DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]         NVARCHAR (50)       NULL,
    [RowVersion]        ROWVERSION          NOT NULL,
    CONSTRAINT [PK_MedicalInstructions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MedicalInstructions_Consultations] FOREIGN KEY ([ConsultationId]) REFERENCES [dbo].[Consultations] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[MedicalAttachments] (
    [Id]                   INT IDENTITY (1, 1) NOT NULL,
    [MedicalRecordId]      INT                 NOT NULL,
    [ConsultationId]       INT                 NULL,
    [AttachmentCategoryId] INT                 NULL,
    [OriginalFileName]     NVARCHAR (255)      NOT NULL,
    [StoredFileName]       NVARCHAR (255)      NOT NULL,
    [RelativePath]         NVARCHAR (500)      NOT NULL,
    [FileExtension]        NVARCHAR (20)       NOT NULL,
    [ContentType]          NVARCHAR (100)      NOT NULL,
    [FileSizeBytes]        BIGINT              NOT NULL,
    [Notes]                NVARCHAR (500)      NULL,
    [CreatedAt]            DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy]            NVARCHAR (50)       NULL,
    [LastUpdatedAt]        DATETIME2 (7)       NULL,
    [LastUpdatedBy]        NVARCHAR (50)       NULL,
    [IsDeleted]            BIT                 NOT NULL DEFAULT 0,
    [RowVersion]           ROWVERSION          NOT NULL,
    CONSTRAINT [PK_MedicalAttachments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MedicalAttachments_MedicalRecords]      FOREIGN KEY ([MedicalRecordId])      REFERENCES [dbo].[MedicalRecords] ([Id])        ON DELETE NO ACTION,
    CONSTRAINT [FK_MedicalAttachments_Consultations]       FOREIGN KEY ([ConsultationId])       REFERENCES [dbo].[Consultations] ([Id])         ON DELETE SET NULL,
    CONSTRAINT [FK_MedicalAttachments_AttachmentCategories]FOREIGN KEY ([AttachmentCategoryId]) REFERENCES [dbo].[AttachmentCategories] ([Id]) ON DELETE SET NULL
);
GO

-- =========================================================================
-- 8. CAJA DIARIA Y COBROS
-- =========================================================================

CREATE TABLE [dbo].[CashSessions] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [UserId]              INT                 NOT NULL,
    [StationName]         NVARCHAR (50)       NOT NULL DEFAULT 'Recepción Principal',
    [OpeningDate]         DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [ClosingDate]         DATETIME2 (7)       NULL,
    [InitialCash]         DECIMAL (18, 2)     NOT NULL,
    [RealCash]            DECIMAL (18, 2)     NULL,
    [ExpectedCash]        DECIMAL (18, 2)     NULL,
    [Difference]          DECIMAL (18, 2)     NULL,
    [TotalCashIncome]     DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [TotalDebitIncome]    DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [TotalCreditIncome]   DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [TotalTransferIncome] DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [TotalQrIncome]       DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [TotalManualCashIn]   DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [TotalManualCashOut]  DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [Status]              NVARCHAR (20)       NOT NULL DEFAULT 'Abierta',
    [ClosingNotes]        NVARCHAR (250)      NULL,
    [RowVersion]          ROWVERSION          NOT NULL,
    CONSTRAINT [PK_CashSessions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashSessions_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);
GO

CREATE TABLE [dbo].[CashMovements] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [CashSessionId] INT                 NOT NULL,
    [UserId]        INT                 NOT NULL,
    [MovementType]  INT                 NOT NULL, -- 1: Ingreso manual, 2: Retiro manual
    [Amount]        DECIMAL (18, 2)     NOT NULL,
    [Description]   NVARCHAR (200)      NOT NULL,
    [CreatedAt]     DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [RowVersion]    ROWVERSION          NOT NULL,
    CONSTRAINT [PK_CashMovements] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashMovements_CashSessions] FOREIGN KEY ([CashSessionId]) REFERENCES [dbo].[CashSessions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CashMovements_Users]        FOREIGN KEY ([UserId])        REFERENCES [dbo].[Users] ([Id])
);
GO

CREATE TABLE [dbo].[ConsultationPayments] (
    [Id]              INT IDENTITY (1, 1) NOT NULL,
    [AppointmentId]   INT                 NOT NULL,
    [CashSessionId]   INT                 NOT NULL,
    [UserId]          INT                 NOT NULL,
    [PaymentMethodId] INT                 NOT NULL,
    [Amount]          DECIMAL (18, 2)     NOT NULL,
    [CopayAmount]     DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [PaymentReceived] DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [PaymentChange]   DECIMAL (18, 2)     NOT NULL DEFAULT 0,
    [ReceiptNumber]   NVARCHAR (50)       NOT NULL,
    [Observations]    NVARCHAR (250)      NULL,
    [CreatedAt]       DATETIME2 (7)       NOT NULL DEFAULT SYSUTCDATETIME(),
    [RowVersion]      ROWVERSION          NOT NULL,
    CONSTRAINT [PK_ConsultationPayments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments_Appointments]   FOREIGN KEY ([AppointmentId])   REFERENCES [dbo].[Appointments] ([Id]),
    CONSTRAINT [FK_Payments_CashSessions]   FOREIGN KEY ([CashSessionId])   REFERENCES [dbo].[CashSessions] ([Id]),
    CONSTRAINT [FK_Payments_PaymentMethods] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethods] ([Id]),
    CONSTRAINT [FK_Payments_Users]          FOREIGN KEY ([UserId])          REFERENCES [dbo].[Users] ([Id])
);
GO