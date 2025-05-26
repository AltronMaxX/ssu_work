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

    private void ShowAllFunctions_Click(object sender, RoutedEventArgs e)
    {
        new PrintAllWindow().Show();
    }

    private void AddFunction_Click(object sender, RoutedEventArgs e)
    {
        new AddFunctionWindow().Show();
    }

    private void FindFunction_Click(object sender, RoutedEventArgs e)
    {
        new FindFuncWindow().Show();
    }
}