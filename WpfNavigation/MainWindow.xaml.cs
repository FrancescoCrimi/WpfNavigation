// Copyright (c) 2024 Francesco Crimi francrim@gmail.com
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Windows;
using WpfNavigation.Pages;

namespace WpfNavigation;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
        => Close();

    private void NavigatePage1_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page1.xaml", UriKind.Relative), "From Menu");
        //App.NavigationService?.Navigate(new Page1(), "From Menu");
    }

    private void NavigatePage2_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page2.xaml", UriKind.Relative), "From Menu");
        //App.NavigationService?.Navigate(new Page2(), "From Menu");
    }

    private void NavigatePage3_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page3.xaml", UriKind.Relative), "From Menu");
        //App.NavigationService?.Navigate(new Page3(), "From Menu");
    }

    private void UpdatePage1_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.UpdateView(new Uri("/Pages/Page1.xaml", UriKind.Relative), "From Menu");
        //App.NavigationService?.UpdateView(new Page1(), "From Menu");
    }

    private void UpdatePage2_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.UpdateView(new Uri("/Pages/Page2.xaml", UriKind.Relative), "From Menu");
        //App.NavigationService?.UpdateView(new Page2(), "From Menu");
    }

    private void UpdatePage3_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.UpdateView(new Uri("/Pages/Page3.xaml", UriKind.Relative), "From Menu");
        //App.NavigationService?.UpdateView(new Page3(), "From Menu");
    }

    private void Collect_Click(object sender, RoutedEventArgs e)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
