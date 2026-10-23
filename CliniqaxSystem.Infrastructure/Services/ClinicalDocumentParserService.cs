using CliniqaxSystem.Application.DTOs.Clinical;
using CliniqaxSystem.Application.Interfaces.Services;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class ClinicalDocumentParserService : IClinicalDocumentParserService
    {
        public async Task<ParsedClinicalDocumentDto> ParseDocumentAsync(byte[] fileBytes, string fileName)
        {
            return await Task.Run(() =>
            {
                string rawText = ExtractRawText(fileBytes, fileName);
                var result = new ParsedClinicalDocumentDto { RawExtractedText = rawText };

                if (string.IsNullOrWhiteSpace(rawText))
                    return result;

                // Detectar si es una plantilla nativa de Cliniqax
                result.IsCliniqaxTemplate = rawText.Contains("CLINIQAX - PLANTILLA OFICIAL DE HISTORIA CLÍNICA")
                                         || rawText.Contains("[SECCIÓN: ANAMNESIS]");

                var dniMatch = Regex.Match(rawText, @"(?:DNI|Documento|DOC|D\.N\.I\.)\s*[:#]?\s*(\d{7,8})", RegexOptions.IgnoreCase);
                if (dniMatch.Success)
                    result.ExtractedDocumentNumber = dniMatch.Groups[1].Value.Trim();
                else
                {
                    var pureDniMatch = Regex.Match(rawText, @"\b(\d{7,8})\b");
                    if (pureDniMatch.Success)
                        result.ExtractedDocumentNumber = pureDniMatch.Groups[1].Value.Trim();
                }

                // 2. Extraer Motivo de Consulta
                var reasonMatch = Regex.Match(rawText, @"(?:Motivo|Razón|Consulta por|Anamnesis)\s*[:]\s*(.*?)(?=(?:Examen|Diagnóstico|Evolución|Indicaciones|\r|\n|$))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                
                if (reasonMatch.Success)
                    result.ReasonForConsultation = CleanSectionText(reasonMatch.Groups[1].Value);

                // 3. Extraer Examen Físico
                var examMatch = Regex.Match(rawText, @"(?:Examen Físico|Signos Vitales|Examen regional)\s*[:]\s*(.*?)(?=(?:Diagnóstico|Evolución|Indicaciones|\r|\n|$))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                
                if (examMatch.Success)
                    result.PhysicalExamination = CleanSectionText(examMatch.Groups[1].Value);

                // 4. Extraer Diagnósticos
                var diagMatch = Regex.Match(rawText, @"(?:Diagnóstico|Diagnósticos|Dx|Juicio clínico)\s*[:]\s*(.*?)(?=(?:Indicaciones|Tratamiento|Plan|\r|\n|$))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                
                if (diagMatch.Success)
                    result.DiagnosesSummary = CleanSectionText(diagMatch.Groups[1].Value);

                // 5. Extraer Indicaciones / Tratamiento
                var instMatch = Regex.Match(rawText, @"(?:Indicaciones|Tratamiento|Prescripción|Plan de cuidado|Rp)\s*[:]\s*(.*?)(?=(?:Firma|Próximo control|$))", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                
                if (instMatch.Success)
                    result.InstructionsSummary = CleanSectionText(instMatch.Groups[1].Value);

                return result;
            });
        }

        private static string ExtractRawText(byte[] fileBytes, string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLowerInvariant();

            if (ext == ".pdf")
            {
                try
                {
                    var sb = new StringBuilder();
                    using var ms = new MemoryStream(fileBytes);
                    using var document = PdfDocument.Open(ms);

                    foreach (var page in document.GetPages())
                    {
                        sb.AppendLine(page.Text);
                    }
                    return sb.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }

            return Encoding.UTF8.GetString(fileBytes);
        }

        private static string CleanSectionText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) 
                return string.Empty;
            
            return text.Replace("\r", " ").Replace("\n", " ").Trim();
        }
    }
}