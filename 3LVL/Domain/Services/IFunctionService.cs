using Entities.Abstract;

namespace Domain.Services;

public interface IFunctionService
{
    List<Function> GetAllFunctions();
    void AddFunction(Function function);
    Function GetFunctionById(int Id);
    void RemoveFunction(int Id);
}