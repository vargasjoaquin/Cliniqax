using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class Professional : AuditableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string DocumentNumber { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!; //Numero de matrícula
        public string? Phone {  get; set; }
        public string? Email { get; set; }
        public int AppointmentDuration { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Observations { get; set; }

        public virtual ICollection<ProfessionalSpeciality> ProfessionalSpecialties { get; set; } = new List<ProfessionalSpeciality>();
        public virtual ICollection<ProfessionalSchedule> Schedules { get; set; } = new List<ProfessionalSchedule>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
