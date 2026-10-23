namespace CliniqaxSystem.Application.Interfaces.Services
{
    public interface ITemplateEngineService
    {
        string Render(string template, IDictionary<string, string> values);
    }
}
