using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ShutdownScheduler.Extensions;

namespace ShutdownScheduler.Views;

public partial class ScheduleShutdownView : UserControl
{
    public ScheduleShutdownView()
    {
        InitializeComponent();
    }
    
    void OnSetClicked(object sender, RoutedEventArgs e)
    {
        int hours = (int)HoursNumericUpDown.Value!;
        int minutes = (int)MinutesNumericUpDown.Value!;

        TimeSpan timeSpan = new TimeSpan(0, hours, minutes, 0);
        
        Window window = this.GetWindow();
        window.Close(timeSpan);
    }
}