using CliniqaxSystem.Application.DTOs.Appointment;
using CliniqaxSystem.Application.DTOs.Cash;
using CliniqaxSystem.Application.DTOs.Patient;
using CliniqaxSystem.Application.Interfaces.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CliniqaxSystem.Infrastructure.Services
{
    public class DocumentService : IDocumentService
    {
        public DocumentService()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        /// <summary>
        /// Genera el recibo térmico de atención / copago para entregar al paciente (formato 80mm).
        /// </summary>
        public async Task<byte[]> GenerateConsultationReceiptPdfAsync(ConsultationReceiptDto receipt)
        {
            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.ContinuousSize(80f, Unit.Millimetre);
                        page.Margin(3, Unit.Millimetre);
                        page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Consolas));

                        page.Content().Column(col =>
                        {
                            // 1. Encabezado
                            col.Item().AlignCenter().Text(receipt.ClinicName.ToUpper()).FontSize(11).ExtraBold();
                            if (!string.IsNullOrWhiteSpace(receipt.ClinicCuit))
                                col.Item().AlignCenter().Text($"CUIT: {receipt.ClinicCuit}").FontSize(7.5f);
                            if (!string.IsNullOrWhiteSpace(receipt.ClinicAddress))
                                col.Item().AlignCenter().Text(receipt.ClinicAddress).FontSize(7.5f);
                            if (!string.IsNullOrWhiteSpace(receipt.ClinicPhone))
                                col.Item().AlignCenter().Text($"Tel: {receipt.ClinicPhone}").FontSize(7.5f);

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            // 2. Datos del Comprobante
                            col.Item().Text($"RECIBO N.°: {receipt.ReceiptNumber}").Bold();
                            col.Item().Text($"FECHA: {receipt.Date:dd/MM/yyyy HH:mm}");
                            col.Item().Text($"RECEPTOR/A: {receipt.CashierName}");

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            // 3. Datos del Paciente
                            col.Item().Text($"PACIENTE: {receipt.PatientName.ToUpper()}").Bold();
                            col.Item().Text($"DNI: {receipt.PatientDocument}");
                            col.Item().Text($"COBERTURA: {receipt.HealthInsuranceName ?? "Particular"}");
                            if (!string.IsNullOrWhiteSpace(receipt.AffiliateNumber))
                                col.Item().Text($"AFILIADO N.°: {receipt.AffiliateNumber}");

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            // 4. Detalle de Atención
                            col.Item().Text($"PROFESIONAL: {receipt.ProfessionalName}");
                            col.Item().Text($"ESPECIALIDAD: {receipt.SpecialtyName}");

                            col.Item().PaddingVertical(3);

                            // 5. Desglose de Importes
                            if (receipt.CopayAmount > 0)
                            {
                                col.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("Copago / Coseguro:");
                                    r.RelativeItem().AlignRight().Text(receipt.CopayAmount.ToString("C2"));
                                });
                            }

                            col.Item().PaddingTop(2).Row(r =>
                            {
                                r.RelativeItem().Text("TOTAL ABONADO:").FontSize(11).ExtraBold();
                                r.RelativeItem().AlignRight().Text(receipt.Amount.ToString("C2")).FontSize(11).ExtraBold();
                            });

                            col.Item().Row(r =>
                            {
                                r.RelativeItem().Text($"Medio de Pago: {receipt.PaymentMethodName}");
                                r.RelativeItem().AlignRight().Text(receipt.PaymentReceived > 0 ? $"Recibido: {receipt.PaymentReceived:C2}" : "");
                            });

                            if (receipt.PaymentChange > 0)
                            {
                                col.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("Su Vuelto:");
                                    r.RelativeItem().AlignRight().Text(receipt.PaymentChange.ToString("C2")).Bold();
                                });
                            }

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            // 6. Pie
                            if (!string.IsNullOrWhiteSpace(receipt.FooterMessage))
                                col.Item().AlignCenter().Text(receipt.FooterMessage).FontSize(7.5f).Italic();

                            col.Item().PaddingTop(3).AlignCenter().Text(". . . . . . . . . . . . . . . . . . . . .").FontColor(Colors.Grey.Lighten1);
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera un informe A4 con el listado de turnos programados en un período.
        /// </summary>
        public async Task<byte[]> GenerateAppointmentsReportPdfAsync(IEnumerable<AppointmentDto> appointments, string title)
        {
            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4.Landscape());
                        page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("CONSULTORIO MÉDICO").FontSize(16).Bold().FontColor(Colors.Blue.Medium);
                                col.Item().Text(title).FontSize(11).SemiBold();
                            });
                            row.RelativeItem().AlignRight().Column(col =>
                            {
                                col.Item().Text($"Emisión: {DateTime.Now:dd/MM/yyyy HH:mm}");
                                col.Item().Text($"Total de Turnos: {appointments.Count()}");
                            });
                        });

                        page.Content().PaddingVertical(15).Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(1.5f); // Fecha
                                cols.RelativeColumn(1.2f); // Horario
                                cols.RelativeColumn(3);    // Paciente
                                cols.RelativeColumn(1.5f); // DNI
                                cols.RelativeColumn(2.5f); // Profesional
                                cols.RelativeColumn(2);    // Especialidad
                                cols.RelativeColumn(1.5f); // Estado
                            });

                            table.Header(h =>
                            {
                                h.Cell().Element(HeaderStyle).Text("FECHA");
                                h.Cell().Element(HeaderStyle).Text("HORARIO");
                                h.Cell().Element(HeaderStyle).Text("PACIENTE");
                                h.Cell().Element(HeaderStyle).Text("DNI");
                                h.Cell().Element(HeaderStyle).Text("PROFESIONAL");
                                h.Cell().Element(HeaderStyle).Text("ESPECIALIDAD");
                                h.Cell().Element(HeaderStyle).Text("ESTADO");

                                static IContainer HeaderStyle(IContainer c) =>
                                    c.Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(4).DefaultTextStyle(x => x.Bold());
                            });

                            foreach (var a in appointments)
                            {
                                table.Cell().Element(CellStyle).AlignCenter().Text(a.AppointmentDate.ToString("dd/MM/yyyy"));
                                table.Cell().Element(CellStyle).AlignCenter().Text(a.TimeSlot);
                                table.Cell().Element(CellStyle).PaddingLeft(4).Text(a.PatientName);
                                table.Cell().Element(CellStyle).AlignCenter().Text(a.PatientDocument);
                                table.Cell().Element(CellStyle).PaddingLeft(4).Text(a.ProfessionalName);
                                table.Cell().Element(CellStyle).AlignCenter().Text(a.SpecialtyName);
                                table.Cell().Element(CellStyle).AlignCenter().Text(a.StatusName).Bold();

                                static IContainer CellStyle(IContainer c) => c.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera la nómina completa de pacientes registrados.
        /// </summary>
        public async Task<byte[]> GeneratePatientsListPdfAsync(IEnumerable<PatientDto> patients)
        {
            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(1.5f, Unit.Centimetre);
                        page.Size(PageSizes.A4);
                        page.DefaultTextStyle(x => x.FontSize(9).FontFamily(Fonts.Verdana));

                        page.Header().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text("PADRÓN GENERAL DE PACIENTES").FontSize(16).Bold().FontColor(Colors.Blue.Medium);
                                col.Item().Text($"Total Registrados: {patients.Count()}");
                            });
                            row.RelativeItem().AlignRight().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}");
                        });

                        page.Content().PaddingVertical(15).Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.RelativeColumn(1.8f); // DNI
                                cols.RelativeColumn(3.5f); // Apellido y Nombre
                                cols.RelativeColumn(1);    // Edad
                                cols.RelativeColumn(2);    // Teléfono
                                cols.RelativeColumn(2.5f); // Cobertura
                            });

                            table.Header(h =>
                            {
                                h.Cell().Element(HeaderStyle).Text("DNI");
                                h.Cell().Element(HeaderStyle).Text("PACIENTE");
                                h.Cell().Element(HeaderStyle).Text("EDAD");
                                h.Cell().Element(HeaderStyle).Text("TELÉFONO");
                                h.Cell().Element(HeaderStyle).Text("OBRA SOCIAL");

                                static IContainer HeaderStyle(IContainer c) =>
                                    c.Background(Colors.Grey.Lighten2).Border(0.5f).AlignCenter().Padding(4).DefaultTextStyle(x => x.Bold());
                            });

                            foreach (var p in patients)
                            {
                                table.Cell().Element(CellStyle).AlignCenter().Text(p.DocumentNumber);
                                table.Cell().Element(CellStyle).PaddingLeft(4).Text(p.FullName);
                                table.Cell().Element(CellStyle).AlignCenter().Text(p.Age.ToString());
                                table.Cell().Element(CellStyle).AlignCenter().Text(p.Phone);
                                table.Cell().Element(CellStyle).AlignCenter().Text(p.HealthInsuranceName ?? "Particular");

                                static IContainer CellStyle(IContainer c) => c.Border(0.5f).PaddingVertical(3);
                            }
                        });

                        page.Footer().AlignCenter().Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                    });
                }).GeneratePdf();
            });
        }

        /// <summary>
        /// Genera el ticket térmico de cierre o arqueo de caja (Z / X) adaptado a CashSession (Opción A).
        /// </summary>
        public async Task<byte[]> GenerateCashSessionTicketPdfAsync(CashSessionDto session, bool isZClose = true)
        {
            string ticketTitle = isZClose ? "CIERRE DEFINITIVO DE CAJA (Z)" : "CIERRE PARCIAL / ARQUEO (X)";

            return await Task.Run(() =>
            {
                return Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.ContinuousSize(80f, Unit.Millimetre);
                        page.Margin(3, Unit.Millimetre);
                        page.DefaultTextStyle(x => x.FontSize(8.5f).FontFamily(Fonts.Consolas));

                        page.Content().Column(col =>
                        {
                            col.Item().AlignCenter().Text("CONSULTORIO MÉDICO").FontSize(11).ExtraBold();
                            col.Item().AlignCenter().Text(ticketTitle).FontSize(9.5f).Bold();
                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            col.Item().Text($"RESPONSABLE: {session.UserName}");
                            col.Item().Text($"RECEPCIÓN: {session.StationName}");
                            col.Item().Text($"SESIÓN N.°: #{session.Id}");
                            col.Item().Text($"APERTURA: {session.OpeningDate:dd/MM/yyyy HH:mm}");
                            if (session.ClosingDate.HasValue)
                                col.Item().Text($"CIERRE:   {session.ClosingDate.Value:dd/MM/yyyy HH:mm}");

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            col.Item().AlignCenter().Text("--- INGRESOS POR MEDIO DE PAGO ---").FontSize(7.5f).Bold();
                            col.Item().Row(r => { r.RelativeItem().Text("• Efectivo:"); r.RelativeItem().AlignRight().Text(session.TotalCashIncome.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Débito:"); r.RelativeItem().AlignRight().Text(session.TotalDebitIncome.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Crédito:"); r.RelativeItem().AlignRight().Text(session.TotalCreditIncome.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• Transferencia:"); r.RelativeItem().AlignRight().Text(session.TotalTransferIncome.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("• QR / Digital:"); r.RelativeItem().AlignRight().Text(session.TotalQrIncome.ToString("C2")); });

                            col.Item().PaddingTop(2).Row(r =>
                            {
                                r.RelativeItem().Text("TOTAL COBRADO:").Bold();
                                r.RelativeItem().AlignRight().Text(session.TotalTurnover.ToString("C2")).Bold();
                            });

                            col.Item().PaddingVertical(2).LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                            col.Item().AlignCenter().Text("--- BALANCE EN GAVETA DE EFECTIVO ---").FontSize(7.5f).Bold();
                            col.Item().Row(r => { r.RelativeItem().Text("Fondo Inicial:"); r.RelativeItem().AlignRight().Text(session.InitialCash.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("(+) Cobros Efectivo:"); r.RelativeItem().AlignRight().Text(session.TotalCashIncome.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("(+) Ingresos Manuales:"); r.RelativeItem().AlignRight().Text(session.TotalManualCashIn.ToString("C2")); });
                            col.Item().Row(r => { r.RelativeItem().Text("(-) Egresos / Retiros:"); r.RelativeItem().AlignRight().Text($"-{session.TotalManualCashOut:C2}"); });

                            col.Item().PaddingTop(2).Row(r =>
                            {
                                r.RelativeItem().Text("EFECTIVO ESPERADO:").FontSize(9.5f).Bold();
                                r.RelativeItem().AlignRight().Text(session.CurrentSystemCash.ToString("C2")).FontSize(9.5f).Bold();
                            });

                            if (isZClose && session.RealCash.HasValue)
                            {
                                col.Item().Row(r =>
                                {
                                    r.RelativeItem().Text("EFECTIVO CONTADO:").FontSize(9.5f).Bold();
                                    r.RelativeItem().AlignRight().Text(session.RealCash.Value.ToString("C2")).FontSize(9.5f).Bold();
                                });

                                decimal diff = session.Difference ?? 0;
                                string diffText = diff == 0 ? "CAJA CUADRADA ($ 0.00)" : (diff > 0 ? $"SOBRANTE: +{diff:C2}" : $"FALTANTE: {diff:C2}");

                                col.Item().PaddingTop(2).Row(r =>
                                {
                                    r.RelativeItem().Text("DIFERENCIA:").Bold();
                                    r.RelativeItem().AlignRight().Text(diffText).Bold();
                                });
                            }

                            col.Item().PaddingTop(15).AlignCenter().Text("_________________________");
                            col.Item().AlignCenter().Text("Firma del Responsable").FontSize(7.5f).Italic();
                            col.Item().PaddingTop(4).AlignCenter().Text(". . . . . . . . . . . . . . . . . . . . .").FontColor(Colors.Grey.Lighten1);
                        });
                    });
                }).GeneratePdf();
            });
        }
    }
}
