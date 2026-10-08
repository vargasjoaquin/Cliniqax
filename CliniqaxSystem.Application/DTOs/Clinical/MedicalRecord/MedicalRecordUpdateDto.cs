namespace CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord
{
    public class MedicalRecordUpdateDto
    {
        public int PatientId { get; set; }
        public string? BloodType { get; set; }
        public string? Allergies { get; set; }
        public string? PathologicalHistory { get; set; }
        public string? NonPathologicalHistory { get; set; }
        public string? SurgicalHistory { get; set; }
        public string? FamilyHistory { get; set; }
        public string? GeneralObservations { get; set; }
    }
}
