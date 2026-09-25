using CliniqaxSystem.Domain.Common;

namespace CliniqaxSystem.Domain.Entities
{
    public class Patient : AuditableEntity
    {
        public string DocumentNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}".Trim();
        public DateTime BirthDate { get; set; }
        public string Phone {  get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }

        public int? HealthInsuranceId { get; set; }
        public virtual HealthInsurance? HealthInsurance { get; set; }

        public string? AffiliateNumber { get; set; } // N° de carnet/afiliado
        public string? AdministrativeNotes { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public int Age
        {
            get
            {
                var today = DateTime.Today;

                int age = today.Year - BirthDate.Year;

                if (BirthDate.Date > today.AddDays(-age))
                {
                    age--;
                }

                return Math.Max(0, age);
            }
        }
    }
}
