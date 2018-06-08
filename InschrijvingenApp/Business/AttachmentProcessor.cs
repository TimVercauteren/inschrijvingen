using InschrijvingPietieterken.Models;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Drawing;

namespace InschrijvingPietieterken.Business
{
    public class AttachmentProcessor : IAttachmentProcessor
    {

        public byte[] GetExcel(List<ChildPrintModel> inschrijvingen, string key)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(key);
                worksheet.Cells["A1"].Value = "Achternaam";
                worksheet.Cells["B1"].Value = "Voornaam";
                worksheet.Cells["C1"].Value = "E-Mailadres";
                worksheet.Cells["D1"].Value = "Telefoon";
                worksheet.Cells["E1"].Value = "Postcode";
                worksheet.Cells["F1"].Value = "Gemeente";
                worksheet.Cells["G1"].Value = "Geboortedatum";
                worksheet.Cells["H1"].Value = "Dag/Maand";
                worksheet.Cells["I1"].Value = "Betaald?";

                using (var range = worksheet.Cells[1, 1, 1, 9])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                    range.Style.Font.Color.SetColor(Color.White);
                }

                worksheet.Cells["A2"].LoadFromCollection(inschrijvingen);

                return package.GetAsByteArray();
            }
        }
    }
}
