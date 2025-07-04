using System;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentSemi.Models;
using FluentSemi.Util;

namespace FluentSemi.ViewModels;

/// <summary>
///     菜单项 view model
/// </summary>
public partial class MenuItemViewModel(MenuItemModel menu) : ViewModelBase
{
    /// <summary>
    ///     菜单是否激活
    /// </summary>
    [ObservableProperty] private bool _isActive;

    /// <summary>
    ///     菜单标题
    /// </summary>
    public string Title { get; set; } = menu.Title;

    /// <summary>
    ///     菜单图标
    /// </summary>
    public IconName Icon { get; set; } = menu.Icon;

    /// <summary>
    ///     菜单对应的页面类型
    /// </summary>
    public Type ViewType { get; } = menu.ViewType;
}