﻿#pragma checksum "..\..\..\..\..\Views\UserControls\.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BF89EE7DAEB9F09D10D9A3160D9087C928CCBF85"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KoD_Library_HCI_Core6.Views.UserControls;
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


namespace KoD_Library_HCI_Core6.Views.UserControls {
    
    
    /// <summary>
    /// PregledKnjiga
    /// </summary>
    public partial class PregledKnjiga : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Views\UserControls\.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKnjige;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Views\UserControls\.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrikaziDetalje;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KoD_Library_HCI_Core6;V1.0.0.0;component/views/usercontrols/.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\UserControls\.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgKnjige = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\..\..\..\Views\UserControls\.xaml"
            this.dgKnjige.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgKnjige_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnPrikaziDetalje = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\Views\UserControls\.xaml"
            this.btnPrikaziDetalje.Click += new System.Windows.RoutedEventHandler(this.btnPrikaziDetalje_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

