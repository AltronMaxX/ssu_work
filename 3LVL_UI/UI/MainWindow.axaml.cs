using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
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
        var window = new PrintAllWindow();
        window.Show();
        window.Closed += OnClosing;
    }

    private void AddFunction_Click(object sender, RoutedEventArgs e)
    {
        var window = new AddFunctionWindow();
        window.Show();
        window.Closed += OnClosing;
    }

    private void FindFunction_Click(object sender, RoutedEventArgs e)
    {
        var window = new FindFuncWindow();
        window.Show();
        window.Closed += OnClosing;
    }

    private void OnClosing(object? sender, EventArgs e)
    {
        Activate();
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}