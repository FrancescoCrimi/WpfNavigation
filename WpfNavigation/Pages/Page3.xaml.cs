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
public partial class Page3 : Page, INavigationAware, IDisposable
{
    private bool disposedValue;

    public Page3()
    {
        InitializeComponent();
        HashCodeTextBlock.Text = GetHashCode().ToString();
        Debug.Print("Costructor Page3 {0}", GetHashCode().ToString());
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

    private void GoPage2_Click(object sender, RoutedEventArgs e)
    {
        //App.NavigationService?.Navigate(new Uri("/Pages/Page2.xaml", UriKind.Relative), "From Page3");
        App.NavigationService?.Navigate(new Page2(), "From Page3");
    }

    private void GoPage1_Click(object sender, RoutedEventArgs e)
    {
        //App.NavigationService?.Navigate(new Uri("/Pages/Page1.xaml", UriKind.Relative), "From Page3");
        App.NavigationService?.Navigate(new Page1(), "From Page3");
    }

    #endregion


    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: eliminare lo stato gestito (oggetti gestiti)
            }

            // TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del finalizzatore
            // TODO: impostare campi di grandi dimensioni su Null
            disposedValue = true;
        }
    }
     
    // TODO: eseguire l'override del finalizzatore solo se 'Dispose(bool disposing)' contiene codice per liberare risorse non gestite
    ~Page3()
    {
        Dispose(disposing: false);
        // Non modificare questo codice. Inserire il codice di pulizia nel metodo 'Dispose(bool disposing)'
        Debug.Print("Finalizer Page3 {0}", GetHashCode().ToString());
    }

    public void Dispose()
    {
        // Non modificare questo codice. Inserire il codice di pulizia nel metodo 'Dispose(bool disposing)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
