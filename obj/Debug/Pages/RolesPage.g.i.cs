﻿#pragma checksum "..\..\..\Pages\RolesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DB1B34FC994CE324918E5B94891DEE74F78EA2E92F0CFEE0289E94A3C30414A9"
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
    /// RolesPage
    /// </summary>
    public partial class RolesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Pages\RolesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid RolesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Pages\RolesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoleBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Pages\RolesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\RolesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\RolesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadData;
        
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
            System.Uri resourceLocater = new System.Uri("/TravelApp;component/pages/rolespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\RolesPage.xaml"
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
            
            #line 9 "..\..\..\Pages\RolesPage.xaml"
            ((TravelApp.Pages.RolesPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RolesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 13 "..\..\..\Pages\RolesPage.xaml"
            this.RolesDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RolesDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\RolesPage.xaml"
            this.RolesDataGrid.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.RolesDataGrid_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RoleBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\Pages\RolesPage.xaml"
            this.RoleBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.RoleBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Pages\RolesPage.xaml"
            this.EditButton.Click += new System.Windows.RoutedEventHandler(this.EditButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\RolesPage.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LoadData = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Pages\RolesPage.xaml"
            this.LoadData.Click += new System.Windows.RoutedEventHandler(this.LoadData_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

