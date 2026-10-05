using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.DTOs.Cash;
using CliniqaxSystem.Application.DTOs.Patient;

namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<byte[]> GenerateConsultationReceiptPdfAsync(ConsultationReceiptDto receipt);
        Task<byte[]> GenerateAppointmentsReportPdfAsync(IEnumerable<AppointmentDto> appointments, string title);
        Task<byte[]> GeneratePatientsListPdfAsync(IEnumerable<PatientDto> patients);
        Task<byte[]> GenerateCashSessionTicketPdfAsync(CashSessionDto cashSession, bool isZClose = true);
    }
}
