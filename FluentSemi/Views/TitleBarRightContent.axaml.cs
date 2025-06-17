using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace FluentSemi.Views;

public partial class TitleBarRightContent : UserControl
{
    public TitleBarRightContent()
    {
        InitializeComponent();
    }

    private async void OpenRepository(object? sender, RoutedEventArgs e)
    {
        var top = TopLevel.GetTopLevel(this);
        if (top is null) return;
        var launcher = top.Launcher;
        await launcher.LaunchUriAsync(new Uri("https://github.com/irihitech/Ursa.Avalonia"));
    }
}