using ClosedXML.Excel;
using ProductionAnalysisBackend.Repositories.Excel;

namespace ProductionAnalysisBackend.Services.Excel;

public class ProductionAnalysisExcelService : IProductionAnalysisExcelService
{
    private readonly IProductionAnalysisExcelRepository _repository;
    
    private static readonly List<string> TimeTemplate = new()
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

        var rowIndex = 8; // после заголовков

        foreach (var time in TimeTemplate)
        {
            ws.Cell(rowIndex, 1).Value = time;

            // ИТОГО — особая строка
            if (time == "ИТОГО")
            {
                ws.Cell(rowIndex, 2).Value = data.Rows.Sum(r => r.PlanQTY);
                ws.Cell(rowIndex, 4).Value = data.Rows.Sum(r => r.FactQTY);
                ws.Cell(rowIndex, 6).Value = data.Rows.Sum(r => r.Deviation);
                ws.Cell(rowIndex, 8).Value = data.Rows.Sum(r => r.DowntimeMinutes);

                ws.Range(rowIndex, 1, rowIndex, 13)
                    .Style.Font.SetBold();

                rowIndex++;
                continue;
            }

            // Перерывы / обед / уборка — серые строки без данных
            if (time.Contains("Перерыв") || time.Contains("Обед") || time.Contains("Уборка"))
            {
                ws.Range(rowIndex, 1, rowIndex, 13)
                    .Style.Fill.SetBackgroundColor(XLColor.LightGray);

                rowIndex++;
                continue;
            }

            // Пытаемся найти данные для интервала
            var rowData = data.Rows
                .ElementAtOrDefault(
                    TimeTemplate.IndexOf(time)
                );

            if (rowData != null)
            {
                ws.Cell(rowIndex, 2).Value = rowData.PlanQTY;
                ws.Cell(rowIndex, 3).Value = rowData.PlanCumulative;
                ws.Cell(rowIndex, 4).Value = rowData.FactQTY;
                ws.Cell(rowIndex, 5).Value = rowData.FactCumulative;
                ws.Cell(rowIndex, 6).Value = rowData.Deviation;
                ws.Cell(rowIndex, 7).Value = rowData.DeviationCumulative;
                ws.Cell(rowIndex, 8).Value = rowData.DowntimeMinutes;
                ws.Cell(rowIndex, 9).Value = rowData.ResponsibleUserName;
                ws.Cell(rowIndex,10).Value = rowData.ReasonGroupName;
                ws.Cell(rowIndex,11).Value = rowData.ReasonName;
                ws.Cell(rowIndex,12).Value = rowData.Comment;
                ws.Cell(rowIndex,13).Value = rowData.TakenMeasures;
            }

            rowIndex++;
        }

        ws.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        wb.SaveAs(stream);
        return stream.ToArray();
    }
}
