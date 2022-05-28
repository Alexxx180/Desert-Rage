﻿#pragma checksum "..\..\..\..\..\Controls\Scenes\BattleScene.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4042C7A0211FEB42CFDCF2A4DC0D8420C4849510"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DesertRage.Controls.Scenes;
using DesertRage.Decorators.UI.Bindings.Attach;
using DesertRage.Decorators.UI.Bindings.Converters;
using SharpVectors.Converters;
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


namespace DesertRage.Controls.Scenes {
    
    
    /// <summary>
    /// BattleScene
    /// </summary>
    public partial class BattleScene : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DesertRage.Controls.Scenes.BattleScene Battle;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop TransparentCurtain;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop BlackCurtain;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Curtain;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop FillCurtain;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop BorderCurtain;
        
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
            System.Uri resourceLocater = new System.Uri("/Desert Rage;V1.0.1.0;component/controls/scenes/battlescene.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
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
            this.Battle = ((DesertRage.Controls.Scenes.BattleScene)(target));
            return;
            case 2:
            this.TransparentCurtain = ((System.Windows.Media.GradientStop)(target));
            return;
            case 3:
            this.BlackCurtain = ((System.Windows.Media.GradientStop)(target));
            return;
            case 4:
            this.Curtain = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            this.FillCurtain = ((System.Windows.Media.GradientStop)(target));
            return;
            case 6:
            this.BorderCurtain = ((System.Windows.Media.GradientStop)(target));
            return;
            case 7:
            
            #line 203 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).Completed += new System.EventHandler(this.BattleStart);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 214 "..\..\..\..\..\Controls\Scenes\BattleScene.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).Completed += new System.EventHandler(this.Exit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

