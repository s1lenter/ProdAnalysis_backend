using ClosedXML.Excel;
using ProductionAnalysisBackend.Repositories.Excel;

namespace ProductionAnalysisBackend.Services.Excel;

public class ProductionAnalysisExcelService : IProductionAnalysisExcelService
{
    private readonly IProductionAnalysisExcelRepository _repository;
    
    private static readonly List<string> DayTemplate = new()
    {
        "08:00 - 09:00",
        "09:00 - 10:00",
        "Перерыв 15 мин",
        "10:15 - 11:15",
        "11:15 - 12:15",
        "Обед 30 мин",
        "12:45 - 13:45",
        "13:45 - 14:45",
        "Перерыв 15 мин",
        "15:00 - 16:00",
        "16:00 - 17:00",
        "Уборка 15 мин",
        "ИТОГО"
    };


    public ProductionAnalysisExcelService(AppDbContext context)
    {
        _repository = new ProductionAnalysisExcelRepository(context);
    }

    public async Task<byte[]> GenerateExcel(int analysisId)
    {
        var data = await _repository.GetAnalysisForExcel(analysisId);

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Производственный анализ");

        // ===== ШАПКА =====
        ws.Cell(1, 1).Value = "Производственный анализ";
        ws.Range(1, 1, 1, 10).Merge().Style.Font.SetBold().Font.FontSize = 16;

        ws.Cell(3, 1).Value = "Наименование продукции:";
        ws.Cell(3, 3).Value = data.ProductName;

        ws.Cell(4, 1).Value = "Подразделение:";
        ws.Cell(4, 3).Value = data.DepartmentName;

        ws.Cell(5, 1).Value = "ФИО заполняющего:";
        ws.Cell(5, 3).Value = data.FilledBy;

        ws.Cell(3, 6).Value = "Дата/смена:";
        ws.Cell(3, 8).Value = data.ShiftInfo;

        ws.Cell(4, 6).Value = "Мощность, шт/час:";
        ws.Cell(4, 8).Value = data.PowerPerHour;

        ws.Cell(5, 6).Value = "Суточный темп:";
        ws.Cell(5, 8).Value = data.DailyTarget;

        // ===== ЗАГОЛОВКИ ТАБЛИЦЫ =====
        var row = 7;
        string[] headers =
        {
            "Время",
            "План",
            "План накопит.",
            "Факт",
            "Факт накопит.",
            "Отклонение",
            "Отклонение накопит.",
            "Простой, мин",
            "Ответственный",
            "Группа причин",
            "Причина",
            "Комментарий",
            "Принятые меры"
        };

        var excelRow = 8;
        var dataIndex = 0; // 👈 индекс по данным из БД

        foreach (var slot in DayTemplate)
        {
            ws.Cell(excelRow, 1).Value = slot;

            // ===== ИТОГО =====
            if (slot == "ИТОГО")
            {
                ws.Cell(excelRow, 2).Value = data.Rows.Sum(r => r.PlanQTY);
                ws.Cell(excelRow, 4).Value = data.Rows.Sum(r => r.FactQTY);
                ws.Cell(excelRow, 6).Value = data.Rows.Sum(r => r.Deviation);
                ws.Cell(excelRow, 8).Value = data.Rows.Sum(r => r.DowntimeMinutes);

                ws.Range(excelRow, 1, excelRow, 13)
                    .Style.Font.SetBold();

                excelRow++;
                break;
            }

            // ===== ПЕРЕРЫВ / ОБЕД / УБОРКА =====
            if (slot.Contains("Перерыв") || slot.Contains("Обед") || slot.Contains("Уборка"))
            {
                ws.Range(excelRow, 1, excelRow, 13)
                    .Style.Fill.SetBackgroundColor(XLColor.LightGray);

                excelRow++;
                continue;
            }

            // ===== РАБОЧИЙ ЧАС =====
            if (dataIndex < data.Rows.Count)
            {
                var rowData = data.Rows[dataIndex];

                ws.Cell(excelRow, 2).Value = rowData.PlanQTY;
                ws.Cell(excelRow, 3).Value = rowData.PlanCumulative;
                ws.Cell(excelRow, 4).Value = rowData.FactQTY;
                ws.Cell(excelRow, 5).Value = rowData.FactCumulative;
                ws.Cell(excelRow, 6).Value = rowData.Deviation;
                ws.Cell(excelRow, 7).Value = rowData.DeviationCumulative;
                ws.Cell(excelRow, 8).Value = rowData.DowntimeMinutes;
                ws.Cell(excelRow, 9).Value = rowData.ResponsibleUserName;
                ws.Cell(excelRow,10).Value = rowData.ReasonGroupName;
                ws.Cell(excelRow,11).Value = rowData.ReasonName;
                ws.Cell(excelRow,12).Value = rowData.Comment;
                ws.Cell(excelRow,13).Value = rowData.TakenMeasures;

                dataIndex++; // 🔥 СДВИГАЕМСЯ ТОЛЬКО НА РАБОЧИХ СТРОКАХ
            }

            excelRow++;
        }

        ws.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        wb.SaveAs(stream);
        return stream.ToArray();
    }
}
