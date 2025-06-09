using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using Avalonia.Controls;

namespace UI;

public partial class FindFuncWindow : Window
{

    public FindFuncWindow()
    {
        InitializeComponent();
    }

    private void Find_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(indexInput.Text, out var index) ||
            index < 0 || index >= ((App)App.Current).FunctionService.GetAllFunctions().Count ||
            !float.TryParse(xInput.Text, out var x))
        {
            resultText.Text = "Ошибка ввода! Проверьте индекс и значение X";
            return;
        }

        var func = ((App)App.Current).FunctionService.GetAllFunctions()[index];
        resultText.Text = $"{func}\nЗначение в точке {x}: {func.F(x):F2}";
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(indexInput.Text, out var index) ||
            index < 0 || index >= ((App)App.Current).FunctionService.GetAllFunctions().Count)
        {
            resultText.Text = "Некорректный индекс!";
            return;
        }

        ((App)App.Current).FunctionService.RemoveFunction(index);
        resultText.Text = $"Функция с индексом {index} удалена";
    }
    
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}