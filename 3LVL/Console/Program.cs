using Data;
using Domain.Services;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var repo = new FunctionRepository();
        var service = new FunctionService(repo);
        var app = new ConsoleApp(service);
        app.Run();
    }
}