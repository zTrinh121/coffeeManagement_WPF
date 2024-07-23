﻿#pragma checksum "..\..\..\DrinkWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25BC75D2E3DB5AE5AFB7C75F0D8742268A78610F"
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
    /// DrinkWindow
    /// </summary>
    public partial class DrinkWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnPersonal;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem mnExit;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menu;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button drink;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button report;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button employee;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\DrinkWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp;component/drinkwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DrinkWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\DrinkWindow.xaml"
            ((WpfApp.DrinkWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\DrinkWindow.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mnPersonal = ((System.Windows.Controls.MenuItem)(target));
            
            #line 30 "..\..\..\DrinkWindow.xaml"
            this.mnPersonal.Click += new System.Windows.RoutedEventHandler(this.mnPersonal_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.mnExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 33 "..\..\..\DrinkWindow.xaml"
            this.mnExit.Click += new System.Windows.RoutedEventHandler(this.mnExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menu = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\DrinkWindow.xaml"
            this.menu.Click += new System.Windows.RoutedEventHandler(this.menu_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.drink = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.report = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\DrinkWindow.xaml"
            this.report.Click += new System.Windows.RoutedEventHandler(this.report_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.employee = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\DrinkWindow.xaml"
            this.employee.Click += new System.Windows.RoutedEventHandler(this.employee_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.logout = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\DrinkWindow.xaml"
            this.logout.Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

