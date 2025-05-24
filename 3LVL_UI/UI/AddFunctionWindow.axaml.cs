using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using Entities;

namespace UI;

public partial class AddFunctionWindow : Window
{
    public AddFunctionWindow()
    {
        InitializeComponent();

    }

    private void Kub_OnClick(object? sender, RoutedEventArgs e)
    {
        if (float.TryParse(Kub_A.Text, out float a) && float.TryParse(Kub_B.Text, out float b) && float.TryParse(Kub_C.Text, out float c))
        {
            var func = new Kub(a, b, c);
            ((App)App.Current).FunctionService.AddFunction(func);
        }        
    }

    private void Line_OnClick(object? sender, RoutedEventArgs e)
    {
        if (float.TryParse(Line_A.Text, out float a) && float.TryParse(Line_B.Text, out float b))
        {
            var func = new Line(a, b);
            ((App)App.Current).FunctionService.AddFunction(func);
        }
    }

    private void Hyperbola_OnClick(object? sender, RoutedEventArgs e)
    {
        if (float.TryParse(Hyperbola_A.Text, out float a) && float.TryParse(Hyperbola_B.Text, out float b))
        {
            var func = new Hyperbola(a, b);
            ((App)App.Current).FunctionService.AddFunction(func);
        }
    }
}   