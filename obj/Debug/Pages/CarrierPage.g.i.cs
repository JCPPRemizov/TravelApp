﻿#pragma checksum "..\..\..\Pages\CarrierPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D708467A5802129AA1394232C69DEB9962C0E0D26E457D7F8FF4D515426141E5"
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
using TravelApp.Pages;


namespace TravelApp.Pages {
    
    
    /// <summary>
    /// CarrierPage
    /// </summary>
    public partial class CarrierPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\CarrierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CarriersDataGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\CarrierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CarrierlNameBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Pages\CarrierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CarrierInnBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\CarrierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\CarrierPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
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
            System.Uri resourceLocater = new System.Uri("/TravelApp;component/pages/carrierpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\CarrierPage.xaml"
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
            
            #line 9 "..\..\..\Pages\CarrierPage.xaml"
            ((TravelApp.Pages.CarrierPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CarriersDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\Pages\CarrierPage.xaml"
            this.CarriersDataGrid.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.CarriersDataGrid_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\CarrierPage.xaml"
            this.CarriersDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CarriersDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CarrierlNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\Pages\CarrierPage.xaml"
            this.CarrierlNameBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CarrierlNameBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CarrierInnBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\Pages\CarrierPage.xaml"
            this.CarrierInnBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CarrierInnBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\CarrierPage.xaml"
            this.EditButton.Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Pages\CarrierPage.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

