// Copyright (c) 2024 Francesco Crimi francrim@gmail.com
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfNavigation.Pages;
public partial class Page1 : Page, INavigationAware
{
    public Page1()
    {
        InitializeComponent();
        HashCodeTextBlock.Text = GetHashCode().ToString();
        Debug.Print("Costructor Page1 {0}", GetHashCode().ToString());
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        GoBackButton.IsEnabled = NavigationService.CanGoBack;
        GoForwardButton.IsEnabled = NavigationService.CanGoForward;
    }

    private void Page_Unloaded(object sender, RoutedEventArgs e)
    {
    }

    public void OnNavigatedTo(object parameter)
    {
        ShareText.Text = parameter?.ToString();
    }

    public void OnNavigatedFrom()
    {
    }

    #region button

    private void GoBackButton_Click(object sender, RoutedEventArgs e)
    {
        if (NavigationService.CanGoBack)
        {
            NavigationService.GoBack();
        }
    }

    private void GoForwardButton_Click(object sender, RoutedEventArgs e)
    {
        if (NavigationService.CanGoForward)
        {
            NavigationService.GoForward();
        }
    }

    private void GoPage3_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page3.xaml", UriKind.Relative), "From Page1");
    }

    private void GoPage2_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page2.xaml", UriKind.Relative), "From Page1");
    }

    #endregion

    ~Page1() => Debug.Print("Finalizer Page1 {0}", GetHashCode().ToString());
}
