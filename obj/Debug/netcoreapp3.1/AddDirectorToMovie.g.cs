﻿#pragma checksum "..\..\..\AddDirectorToMovie.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DF5455C77034AD612CFFA2A3281CBCF90035AB10"
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
    /// AddDirectorToMovie
    /// </summary>
    public partial class AddDirectorToMovie : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\AddDirectorToMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox moviesComboBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\AddDirectorToMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AddDirectorToMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\AddDirectorToMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\AddDirectorToMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox directorsComboBox;
        
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
            System.Uri resourceLocater = new System.Uri("/MoviesDB_Manager;component/adddirectortomovie.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddDirectorToMovie.xaml"
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
            
            #line 9 "..\..\..\AddDirectorToMovie.xaml"
            ((MoviesDB_Manager.AddDirectorToMovie)(target)).Initialized += new System.EventHandler(this.window_opened);
            
            #line default
            #line hidden
            return;
            case 2:
            this.moviesComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.firstNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lastNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.checkBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 43 "..\..\..\AddDirectorToMovie.xaml"
            this.checkBox.Checked += new System.Windows.RoutedEventHandler(this.checkedCB);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\AddDirectorToMovie.xaml"
            this.checkBox.Unchecked += new System.Windows.RoutedEventHandler(this.uncheckedCB);
            
            #line default
            #line hidden
            return;
            case 6:
            this.directorsComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 46 "..\..\..\AddDirectorToMovie.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.add_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

