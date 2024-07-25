using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace ShutdownScheduler.Extensions;

public static class ApplicationExtensions
{
    public static Window? GetMainWindow()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime app)
        {
            return app.MainWindow;
        }

        return null;
    }
}