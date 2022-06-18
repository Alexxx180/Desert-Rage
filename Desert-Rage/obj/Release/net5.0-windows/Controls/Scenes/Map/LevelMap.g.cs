﻿#pragma checksum "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5A8264A3CCAB5352455E59FC306CD7698DA51206"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DesertRage.Controls.Menu.Game;
using DesertRage.Controls.Scenes.Map;
using DesertRage.Decorators.UI.Bindings.Attach;
using DesertRage.Decorators.UI.Bindings.Converters;
using DesertRage.Resources.Media.OST.Noises.Info;
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


namespace DesertRage.Controls.Scenes.Map {
    
    
    /// <summary>
    /// LevelMap
    /// </summary>
    public partial class LevelMap : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DesertRage.Controls.Scenes.Map.LevelMap This;
        
        #line default
        #line hidden
        
        
        #line 378 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DesertRage.Controls.Scenes.Map.MapTile HeroTile;
        
        #line default
        #line hidden
        
        
        #line 744 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Curtain;
        
        #line default
        #line hidden
        
        
        #line 747 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop FillCurtain;
        
        #line default
        #line hidden
        
        
        #line 748 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Desert Rage;V1.0.1.0;component/controls/scenes/map/levelmap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.15.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.This = ((DesertRage.Controls.Scenes.Map.LevelMap)(target));
            return;
            case 2:
            this.HeroTile = ((DesertRage.Controls.Scenes.Map.MapTile)(target));
            return;
            case 3:
            this.Curtain = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            this.FillCurtain = ((System.Windows.Media.GradientStop)(target));
            return;
            case 5:
            this.BorderCurtain = ((System.Windows.Media.GradientStop)(target));
            return;
            case 6:
            
            #line 756 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).Completed += new System.EventHandler(this.EnemyApproaches);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 767 "..\..\..\..\..\..\Controls\Scenes\Map\LevelMap.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).Completed += new System.EventHandler(this.ContinueAdventure);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

