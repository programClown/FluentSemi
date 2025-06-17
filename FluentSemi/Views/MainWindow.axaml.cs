using System;
using Ursa.Controls;

namespace FluentSemi.Views;

public partial class MainWindow : UrsaWindow
{
    private DateTime _lastShiftPressTime;

    public MainWindow()
    {
        InitializeComponent();
    }
}