using Domain.Services;
using Entities;
using Entities.Abstract;

namespace ConsoleApp;

public class ConsoleApp
{
    private readonly IFunctionService _service;

    public ConsoleApp(IFunctionService service)
    {
        _service = service;
    }

    public void Run()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("=-=-=-=Меню=-=-=-=");
            Console.WriteLine("1. Вывести все функции");
            Console.WriteLine("2. Добавить функцию");
            Console.WriteLine("3. Найти функцию по Id");
            Console.WriteLine("4. Выйти");

            switch(Console.ReadLine())
            {
                case "1":
                    ShowAllFunction();
                    break;
                case "2":
                    AddFunction();
                    break;
                case "3":
                    FindFunction();
                    break;
                case "4":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Неверная опция. Попробуйте снова!");
                    break;
            }
        }
    }

    private void ShowAllFunction()
    {
        Console.Clear();
        Console.WriteLine("Все существующие функции");
        var all = _service.GetAllFunctions();
        foreach(var func in all)
        {
            Console.WriteLine(func);
        }
        Console.WriteLine("Функция добавлена! Нажмите ENTER для продолжения.");
        Console.ReadLine();
        Console.Clear();
    }

    private void AddFunction()
    {
        Function toAdd;
        Console.Clear();
        Console.WriteLine("Выберите функцию, которую хотите добавить");
        Console.WriteLine("1. Кубическая");
        Console.WriteLine("2. Линейная");
        Console.WriteLine("3. Гипербола");

        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("Введите данные в формате \'A B C\'");
                var input = Console.ReadLine().Split(" ");
                toAdd = new Kub(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                break;
            case "2":
                Console.WriteLine("Введите данные в формате \'A B\'");
                input = Console.ReadLine().Split(" ");
                toAdd = new Line(int.Parse(input[0]), int.Parse(input[1]));
                break;
            case "3":
                Console.WriteLine("Введите данные в формате \'A B\'");
                input = Console.ReadLine().Split(" ");
                toAdd = new Hyperbola(int.Parse(input[0]), int.Parse(input[1]));
                break;
            default:
                Console.WriteLine("Неверная функция! Нажмите ENTER для возврата в главное меню.");
                Console.ReadLine();
                Console.Clear();
                return;
        }

        _service.AddFunction(toAdd);
        Console.WriteLine("Функция добавлена! Нажмите ENTER для продолжения.");
        Console.ReadLine();
        Console.Clear();
    }

    private void FindFunction()
    {
        Console.Clear();
        Console.WriteLine("Введите Id функции");
        int id;
        string line = Console.ReadLine();
        while (!int.TryParse(line, out id))
        {
            Console.WriteLine("Неверно введён Id!");
            Console.WriteLine("Введите Id функции");
            line = Console.ReadLine();
        }

        Function func;

        try {
            func = _service.GetFunctionById(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Нажмите ENTER для продолжения!");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        Console.WriteLine("Функция успешно найдена!");
        Console.WriteLine("Выберите что вы хотите сделать:");
        Console.WriteLine("1. Найти значение функции для x");
        Console.WriteLine("2. Удалить функцию");
        Console.WriteLine("3. Вернуться в главное меню");

        while (true)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Введите x");
                    int x;
                    string l = Console.ReadLine();
                    while (!int.TryParse(l, out x))
                    {
                        Console.WriteLine("Неверно введён x!");
                        Console.WriteLine("Введите x");
                        l = Console.ReadLine();
                    }
                    Console.WriteLine(func.PrintInfo(x));
                    Console.WriteLine("Нажмите ENTER для продолжения!");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                case "2":
                    _service.RemoveFunction(id);
                    Console.WriteLine("Функция успешно удалена!");
                    Console.WriteLine("Нажмите ENTER для продолжения!");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                case "3":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Выбрана неверная опция!");
                    break;
            }
        }
    }
}