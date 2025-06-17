using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FluentSemi.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private UserControl? _currentPage;
}