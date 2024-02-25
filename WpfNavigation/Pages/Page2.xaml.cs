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
public partial class Page2 : Page, INavigationAware
{
    public Page2()
    {
        InitializeComponent();
        HashCodeTextBlock.Text = GetHashCode().ToString();
        Debug.Print("Costructor Page2 {0}", GetHashCode().ToString());
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
        if (parameter != null)
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

    private void GoPage1_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page1.xaml", UriKind.Relative), "From Page2");
    }

    private void GoPage3_Click(object sender, RoutedEventArgs e)
    {
        App.NavigationService?.Navigate(new Uri("/Pages/Page3.xaml", UriKind.Relative), "From Page2");
    }

    #endregion

    ~Page2() => Debug.Print("Finalizer Page2 {0}", GetHashCode().ToString());
}
