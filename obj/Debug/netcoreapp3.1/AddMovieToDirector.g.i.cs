﻿#pragma checksum "..\..\..\AddMovieToDirector.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C829F8794BE204846A879217F213473E89809FD7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MoviesDB_Manager;
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


namespace MoviesDB_Manager {
    
    
    /// <summary>
    /// AddMovieToDirector
    /// </summary>
    public partial class AddMovieToDirector : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\AddMovieToDirector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox directorsComboBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\AddMovieToDirector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\AddMovieToDirector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox moviesComboBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AddMovieToDirector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MoviesDB_Manager;component/addmovietodirector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddMovieToDirector.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\AddMovieToDirector.xaml"
            ((MoviesDB_Manager.AddMovieToDirector)(target)).Initialized += new System.EventHandler(this.window_opened);
            
            #line default
            #line hidden
            return;
            case 2:
            this.directorsComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.titleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.moviesComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.checkBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\..\AddMovieToDirector.xaml"
            this.checkBox.Checked += new System.Windows.RoutedEventHandler(this.checkedCB);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\AddMovieToDirector.xaml"
            this.checkBox.Unchecked += new System.Windows.RoutedEventHandler(this.uncheckedCB);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 42 "..\..\..\AddMovieToDirector.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.add_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

