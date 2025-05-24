using Data;
using Entities.Abstract;

namespace Domain.Services;

public class FunctionService : IFunctionService
{

    private readonly FunctionRepository _repo;

    public FunctionService(FunctionRepository repo)
    {
        _repo = repo;
    }

    public void AddFunction(Function function)
    {
        var functions = _repo.GetAll();
        functions.Add(function);
        _repo.SaveAll(functions);
    }

    public List<Function> GetAllFunctions()
    {
        return _repo.GetAll();
    }

    public Function GetFunctionById(int Id)
    {
        return _repo.GetById(Id);
    }

    public void RemoveFunction(int Id)
    {
        _repo.RemoveById(Id);
    }
}