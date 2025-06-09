using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using Entities.Abstract;
using Entities;

namespace UI;

public partial class AddFunctionWindow : Window
{

    public AddFunctionWindow()
    {
        InitializeComponent();
        typeComboBox.SelectionChanged += OnTypeChanged;
    }

    private void OnTypeChanged(object sender, SelectionChangedEventArgs e)
    {
        paramC.IsVisible = typeComboBox.SelectedIndex == 1;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        if (!float.TryParse(paramA.Text, out float a) ||
            !float.TryParse(paramB.Text, out float b)) return;

        Function func = typeComboBox.SelectedIndex switch
        {
            0 => new Line { A = a, B = b },
            1 when float.TryParse(paramC.Text, out float c) => new Kub { A = a, B = b, C = c },
            2 => new Hyperbola { A = a, B = b },
            _ => null
        };

        if (func != null) ((App)App.Current).FunctionService.AddFunction(func);
        Close();
    }
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}   