using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqaxSystem.Application.DTOs.Clinical
{
    public class ParsedClinicalDocumentDto
    {
        public string? ExtractedDocumentNumber { get; set; }
        public string? ExtractedPatientName { get; set; }
        public DateTime? ExtractedDate { get; set; }
        public string? ReasonForConsultation { get; set; }
        public string? PhysicalExamination { get; set; }
        public string? DiagnosesSummary { get; set; }
        public string? InstructionsSummary { get; set; }
        public string RawExtractedText { get; set; } = string.Empty;
        public bool IsCliniqaxTemplate { get; set; }
    }
}
