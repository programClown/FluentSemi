using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FluentSemi.Models;
using FluentSemi.Services;
using FluentSemi.Services.Impl;
using FluentSemi.Util;

namespace FluentSemi.ViewModels;

public partial class MainViewModel : RecipientViewModelBase, IRecipient<CurrentPageChangedMessage>
{
    private readonly INavigationService _navigationService;
    
    /// <summary>
    ///     当前选中的菜单项
    /// </summary>
    [ObservableProperty] private MenuItemViewModel? _currentMenu;

    /// <summary>
    ///     当前页面对应的视图模型
    /// </summary>
    [ObservableProperty] private ViewModelBase? _currentPage;
    
    /// <summary>
    ///     当前是否全屏
    /// </summary>
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MainWindowPadding))]
    private bool _isMaximized;

    /// <summary>
    ///     侧边栏导航区域展开状态
    /// </summary>
    [ObservableProperty] private bool _isSidebarOpened = true;

    public MainViewModel( INavigationService navigationService)
    {
        _navigationService = navigationService;
        _navigationService.NavigateTo(typeof(HomeViewModel));
    }
    
    /// <summary>
    ///     主窗口内边距
    /// </summary>
    public Thickness MainWindowPadding => IsMaximized ? new Thickness(8) : new Thickness(0);

    /// <summary>
    ///     系统设置图标名称
    /// </summary>
    public static IconName SettingsButtonIcon => IconName.SettingsRounded;

    /// <summary>
    ///     菜单折叠图标名称
    /// </summary>
    public static IconName SidebarToggleButtonIcon => IconName.MenuRounded;

    /// <summary>
    ///     菜单列表
    /// </summary>
    public ObservableCollection<MenuItemViewModel> Menus { get; } =
    [
        new(new MenuItemModel { Title = "主页", Icon = IconName.Home, ViewType = typeof(HomeViewModel) })
            { IsActive = true },
        new(new MenuItemModel { Title = "关于", Icon = IconName.InfoRounded, ViewType = typeof(AboutViewModel) })
    ];
    
    /// <inheritdoc />
    public void Receive(CurrentPageChangedMessage message)
    {
        CurrentPage = message.Value;
    }
    
    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarOpened = !IsSidebarOpened;
    }
    
    [RelayCommand]
    private void Navigate(MenuItemViewModel? clickMenu)
    {
        if (clickMenu is null || clickMenu.IsActive) return;

        clickMenu.IsActive = true;
        CurrentMenu = clickMenu;

        foreach (var menuItemViewModel in Menus)
        {
            if (menuItemViewModel == clickMenu) continue;

            menuItemViewModel.IsActive = false;
        }

        _navigationService.NavigateTo(clickMenu.ViewType);
    }
}