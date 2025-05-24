using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;

namespace UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void PrintAll_OnClick(object? sender, RoutedEventArgs e)
    {
        var printAll = new PrintAllWindow();
        printAll.Show();
    }

    private void AddFunction_OnClick(object? sender, RoutedEventArgs e)
    {
        var window = new AddFunctionWindow();
        window.Show();
    }

    private void FindFunction_OnClick(object? sender, RoutedEventArgs e)
    {
        Debug.WriteLine("Click!");
    }
}