﻿#pragma checksum "..\..\..\Windows\AdminWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B77BADB9A5902DD73C6F988F8CBAB76122AAA07B30EDB48511B4B088B6BB9E76"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TravelApp.Windows;


namespace TravelApp.Windows {
    
    
    /// <summary>
    /// AdminWindow
    /// </summary>
    public partial class AdminWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HideAppButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseAppButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox WindowComboBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame AdminFrame;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Windows\AdminWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReturnButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TravelApp;component/windows/adminwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AdminWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\Windows\AdminWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HideAppButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Windows\AdminWindow.xaml"
            this.HideAppButton.Click += new System.Windows.RoutedEventHandler(this.HideAppButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseAppButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Windows\AdminWindow.xaml"
            this.CloseAppButton.Click += new System.Windows.RoutedEventHandler(this.CloseAppButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.WindowComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\..\Windows\AdminWindow.xaml"
            this.WindowComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.WindowComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AdminFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.ReturnButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Windows\AdminWindow.xaml"
            this.ReturnButton.Click += new System.Windows.RoutedEventHandler(this.ReturnButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

