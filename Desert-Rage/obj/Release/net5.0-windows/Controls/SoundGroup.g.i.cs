﻿#pragma checksum "..\..\..\..\Controls\SoundGroup.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D57D621365A26D1E1C53ADF313EA90644D8E4301"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DesertRage.Decorators.UI.Bindings.Converters;
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


namespace DesertRage.Controls {
    
    
    /// <summary>
    /// SoundGroup
    /// </summary>
    public partial class SoundGroup : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Controls\SoundGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DesertRage.Controls.SoundGroup This;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\Controls\SoundGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Sound1;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Controls\SoundGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Sound2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Controls\SoundGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement Sound3;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Desert Rage;V1.0.5.5;component/controls/soundgroup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\SoundGroup.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.This = ((DesertRage.Controls.SoundGroup)(target));
            return;
            case 2:
            this.Sound1 = ((System.Windows.Controls.MediaElement)(target));
            
            #line 11 "..\..\..\..\Controls\SoundGroup.xaml"
            this.Sound1.MediaEnded += new System.Windows.RoutedEventHandler(this.OnMusicEnd);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Sound2 = ((System.Windows.Controls.MediaElement)(target));
            
            #line 25 "..\..\..\..\Controls\SoundGroup.xaml"
            this.Sound2.MediaEnded += new System.Windows.RoutedEventHandler(this.OnSoundsEnd);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Sound3 = ((System.Windows.Controls.MediaElement)(target));
            
            #line 39 "..\..\..\..\Controls\SoundGroup.xaml"
            this.Sound3.MediaEnded += new System.Windows.RoutedEventHandler(this.OnSoundsEnd);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

