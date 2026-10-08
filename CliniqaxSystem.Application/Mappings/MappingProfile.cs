using AutoMapper;
using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.DTOs.Cash;
using CliniqaxSystem.Application.DTOs.Catalog;
using CliniqaxSystem.Application.DTOs.Clinical.Attachment;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.Diagnosis;
using CliniqaxSystem.Application.DTOs.Clinical.Evolution;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalAttachment;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalInstruction;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.DTOs.Professional;
using CliniqaxSystem.Application.DTOs.User;
using CliniqaxSystem.Domain.Entities;
using CliniqaxSystem.Domain.Enums;

namespace CliniqaxSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ==========================================
            // 1. USUARIOS Y SESIÓN
            // ==========================================
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty))
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(src => src.Professional != null ? src.Professional.FullName : null));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Professional, opt => opt.Ignore())
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<User, UserSessionDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}".Trim()))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.Name : string.Empty))
                .ForMember(dest => dest.LoginTime, opt => opt.Ignore());

            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Professional, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<UserProfileUpdateDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.RoleId, opt => opt.Ignore())
                .ForMember(dest => dest.Username, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 2. ESPECIALIDADES Y OBRAS SOCIALES
            // ==========================================
            CreateMap<Specialty, SpecialtyDto>().ReverseMap()
                .ForMember(dest => dest.ProfessionalSpecialties, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<HealthInsurance, HealthInsuranceDto>().ReverseMap()
                .ForMember(dest => dest.Patients, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 3. PACIENTES
            // ==========================================
            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.HealthInsuranceName, opt => opt.MapFrom(src => src.HealthInsurance != null ? src.HealthInsurance.Name : "Particular"));

            CreateMap<PatientDto, Patient>()
                .ForMember(dest => dest.HealthInsurance, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<PatientCreateDto, Patient>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.HealthInsurance, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<PatientUpdateDto, Patient>()
                .ForMember(dest => dest.HealthInsurance, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 4. PROFESIONALES Y HORARIOS
            // ==========================================
            CreateMap<Professional, ProfessionalDto>()
                .ForMember(dest => dest.SpecialtyIds, opt => opt.MapFrom(src => src.ProfessionalSpecialties.Select(ps => ps.SpecialtyId).ToList()))
                .ForMember(dest => dest.SpecialtyNames, opt => opt.MapFrom(src => src.ProfessionalSpecialties.Select(ps => ps.Specialty.Name).ToList()))
                .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules));

            CreateMap<ProfessionalCreateDto, Professional>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(_ => true))
                .ForMember(dest => dest.ProfessionalSpecialties, opt => opt.Ignore())
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<ProfessionalUpdateDto, Professional>()
                .ForMember(dest => dest.ProfessionalSpecialties, opt => opt.Ignore())
                .ForMember(dest => dest.Schedules, opt => opt.Ignore())
                .ForMember(dest => dest.Appointments, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<ProfessionalSchedule, ProfessionalScheduleDto>().ReverseMap()
                .ForMember(dest => dest.Professional, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 5. TURNOS / CITAS
            // ==========================================
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.FullName : string.Empty))
                .ForMember(dest => dest.PatientDocument, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.DocumentNumber : string.Empty))
                .ForMember(dest => dest.PatientPhone, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.Phone : string.Empty))
                .ForMember(dest => dest.HealthInsuranceName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.HealthInsurance != null ? src.Patient.HealthInsurance.Name : "Particular"))
                .ForMember(dest => dest.AffiliateNumber, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.AffiliateNumber : null))
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(src => src.Professional != null ? src.Professional.FullName : string.Empty))
                .ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Specialty != null ? src.Specialty.Name : string.Empty));

            CreateMap<AppointmentCreateDto, Appointment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => AppointmentStatus.Pending))
                .ForMember(dest => dest.HasClinicalHistory, opt => opt.MapFrom(_ => false))
                .ForMember(dest => dest.CancellationReason, opt => opt.Ignore())
                .ForMember(dest => dest.Patient, opt => opt.Ignore())
                .ForMember(dest => dest.Professional, opt => opt.Ignore())
                .ForMember(dest => dest.Specialty, opt => opt.Ignore())
                .ForMember(dest => dest.Payments, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 6. CAJA DIARIA Y MOVIMIENTOS
            // ==========================================
            CreateMap<CashSession, CashSessionDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? $"{src.User.LastName} {src.User.FirstName}".Trim() : string.Empty));

            CreateMap<CashMovement, CashMovementDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : string.Empty));

            CreateMap<ConsultationPayment, ConsultationPaymentDto>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Appointment.Patient.FullName))
                .ForMember(dest => dest.PatientDocument, opt => opt.MapFrom(src => src.Appointment.Patient.DocumentNumber))
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(src => src.Appointment.Professional.FullName))
                .ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Appointment.Specialty.Name))
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Name));

            // ==========================================
            // 7. CONFIGURACIÓN DEL CONSULTORIO
            // ==========================================
            CreateMap<ClinicSettings, ClinicSettingsDto>().ReverseMap()
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==========================================
            // 8. GESTIÓN CLÍNICA Y EXPEDIENTE DIGITAL
            // ==========================================
            CreateMap<DiagnosisType, DiagnosisTypeDto>();
            CreateMap<ConsultationStatus, ConsultationStatusDto>();
            CreateMap<AttachmentCategory, AttachmentCategoryDto>();

            CreateMap<MedicalRecord, MedicalRecordDto>()
                .ForMember(dest => dest.PatientFullName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.PatientDocument, opt => opt.MapFrom(src => src.Patient.DocumentNumber))
                .ForMember(dest => dest.PatientHealthInsurance, opt => opt.MapFrom(src => src.Patient.HealthInsurance != null ? src.Patient.HealthInsurance.Name : "Particular"))
                .ForMember(dest => dest.PatientAffiliateNumber, opt => opt.MapFrom(src => src.Patient.AffiliateNumber))
                .ForMember(dest => dest.PatientAge, opt => opt.MapFrom(src => src.Patient.Age))
                .ForMember(dest => dest.Consultations, opt => opt.MapFrom(src => src.Consultations.OrderByDescending(c => c.ConsultationDate)))
                .ForMember(dest => dest.MedicalAttachments, opt => opt.MapFrom(src => src.MedicalAttachments.OrderByDescending(a => a.CreatedAt)));

            CreateMap<Consultation, ConsultationDto>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.MedicalRecord.PatientId))
                .ForMember(dest => dest.PatientFullName, opt => opt.MapFrom(src => src.MedicalRecord.Patient.FullName))
                .ForMember(dest => dest.PatientDocument, opt => opt.MapFrom(src => src.MedicalRecord.Patient.DocumentNumber))
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(src => src.Professional.FullName))
                .ForMember(dest => dest.ProfessionalLicense, opt => opt.MapFrom(src => src.Professional.LicenseNumber))
                .ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Specialty.Name))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.ConsultationStatus.Name));

            CreateMap<Consultation, ConsultationSummaryDto>()
                .ForMember(dest => dest.ProfessionalName, opt => opt.MapFrom(src => src.Professional.FullName))
                .ForMember(dest => dest.SpecialtyName, opt => opt.MapFrom(src => src.Specialty.Name))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.ConsultationStatus.Name))
                .ForMember(dest => dest.MainDiagnosis, opt => opt.MapFrom(src => src.ClinicalDiagnoses.FirstOrDefault() != null ? src.ClinicalDiagnoses.First().Description : "-"))
                .ForMember(dest => dest.AttachmentsCount, opt => opt.MapFrom(src => src.MedicalAttachments.Count));

            CreateMap<ClinicalEvolution, ClinicalEvolutionDto>();
            CreateMap<ClinicalDiagnosis, ClinicalDiagnosisDto>()
                .ForMember(dest => dest.DiagnosisTypeName, opt => opt.MapFrom(src => src.DiagnosisType.Name));

            CreateMap<MedicalInstruction, MedicalInstructionDto>();
            CreateMap<MedicalAttachment, MedicalAttachmentDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.AttachmentCategory != null ? src.AttachmentCategory.Name : "Sin Categoría"));
        }
    }
}
