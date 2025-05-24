using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Domain.Services;
using Data;

namespace UI;

public partial class App : Application
{
    public IFunctionService? FunctionService;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        var repo = new FunctionRepository();
        FunctionService = new FunctionService(repo);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
}