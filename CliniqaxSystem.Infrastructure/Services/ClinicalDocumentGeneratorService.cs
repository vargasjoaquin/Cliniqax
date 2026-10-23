using CliniqaxSystem.Application.DTOs.AdminAndDashboard;
using CliniqaxSystem.Application.DTOs.Clinical.Consultation;
using CliniqaxSystem.Application.DTOs.Clinical.MedicalRecord;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QColor = QuestPDF.Infrastructure.Color;
using WColor = DocumentFormat.OpenXml.Wordprocessing.Color;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class ClinicalDocumentGeneratorService
    {
        private const string HexPrimary = "1E3A8A";       // Azul oscuro institucional
        private const string HexLightCyan = "E0F2FE";     // Celeste fondo de casilleros
        private const string HexBorder = "BFDBFE";        // Celeste bordes suaves
        private const string HexDangerBg = "FEE2E2";      // Fondo suave alerta alergias
        private const string HexDangerText = "DC2626";    // Rojo texto alerta alergias

        private static readonly QColor QColorPrimary = QColor.FromHex($"#{HexPrimary}");
        private static readonly QColor QColorLightCyan = QColor.FromHex($"#{HexLightCyan}");
        private static readonly QColor QColorBorder = QColor.FromHex($"#{HexBorder}");
        private static readonly QColor QColorDanger = QColor.FromHex($"#{HexDangerText}");

        public ClinicalDocumentGeneratorService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        // =========================================================================
        // 1. GENERACIÓN OFICIAL EN PDF
        // =========================================================================
        public byte[] GenerateOfficialMedicalRecordPdf(MedicalRecordDto? record, ClinicSettingsDto settings, ConsultationDto? specificConsultation = null)
        {
            record ??= new MedicalRecordDto
            {
                RecordNumber = "HC-00000000",
                PatientFullName = "Paciente",
                PatientDocument = "---",
                PatientHealthInsurance = "Particular",
                Consultations = new List<ConsultationSummaryDto>()
            };

            byte[] effectiveLogo = ResolveLogoBytes(settings);
            var latestSummary = record.Consultations?.FirstOrDefault();

            string reasonForConsultation = specificConsultation?.ReasonForConsultation
                ?? latestSummary?.ReasonForConsultation
                ?? "Evaluación clínica general";

            string physicalExam = specificConsultation?.PhysicalExamination
                ?? "Signos vitales normales. Examen clínico regional sin particularidades.";

            string mainDiagnosis = specificConsultation?.Diagnoses?.FirstOrDefault()?.Description
                ?? latestSummary?.MainDiagnosis
                ?? "En estudio";

            string statusName = specificConsultation?.StatusName
                ?? latestSummary?.StatusName
                ?? "Finalizada";

            string professionalName = specificConsultation?.ProfessionalName
                ?? latestSummary?.ProfessionalName
                ?? "Profesional de la Salud";

            string professionalLicense = specificConsultation?.ProfessionalLicense
                ?? string.Empty;

            return QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1.2f, Unit.Centimetre);
                    page.Size(PageSizes.A4);
                    //page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Verdana));

                    // Encabezado
                    page.Header().Column(col =>
                    {
                        col.Item().Row(row =>
                        {
                            if (effectiveLogo.Length > 0)
                            {
                                row.ConstantItem(85).Height(45).Image(effectiveLogo).FitArea();
                            }

                            row.RelativeItem().PaddingLeft(10).Column(c =>
                            {
                                c.Item().Text(settings.ClinicName.ToUpper()).FontSize(14).ExtraBold().FontColor(QColorPrimary);
                                c.Item().Text("HISTORIA CLÍNICA").FontSize(16).Bold().FontColor(QColorPrimary);
                                if (!string.IsNullOrWhiteSpace(settings.Address))
                                    c.Item().Text(settings.Address).FontSize(7.5f).FontColor(Colors.Grey.Darken1);
                            });

                            row.ConstantItem(170).Background(QColorLightCyan).Border(1).BorderColor(QColorBorder).Padding(6).Column(meta =>
                            {
                                meta.Item().Row(r => { r.RelativeItem().Text("Fecha:").Bold().FontSize(8); r.RelativeItem().AlignRight().Text(DateTime.Now.ToString("dd/MM/yyyy")).FontSize(8); });
                                meta.Item().Row(r => { r.RelativeItem().Text("Hora:").Bold().FontSize(8); r.RelativeItem().AlignRight().Text(DateTime.Now.ToString("HH:mm")).FontSize(8); });
                                meta.Item().Row(r => { r.RelativeItem().Text("N.° Historia:").Bold().FontSize(8); r.RelativeItem().AlignRight().Text(record.RecordNumber ?? "HC-00000000").Bold().FontSize(8).FontColor(QColorPrimary); });
                            });
                        });

                        col.Item().PaddingVertical(6);
                    });

                    // Cuerpo
                    page.Content().Column(col =>
                    {
                        // 1. Identificación
                        col.Item().Element(CardContainer).Column(card =>
                        {
                            card.Item().Element(CardHeader).Text("DATOS DE IDENTIFICACIÓN").FontSize(9).ExtraBold().FontColor(Colors.White);

                            card.Item().Padding(8).Column(inner =>
                            {
                                inner.Item().Row(r =>
                                {
                                    r.RelativeItem(3).Element(PillBox).Text($"Nombres y Apellidos: {record.PatientFullName ?? "-"}").Bold();
                                    r.RelativeItem(1.5f).PaddingLeft(4).Element(PillBox).Text($"DNI: {record.PatientDocument ?? "-"}").Bold();
                                    r.RelativeItem(1).PaddingLeft(4).Element(PillBox).Text($"Edad: {record.PatientAge} años");
                                });

                                inner.Item().PaddingTop(4).Row(r =>
                                {
                                    r.RelativeItem().Element(PillBox).Text($"Teléfono: {record.PatientHealthInsurance ?? "Particular"}");
                                    r.RelativeItem().PaddingLeft(4).Element(PillBox).Text($"Cobertura: {record.PatientHealthInsurance ?? "Particular"}");
                                    r.RelativeItem().PaddingLeft(4).Element(PillBox).Text($"Afiliado N.°: {record.PatientAffiliateNumber ?? "-"}");
                                });
                            });
                        });

                        col.Item().PaddingVertical(4);

                        // 2. Antecedentes
                        col.Item().Element(CardContainer).Column(card =>
                        {
                            card.Item().Element(CardHeader).Text("ANTECEDENTES CLÍNICOS Y FACTORES DE RIESGO").FontSize(9).ExtraBold().FontColor(Colors.White);

                            card.Item().Padding(8).Column(inner =>
                            {
                                inner.Item().Row(r =>
                                {
                                    r.RelativeItem(1.5f).Element(PillBox).Text($"Grupo Sanguíneo: {record.BloodType ?? "No especificado"}").Bold();
                                    r.RelativeItem(3.5f).PaddingLeft(4).Border(1).BorderColor(QColorDanger).Background(Colors.Red.Lighten5).Padding(4).Text($"⚠️ ALERGIAS: {record.Allergies ?? "Sin alergias conocidas"}").Bold().FontColor(QColorDanger);
                                });

                                inner.Item().PaddingTop(4).Row(r =>
                                {
                                    r.RelativeItem().Element(PillBox).Text($"Patológicos: {record.PathologicalHistory ?? "Sin antecedentes"}");
                                    r.RelativeItem().PaddingLeft(4).Element(PillBox).Text($"Quirúrgicos: {record.SurgicalHistory ?? "Sin antecedentes"}");
                                });

                                inner.Item().PaddingTop(4).Row(r =>
                                {
                                    r.RelativeItem().Element(PillBox).Text($"Hábitos: {record.NonPathologicalHistory ?? "Sin antecedentes"}");
                                    r.RelativeItem().PaddingLeft(4).Element(PillBox).Text($"Familiares: {record.FamilyHistory ?? "Sin antecedentes"}");
                                });
                            });
                        });

                        col.Item().PaddingVertical(4);

                        // 3. Motivo y Examen
                        col.Item().Element(CardContainer).Column(card =>
                        {
                            card.Item().Element(CardHeader).Text("MOTIVO DE CONSULTA Y ENFERMEDAD ACTUAL").FontSize(9).ExtraBold().FontColor(Colors.White);

                            card.Item().Padding(8).Column(inner =>
                            {
                                inner.Item().Element(PillBox).Text($"Motivo de Consulta: {reasonForConsultation}").Bold();
                                inner.Item().PaddingTop(4).Text("Evolución y Examen Físico:").Bold().FontSize(8);
                                inner.Item().Background(QColorLightCyan).Border(0.5f).BorderColor(QColorBorder).Padding(6).Text(physicalExam).FontSize(8);
                            });
                        });

                        col.Item().PaddingVertical(4);

                        // 4. Diagnóstico y Tratamiento
                        col.Item().Element(CardContainer).Column(card =>
                        {
                            card.Item().Element(CardHeader).Text("JUICIO DIAGNÓSTICO E INDICACIONES TERAPÉUTICAS").FontSize(9).ExtraBold().FontColor(Colors.White);

                            card.Item().Padding(8).Column(inner =>
                            {
                                inner.Item().Row(r =>
                                {
                                    r.RelativeItem(2).Element(PillBox).Text($"Diagnóstico: {mainDiagnosis}").Bold();
                                    r.RelativeItem(1).PaddingLeft(4).Element(PillBox).Text($"Estado: {statusName}");
                                });

                                inner.Item().PaddingTop(4).Text("Indicaciones Médicas y Tratamiento:").Bold().FontSize(8);
                                inner.Item().Border(0.5f).BorderColor(QColorBorder).Padding(6).Text(
                                    "1. Cumplir con la medicación prescripta en los horarios y dosis pautadas.\n" +
                                    "2. Pautas de alarma inmediatas ante exacerbación de síntomas.\n" +
                                    "3. Control evolutivo según programación médica."
                                ).FontSize(8);
                            });
                        });

                        // 5. Firma
                        col.Item().PaddingTop(20).Row(r =>
                        {
                            r.RelativeItem().Column(c =>
                            {
                                c.Item().Text("Documento confidencial para uso médico exclusivo.").FontSize(7).Italic();
                                c.Item().Text("Sistema de Gestión Clínica Cliniqax").FontSize(7).FontColor(Colors.Grey.Medium);
                            });

                            r.ConstantItem(220).Column(c =>
                            {
                                c.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Darken1);
                                c.Item().PaddingTop(2).AlignCenter().Text("Firma y Sello del Profesional").FontSize(8).Bold();
                                c.Item().AlignCenter().Text($"Dr/a. {professionalName}").FontSize(7.5f);
                                if (!string.IsNullOrWhiteSpace(professionalLicense))
                                {
                                    c.Item().AlignCenter().Text($"Matrícula: {professionalLicense}").FontSize(7);
                                }
                            });
                        });
                    });

                    // Footer
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Documento médico confidencial generado por Cliniqax — Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            }).GeneratePdf();

            static IContainer CardContainer(IContainer c) => c.Border(1).BorderColor(QColorBorder).Background(Colors.White);
            static IContainer CardHeader(IContainer c) => c.Background(QColorPrimary).PaddingVertical(3).PaddingHorizontal(8);
            static IContainer PillBox(IContainer c) => c.Background(QColorLightCyan).Border(0.5f).BorderColor(QColorBorder).Padding(4);
        }

        // =========================================================================
        // 2. GENERACIÓN DE PLANTILLA VACÍA
        // =========================================================================
        public byte[] GenerateBlankTemplateDocx(ClinicSettingsDto settings, MedicalRecordDto? patientRecord = null)
        {
            using var memoryStream = new MemoryStream();

            using (var wordDoc = WordprocessingDocument.Create(memoryStream, WordprocessingDocumentType.Document, true))
            {
                var mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                var body = new Body();

                // Encabezado
                var headerTable = CreateWordHeaderTable(
                    clinicName: settings.ClinicName.ToUpper(),
                    address: settings.Address ?? string.Empty,
                    dateText: "Fecha: [   /   /      ]",
                    timeText: "Hora: [   :   hs]",
                    hcText: $"N.° Historia: [ {patientRecord?.RecordNumber ?? "                    "} ]"
                );
                body.Append(headerTable);
                body.Append(CreateEmptySpacing());

                // 1. Datos de identificación
                var idTable = CreateWordCardSection(
                    sectionTitle: "DATOS DE IDENTIFICACIÓN",
                    rows: new List<string[]>
                    {
                        new[] {
                            $"Nombres y Apellidos: {patientRecord?.PatientFullName ?? ""}",
                            $"DNI: {patientRecord?.PatientDocument ?? ""}",
                            $"Edad: {(patientRecord != null ? patientRecord.PatientAge.ToString() + " años" : "     años")}"
                        },
                        new[] {
                            "Teléfono: ",
                            $"Cobertura: {patientRecord?.PatientHealthInsurance ?? ""}",
                            $"Afiliado N.°: {patientRecord?.PatientAffiliateNumber ?? ""}"
                        },
                        new[] {
                            "Fecha y Lugar de Nacimiento: ",
                            "Sexo: [ F / M / X ]",
                            "Contacto de Emergencia: "
                        }
                    }
                );
                body.Append(idTable);
                body.Append(CreateEmptySpacing());

                // 2. Antecedentes Clínicos 
                var antTable = CreateWordCardSection(
                    sectionTitle: "ANTECEDENTES CLÍNICOS Y FACTORES DE RIESGO",
                    rows: new List<string[]>
                    {
                        new[] {
                            "Grupo Sanguíneo: [       ]",
                            "⚠️ ALERGIAS CONOCIDAS: [                                                                                ]"
                        },
                        new[] {
                            "Patológicos (Enfermedades crónicas): ",
                            "Quirúrgicos / Traumatológicos: "
                        },
                        new[] {
                            "Hábitos / No Patológicos (Tabaquismo, alcohol): ",
                            "Antecedentes Heredo-Familiares: "
                        }
                    }
                );
                body.Append(antTable);
                body.Append(CreateEmptySpacing());

                // 3. Motivo de consulta
                var consultTable = CreateWordCardSection(
                    sectionTitle: "MOTIVO DE CONSULTA Y ENFERMEDAD ACTUAL",
                    rows: new List<string[]>
                    {
                        new[] { "Motivo de Consulta: [ Describa aquí el motivo principal de la consulta médica... ]\n" },
                        new[] { "Evolución y Examen Físico (Signos vitales: TA, FC, Temp, Peso, Talla, Examen regional):\n\n\n\n" }
                    }
                );
                body.Append(consultTable);
                body.Append(CreateEmptySpacing());

                // 4. Diagnostico y Tratamiento
                var diagTable = CreateWordCardSection(
                    sectionTitle: "JUICIO DIAGNÓSTICO E INDICACIONES TERAPÉUTICAS",
                    rows: new List<string[]>
                    {
                        new[] {
                            "Diagnóstico Principal (CIE-10 / Texto): [                                                                  ]",
                            "Estado: [ Presuntivo / Definitivo ]"
                        },
                        new[] {
                            "Indicaciones Médicas y Tratamiento:\n" +
                            "1. Cumplir con la medicación prescripta en los horarios y dosis pautadas.\n" +
                            "2. Pautas de alarma inmediatas ante exacerbación de síntomas.\n" +
                            "3. Control evolutivo según programación médica.\n\n"
                        }
                    }
                );
                body.Append(diagTable);
                body.Append(CreateEmptySpacing());

                var footerTable = CreateWordFooterTable();
                body.Append(footerTable);

                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }

            return memoryStream.ToArray();
        }


        private static Table CreateWordHeaderTable(string clinicName, string address, string dateText, string timeText, string hcText)
        {
            var table = new Table();
            var tblPr = new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new BottomBorder { Val = BorderValues.Single, Size = 12, Color = HexPrimary },
                    new InsideHorizontalBorder { Val = BorderValues.None },
                    new InsideVerticalBorder { Val = BorderValues.None }
                )
            );
            table.Append(tblPr);

            var row = new TableRow();

            // Columna Izquierda: Logo textual y títulos
            var cellLeft = new TableCell(
                new TableCellProperties(new TableCellWidth { Width = "3400", Type = TableWidthUnitValues.Pct }),
                new Paragraph(
                    new ParagraphProperties(new SpacingBetweenLines { After = "40" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "26" }, new WColor { Val = HexPrimary }), new Text(clinicName))
                ),
                new Paragraph(
                    new ParagraphProperties(new SpacingBetweenLines { After = "30" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "30" }, new WColor { Val = HexPrimary }), new Text("HISTORIA CLÍNICA"))
                ),
                new Paragraph(
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new FontSize { Val = "15" }, new WColor { Val = "64748B" }), new Text(address))
                )
            );

            // Columna Derecha: Tarjeta Celeste de Metadatos (Fecha, Hora, N° HC)
            var cellRight = new TableCell(
                new TableCellProperties(
                    new TableCellWidth { Width = "1600", Type = TableWidthUnitValues.Pct },
                    new Shading { Val = ShadingPatternValues.Clear, Fill = HexLightCyan },
                    new TableCellBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                        new BottomBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                        new LeftBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                        new RightBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder }
                    )
                ),
                new Paragraph(new ParagraphProperties(new SpacingBetweenLines { Before = "30", After = "30" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "16" }), new Text(dateText))),
                new Paragraph(new ParagraphProperties(new SpacingBetweenLines { After = "30" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "16" }), new Text(timeText))),
                new Paragraph(new ParagraphProperties(new SpacingBetweenLines { After = "30" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "16" }, new WColor { Val = HexPrimary }), new Text(hcText)))
            );

            row.Append(cellLeft);
            row.Append(cellRight);
            table.Append(row);

            return table;
        }

        private static Table CreateWordCardSection(string sectionTitle, List<string[]> rows)
        {
            var table = new Table();
            var tblPr = new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                    new BottomBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                    new LeftBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                    new RightBorder { Val = BorderValues.Single, Size = 6, Color = HexBorder },
                    new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4, Color = HexBorder },
                    new InsideVerticalBorder { Val = BorderValues.Single, Size = 4, Color = HexBorder }
                )
            );
            table.Append(tblPr);

            // 1. Barra de Encabezado Azul de la Tarjeta (Igual que en el PDF)
            var headerRow = new TableRow();
            var headerCell = new TableCell(
                new TableCellProperties(
                    new GridSpan { Val = 3 },
                    new Shading { Val = ShadingPatternValues.Clear, Fill = HexPrimary }
                ),
                new Paragraph(
                    new ParagraphProperties(new SpacingBetweenLines { Before = "60", After = "60" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "17" }, new WColor { Val = "FFFFFF" }), new Text(sectionTitle))
                )
            );
            headerRow.Append(headerCell);
            table.Append(headerRow);

            // 2. Filas de Casilleros Interiores (PillBoxes en Word)
            foreach (var cols in rows)
            {
                var r = new TableRow();

                foreach (var text in cols)
                {
                    bool isAllergies = text.Contains("⚠️ ALERGIAS");
                    string fillHex = isAllergies ? HexDangerBg : HexLightCyan;
                    string textHex = isAllergies ? HexDangerText : "0F172A";

                    var c = new TableCell(
                        new TableCellProperties(
                            cols.Length == 1 ? new GridSpan { Val = 3 } : (cols.Length == 2 ? new GridSpan { Val = 1 } : new TableCellProperties()),
                            new Shading { Val = ShadingPatternValues.Clear, Fill = fillHex }
                        ),
                        new Paragraph(
                            new ParagraphProperties(new SpacingBetweenLines { Before = "40", After = "40" }),
                            new Run(new RunProperties(
                                new RunFonts { Ascii = "Verdana" },
                                new FontSize { Val = "16" },
                                new WColor { Val = textHex },
                                (isAllergies || text.Contains(":")) ? new Bold() : new RunProperties()),
                                new Text(text)
                            )
                        )
                    );
                    r.Append(c);
                }
                table.Append(r);
            }

            return table;
        }

        private static Table CreateWordFooterTable()
        {
            var table = new Table();
            var tblPr = new TableProperties(
                new TableWidth { Width = "5000", Type = TableWidthUnitValues.Pct },
                new TableBorders(
                    new TopBorder { Val = BorderValues.None },
                    new BottomBorder { Val = BorderValues.None },
                    new LeftBorder { Val = BorderValues.None },
                    new RightBorder { Val = BorderValues.None },
                    new InsideHorizontalBorder { Val = BorderValues.None },
                    new InsideVerticalBorder { Val = BorderValues.None }
                )
            );
            table.Append(tblPr);

            var row = new TableRow();

            // Derecha: Firma y Sello
            var cellRight = new TableCell(
                new TableCellProperties(new TableCellWidth { Width = "2000", Type = TableWidthUnitValues.Pct }),
                new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center }, new SpacingBetweenLines { Before = "250" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }), new Text("_________________________________________"))
                ),
                new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center }, new SpacingBetweenLines { After = "30" }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new Bold(), new FontSize { Val = "16" }), new Text("Firma y Sello del Profesional"))
                ),
                new Paragraph(
                    new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
                    new Run(new RunProperties(new RunFonts { Ascii = "Verdana" }, new FontSize { Val = "15" }, new WColor { Val = "64748B" }), new Text("Dr/a. _______________________ | Mat: ________"))
                )
            );

            row.Append(cellRight);
            table.Append(row);

            return table;
        }

        private static Paragraph CreateEmptySpacing()
        {
            return new Paragraph(new ParagraphProperties(new SpacingBetweenLines { Before = "60", After = "60" }));
        }

        private static byte[] ResolveLogoBytes(ClinicSettingsDto settings)
        {
            if (settings.Logo != null && settings.Logo.Length > 0)
                return settings.Logo;

            try
            {
                string defaultLogoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo_cliniqax.png");
                
                if (File.Exists(defaultLogoPath))
                    return File.ReadAllBytes(defaultLogoPath);

                string devPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Icons", "logo_cliniqax.png");
                
                if (File.Exists(devPath))
                    return File.ReadAllBytes(devPath);
            }
            catch 
            {
            }

            return Array.Empty<byte>();
        }
    }
}