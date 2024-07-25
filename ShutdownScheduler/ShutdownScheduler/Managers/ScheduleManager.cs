using System;
using System.Diagnostics;

namespace ShutdownScheduler.Managers;

public sealed class ScheduleManager
{
    public static readonly ScheduleManager Instance = new();
    
    ScheduleManager()
    {
    }

    public void ScheduleShutdown(TimeSpan timeSpan)
    {
        int seconds = (int)timeSpan.TotalSeconds;
        
        Process.Start("Shutdown", $"-s -t {seconds}");
    }

    public void AbortShutdown()
    {
        Process.Start("Shutdown", $"-a");
    }
}