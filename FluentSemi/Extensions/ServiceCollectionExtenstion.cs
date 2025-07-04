using System;
using CommunityToolkit.Mvvm.Messaging;
using FluentSemi.Services;
using FluentSemi.Services.Impl;
using FluentSemi.ViewModels;
using FluentSemi.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FluentSemi.Extensions;

/// <summary>
///     依赖注入
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     注入通用服务
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        // 主窗口
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<MainView>();
        serviceCollection.AddSingleton<Lazy<MainWindow>>(provider =>
            new Lazy<MainWindow>(provider.GetRequiredService<MainWindow>));
        serviceCollection.AddSingleton<Lazy<MainView>>(provider =>
            new Lazy<MainView>(provider.GetRequiredService<MainView>));
        serviceCollection.AddSingleton<INavigationService, DefaultNavigationService>();
        serviceCollection.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
    }

    /// <summary>
    ///     注入 View Model
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViewModels(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<MainViewModel>();

        // page view model
        serviceCollection.AddTransient<HomeViewModel>();
        serviceCollection.AddTransient<AboutViewModel>();
    }

    /// <summary>
    ///     注入页面（Views）
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViews(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<HomeView>();
        serviceCollection.AddTransient<AboutView>();
    }
}