using ProductionAnalysisBackend.Dto.Supervizor;

namespace ProductionAnalysisBackend.Services.Supervizor;

public interface ISupervizorService
{
    public Task<Result<string>> CreateShiftAsync(ShiftCreateDto shiftCreateDto);
}