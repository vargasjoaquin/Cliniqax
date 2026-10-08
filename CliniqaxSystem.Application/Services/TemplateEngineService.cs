using CliniqaxSystem.Application.Interfaces.Services;
using System.Text.RegularExpressions;

namespace CliniqaxSystem.Application.Services
{
    public class TemplateEngineService : ITemplateEngineService
    {
        public string Render(string template, IDictionary<string, string> values)
        {
            if (string.IsNullOrWhiteSpace(template) || values == null || !values.Any())
                return template ?? string.Empty;

            // Reemplazo seguro de tokens con formato {Clave}
            return Regex.Replace(template, @"\{(\w+)\}", match =>
            {
                string key = match.Groups[1].Value;
                return values.TryGetValue(key, out var val) ? (val ?? string.Empty) : match.Value;
            });
        }
    }
}
