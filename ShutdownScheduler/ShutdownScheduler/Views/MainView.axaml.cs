using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ShutdownScheduler.Extensions;
using ShutdownScheduler.Managers;
using ShutdownScheduler.ViewModels;

namespace ShutdownScheduler.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    
    public void ScheduleButtonClick(object? sender, RoutedEventArgs routedEventArgs)
    {
        ShowPopup();
    }
    
    public void AbortButtonClick(object? sender, RoutedEventArgs routedEventArgs)
    {
        ScheduleManager.Instance.AbortShutdown();
    }
    
    async void ShowPopup()
    {
        ScheduleShutdownView view = new ScheduleShutdownView
        {
            DataContext = new ScheduleShutdownViewModel()
        };

        ModalWindow modal = new()
        {
            Content = view,
            Title = "Schedule",
            CanResize = false,
        };

        TimeSpan? result = await modal.ShowDialogAtCurrentWindow<TimeSpan?>();

        if (!result.HasValue)
        {
            return;
        }
        
        ScheduleManager.Instance.ScheduleShutdown(result.Value);
    }
}