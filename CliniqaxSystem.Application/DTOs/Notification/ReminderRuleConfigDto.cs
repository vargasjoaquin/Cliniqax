namespace CliniqaxSystem.Application.DTOs.Notification
{
    public class ReminderRuleConfigDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AdvanceHours { get; set; }
        public int ChannelId { get; set; }
        public string ChannelName { get; set; } = null!;
        public int TemplateId { get; set; }
        public string TemplateName { get; set; } = null!;
        public bool IsEnabled { get; set; }
    }
}
