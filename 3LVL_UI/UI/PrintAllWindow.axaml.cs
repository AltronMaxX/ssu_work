using System.Text;
using Avalonia.Controls;

namespace UI;

public partial class PrintAllWindow : Window
{
    public PrintAllWindow()
    {
        InitializeComponent();

        FunctionsOutput.Text = BuildOutput();
    }

    private string BuildOutput()
    {
        var all = ((App)App.Current).FunctionService.GetAllFunctions();
        StringBuilder stringBuilder = new();
        foreach(var func in all)
        {
            stringBuilder.AppendLine(func.ToString());
        }

        return stringBuilder.ToString();
    }
}