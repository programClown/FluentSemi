using Avalonia.Controls;
using FluentSemi.ViewModels;

namespace FluentSemi.Views;

public partial class MainView : UserControl
{
    public readonly MainViewModel ViewModel = new();

    public MainView()
    {
        InitializeComponent();
        DataContext = ViewModel;
    }
}