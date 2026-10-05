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
    [CreatedAt]     DATETIME2 (7)       NOT NULL,
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
    [CreatedAt]     DATETIME2 (7)       NOT NULL,
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
-- 2. PROFESIONALES Y HORARIOS
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
    [CreatedAt]           DATETIME2 (7)       NOT NULL,
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
-- 3. USUARIOS Y PACIENTES
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
    [CreatedAt]      DATETIME2 (7)       NOT NULL,
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
    [CreatedAt]           DATETIME2 (7)       NOT NULL,
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
-- 4. TURNOS Y ATENCIÓN
-- =========================================================================

CREATE TABLE [dbo].[Appointments] (
    [Id]                   INT IDENTITY (1, 1) NOT NULL,
    [PatientId]            INT                 NOT NULL,
    [ProfessionalId]       INT                 NOT NULL,
    [SpecialtyId]          INT                 NOT NULL,
    [AppointmentDate]      DATE                NOT NULL,
    [StartTime]            TIME (7)            NOT NULL,
    [EndTime]              TIME (7)            NOT NULL,
    [Status]               INT                 NOT NULL, -- 1= Pendiente, 2= Confirmado, 3= En espera, 4= Atentido, 5= Cancelado, 6= Ausente, 7= Reprogramado
    [CancellationReason]   NVARCHAR (250)      NULL,
    [Observations]         NVARCHAR (500)      NULL,
    [HasClinicalHistory]   BIT                 NOT NULL DEFAULT 0,
    [CreatedAt]            DATETIME2 (7)       NOT NULL,
    [CreatedBy]            NVARCHAR (50)       NULL,
    [LastUpdatedAt]        DATETIME2 (7)       NULL,
    [LastUpdatedBy]        NVARCHAR (50)       NULL,
    [IsDeleted]            BIT                 NOT NULL DEFAULT 0,
    [RowVersion]           ROWVERSION          NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Appointments_Patients]      FOREIGN KEY ([PatientId])      REFERENCES [dbo].[Patients] ([Id]),
    CONSTRAINT [FK_Appointments_Professionals] FOREIGN KEY ([ProfessionalId]) REFERENCES [dbo].[Professionals] ([Id]),
    CONSTRAINT [FK_Appointments_Specialties]   FOREIGN KEY ([SpecialtyId])    REFERENCES [dbo].[Specialties] ([Id])
);
GO

-- =========================================================================
-- 5. CAJA DIARIA Y COBROS
-- =========================================================================

CREATE TABLE [dbo].[CashSessions] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [UserId]              INT                 NOT NULL,
    [StationName]         NVARCHAR (50)       NOT NULL DEFAULT 'Recepción Principal',
    [OpeningDate]         DATETIME2 (7)       NOT NULL,
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
    [CreatedAt]     DATETIME2 (7)       NOT NULL,
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
    [CreatedAt]       DATETIME2 (7)       NOT NULL,
    [RowVersion]      ROWVERSION          NOT NULL,
    CONSTRAINT [PK_ConsultationPayments] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Payments_Appointments]   FOREIGN KEY ([AppointmentId])   REFERENCES [dbo].[Appointments] ([Id]),
    CONSTRAINT [FK_Payments_CashSessions]   FOREIGN KEY ([CashSessionId])   REFERENCES [dbo].[CashSessions] ([Id]),
    CONSTRAINT [FK_Payments_PaymentMethods] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethods] ([Id]),
    CONSTRAINT [FK_Payments_Users]          FOREIGN KEY ([UserId])          REFERENCES [dbo].[Users] ([Id])
);
GO