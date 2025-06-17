using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using FluentAvalonia.UI.Controls;
using FluentSemi.ViewModels;

namespace FluentSemi.Views;

public partial class MainView : UserControl
{
    public readonly MainViewModel ViewModel = new();

    public MainView()
    {
        InitializeComponent();
        DataContext = ViewModel;

        Nav.SelectionChanged += (_, e) =>
        {
            // ViewModel.TogglePage(((e.SelectedItem as NavigationViewItem).Tag as string)!);
            App.Notification.Show(((e.SelectedItem as NavigationViewItem).Tag as string)!, NotificationType.Success);
        };
    }

    public NavigationView NavigationView => Nav;
    public ContentControl Frame => FrameView;
}