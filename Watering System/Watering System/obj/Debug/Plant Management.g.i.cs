﻿#pragma checksum "..\..\Plant Management.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5EFAED7F9E649B9FE771E419D54DC31BC7FF0FED4019D674FE98B196A6BB4CEC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
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
using Watering_System;


namespace Watering_System {
    
    
    /// <summary>
    /// Plant_Management
    /// </summary>
    public partial class Plant_Management : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lst_plants;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_pln_id;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_name;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_typ;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_temp;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_hum;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_soil;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cansel;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_save;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_creat;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_update;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Plant Management.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_delete;
        
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
            System.Uri resourceLocater = new System.Uri("/Watering System;component/plant%20management.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Plant Management.xaml"
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
            this.lst_plants = ((System.Windows.Controls.ListBox)(target));
            
            #line 22 "..\..\Plant Management.xaml"
            this.lst_plants.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lst_plants_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txt_pln_id = ((System.Windows.Controls.TextBox)(target));
            
            #line 63 "..\..\Plant Management.xaml"
            this.txt_pln_id.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            
            #line 63 "..\..\Plant Management.xaml"
            this.txt_pln_id.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_usr_id_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cmb_typ = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txt_temp = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\Plant Management.xaml"
            this.txt_temp.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_hum = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\Plant Management.xaml"
            this.txt_hum.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_soil = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\Plant Management.xaml"
            this.txt_soil.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_cansel = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\Plant Management.xaml"
            this.btn_cansel.Click += new System.Windows.RoutedEventHandler(this.btn_cansel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_save = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\Plant Management.xaml"
            this.btn_save.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btn_creat = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\Plant Management.xaml"
            this.btn_creat.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btn_update = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Plant Management.xaml"
            this.btn_update.Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btn_delete = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
