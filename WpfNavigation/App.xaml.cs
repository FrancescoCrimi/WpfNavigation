// Copyright (c) 2024 Francesco Crimi francrim@gmail.com
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Windows;
using WpfNavigation.Pages;

namespace WpfNavigation;
public partial class App : Application
{
    public static NavigationService? NavigationService { get; private set; }

    public App()
    {
        var window = new MainWindow();
        window.Show();
        NavigationService = new NavigationService(window.ShellFrame);
        //NavigationService.Navigate(new Uri("/Pages/Page1.xaml", UriKind.Relative), "From App");
        NavigationService.Navigate(new Page1(), "From App");
    }
}
