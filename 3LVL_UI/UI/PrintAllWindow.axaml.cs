using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

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
        for (int i = 0; i < all.Count; i++)
        {
            stringBuilder.AppendLine($"{i}: {all[i].ToString()}");
        }

        return stringBuilder.ToString();
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}