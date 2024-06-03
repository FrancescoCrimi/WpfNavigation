// Copyright (c) 2024 Francesco Crimi francrim@gmail.com
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfNavigation.Pages;

namespace WpfNavigation;
public class NavigationService
{
    private readonly Frame _frame;
    private object? _lastParameterUsed;

    public NavigationService(Frame frame)
    {
        _frame = frame;
        _frame.Navigating += Frame_Navigating;
        _frame.Navigated += Frame_Navigated;
    }

    public bool CanGoBack
        => _frame.CanGoBack;

    public bool CanGoForward
        => _frame.CanGoForward;

    public void GoBack()
    {
        if (_frame.CanGoBack)
        {
            _frame.GoBack();
        }
    }

    public void GoForward()
    {
        if (!_frame.CanGoForward)
        {
            _frame.GoForward();
        }
    }

    public bool Navigate(Uri source, object? parameter = null, bool clearNavigation = true)
    {
        if (_frame.CurrentSource != source || parameter != null && !parameter.Equals(_lastParameterUsed))
        {
            _frame.Tag = clearNavigation;
            var navigated = _frame.Navigate(source, parameter);
            _lastParameterUsed = parameter;
            return navigated;
        }
        return false;
    }

    public bool Navigate(Page content, object? parameter = null, bool clearNavigation = true)
    {
        if (_frame.Content != content || parameter != null && !parameter.Equals(_lastParameterUsed))
        {
            _frame.Tag = clearNavigation;
            var navigated = _frame.Navigate(content, parameter);
            _lastParameterUsed = parameter;
            return navigated;
        }
        return false;
    }

    private void Frame_Navigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame)
        {
            var clearNavigation = (bool?)frame.Tag;
            if (clearNavigation == true)
            {
                while (frame.CanGoBack)
                {
                    frame.RemoveBackEntry();
                }
            }
            if (frame.Content is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(e.ExtraData);
            }
        }
    }

    private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        if (sender is Frame frame)
        {
            if (frame.Content is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedFrom();
            }
        }
    }
}
