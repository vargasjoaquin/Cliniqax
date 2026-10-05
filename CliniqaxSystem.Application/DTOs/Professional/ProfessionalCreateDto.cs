    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliniqaxSystem.Application.DTOs.Professional
{
    public class ProfessionalCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int AppointmentDuration { get; set; }
        public string? Observations { get; set; }
        public List<int> SpecialtyIds { get; set; } = new();
        public List<ProfessionalScheduleDto> Schedules { get; set; } = new();
    }
}
