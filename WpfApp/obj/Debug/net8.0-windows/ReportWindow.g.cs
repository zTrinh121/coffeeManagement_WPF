﻿#pragma checksum "..\..\..\ReportWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6CFBFDEDBA49D1E238C4A86FA7113140466E6339"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using System.Windows.Controls.Ribbon;
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
using WpfApp;


namespace WpfApp {
    
    
    /// <summary>
    /// ReportWindow
    /// </summary>
    public partial class ReportWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnPersonal;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnExit;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menu;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button drink;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button report;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button employee;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\ReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/reportwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ReportWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\ReportWindow.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mnPersonal = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\..\ReportWindow.xaml"
            this.mnPersonal.Click += new System.Windows.RoutedEventHandler(this.mnPersonal_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mnExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 32 "..\..\..\ReportWindow.xaml"
            this.mnExit.Click += new System.Windows.RoutedEventHandler(this.mnExit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.menu = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\ReportWindow.xaml"
            this.menu.Click += new System.Windows.RoutedEventHandler(this.menu_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.drink = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\ReportWindow.xaml"
            this.drink.Click += new System.Windows.RoutedEventHandler(this.drink_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.report = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.employee = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\ReportWindow.xaml"
            this.employee.Click += new System.Windows.RoutedEventHandler(this.employee_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.logout = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\ReportWindow.xaml"
            this.logout.Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

