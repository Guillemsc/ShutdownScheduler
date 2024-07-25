using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;

namespace ShutdownScheduler.Extensions;

public static class WindowExtensions
{
    public static Task<TResult> ShowDialogAtCurrentWindow<TResult>(this Window window)
    {
        return window.ShowDialog<TResult>(ApplicationExtensions.GetMainWindow()!); 
    }
    
    public static Window GetWindow(this Visual visual)
    {
        Visual? parent = visual;

        while (parent != null)
        {
            if (parent is Window window)
            {
                return window;
            }

            parent = parent.GetVisualParent();
        }

        throw new Exception("Window could not be found");
    }
}