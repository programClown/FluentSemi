using System;
using System.Diagnostics;

namespace FluentSemi.Util;

public class AppMethod
{
    public static void RestartApp(bool isAdmin = false)
    {
        var startInfo = new ProcessStartInfo
        {
            UseShellExecute = true,
            WorkingDirectory = Environment.CurrentDirectory,
            FileName = Process.GetCurrentProcess()?.MainModule?.FileName
        };
        if (isAdmin) startInfo.Verb = "runas";
        Process.Start(startInfo);
        Environment.Exit(0);
    }
}