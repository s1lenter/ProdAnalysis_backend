using ClosedXML.Excel;
using ProductionAnalysisBackend.Repositories.Excel;

namespace ProductionAnalysisBackend.Services.Excel;

public class ProductionAnalysisExcelService : IProductionAnalysisExcelService
{
    private readonly IProductionAnalysisExcelRepository _repository;

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

        for (int i = 0; i < headers.Length; i++)
        {
            ws.Cell(row, i + 1).Value = headers[i];
            ws.Cell(row, i + 1).Style.Font.SetBold();
        }

        // ===== ДАННЫЕ =====
        row++;
        foreach (var r in data.Rows)
        {
            ws.Cell(row, 1).Value = r.WorkInterval;
            ws.Cell(row, 2).Value = r.PlanQTY;
            ws.Cell(row, 3).Value = r.PlanCumulative;
            ws.Cell(row, 4).Value = r.FactQTY;
            ws.Cell(row, 5).Value = r.FactCumulative;
            ws.Cell(row, 6).Value = r.Deviation;
            ws.Cell(row, 7).Value = r.DeviationCumulative;
            ws.Cell(row, 8).Value = r.DowntimeMinutes;
            ws.Cell(row, 9).Value = r.ResponsibleUserName;
            ws.Cell(row,10).Value = r.ReasonGroupName;
            ws.Cell(row,11).Value = r.ReasonName;
            ws.Cell(row,12).Value = r.Comment;
            ws.Cell(row,13).Value = r.TakenMeasures;
            row++;
        }

        ws.Columns().AdjustToContents();

        using var stream = new MemoryStream();
        wb.SaveAs(stream);
        return stream.ToArray();
    }
}
