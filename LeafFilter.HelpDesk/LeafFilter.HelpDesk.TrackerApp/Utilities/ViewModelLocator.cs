using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace LeafFilter.HelpDesk.TrackerApp.Utilities
{
    public static class ViewModelLocator
    {
        public static readonly DependencyProperty AutoWireViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWireViewModel",
                typeof(bool), typeof(ViewModelLocator),
                new PropertyMetadata(false, AutoWireViewModelChanged));

        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }        

        private static void AutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d)) return;
            
            var viewModelType = new List<string>();
            d.GetType().FullName.Split(".").ToList()
                .ForEach(x => viewModelType.Add(x.Replace("View", "ViewModel")));            
            ((FrameworkElement)d).DataContext = Activator.CreateInstance(Type.GetType(String.Join(".", viewModelType.ToArray())));            
        }        
    }
}
