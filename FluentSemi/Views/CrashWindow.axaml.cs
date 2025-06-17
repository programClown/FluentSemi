using System;
using FluentSemi.Util;
using FluentSemi.Util.Ui;
using Ursa.Controls;

namespace FluentSemi.Views;

public partial class CrashWindow : UrsaWindow
{
    public CrashWindow(string exception)
    {
        InitializeComponent();
        Setter.UpdateWindowStyle(this);

        Info.Text = exception;
        Copy.Click += async (_, _) =>
        {
            var clipboard = GetTopLevel(this)?.Clipboard;
            await clipboard!.SetTextAsync(exception);
        };
        Continue.Click += (_, _) => { Close(); };
        Restart.Click += (_, _) => { AppMethod.RestartApp(); };
        Exit.Click += (_, _) => { Environment.Exit(0); };
        Topmost = true;
        Loaded += (_, _) => { Setter.UpdateWindowStyle(this); };
        Show();
        Activate();
    }

    public CrashWindow()
    {
    }

    public sealed override void Show()
    {
        base.Show();
    }
}