using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Platform;
using Ursa.Controls;

namespace FluentSemi.Util.Ui;

public class Setter
{
    public static void SetAccentColor(Color color)
    {
        try
        {
            Application.Current.Resources["SystemAccentColor"] = color;
            Application.Current.Resources["ButtonDefaultPrimaryForeground"] = color;
            Application.Current.Resources["TextBoxFocusBorderBrush"] = color;
            Application.Current.Resources["ComboBoxSelectorPressedBorderBrush"] = color;
            Application.Current.Resources["ComboBoxSelectorFocusBorderBrush"] = color;
            Application.Current.Resources["TextBoxSelectionBackground"] = color;
            Application.Current.Resources["ProgressBarPrimaryForeground"] = color;
            Application.Current.Resources["ProgressBarIndicatorBrush"] = color;
            Application.Current.Resources["SliderThumbBorderBrush"] = color;
            Application.Current.Resources["SliderTrackForeground"] = color;
            Application.Current.Resources["HyperlinkButtonOverForeground"] = color;
            Application.Current.Resources["SliderThumbPressedBorderBrush"] = color;
            Application.Current.Resources["SliderThumbPointeroverBorderBrush"] = color;
            Application.Current.Resources["SystemAccentColorLight1"] = Calculator.ColorVariant(color, 0.15f);
            Application.Current.Resources["SystemAccentColorLight2"] = Calculator.ColorVariant(color, 0.30f);
            Application.Current.Resources["SystemAccentColorLight3"] = Calculator.ColorVariant(color, 0.45f);
            Application.Current.Resources["SystemAccentColorDark1"] = Calculator.ColorVariant(color, -0.15f);
            Application.Current.Resources["SystemAccentColorDark2"] = Calculator.ColorVariant(color, -0.30f);
            Application.Current.Resources["SystemAccentColorDark3"] = Calculator.ColorVariant(color, -0.45f);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void UpdateWindowStyle(UrsaWindow window, Action? action = null)
    {
        if (window == null) return;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ||
            RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD) ||
            (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
             Environment.OSVersion.Version.Major < 10))
        {
            window.IsManagedResizerVisible = true;
            window.SystemDecorations = SystemDecorations.None;
        }

        // window.FindControl<TitleBar>("TitleBar").IsVisible = true;
        window.FindControl<Border>("Root").CornerRadius = new CornerRadius(8);
        // window.WindowState = WindowState.Maximized;
        // window.WindowState = WindowState.Normal;
        window.ExtendClientAreaChromeHints = ExtendClientAreaChromeHints.NoChrome;
        window.ExtendClientAreaToDecorationsHint = true;
        action?.Invoke();
    }
}