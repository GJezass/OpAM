using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;

namespace OpAM.TemplateControls
{
    /// <summary>
    /// Logica de ativação do led
    /// </summary>
    public class LedControl1 : TemplatedControl
    {


        #region propriedades


        /// <summary>Definir se estado ativo</summary>
        ///
        public static readonly StyledProperty<bool> LedAtivoProperty = AvaloniaProperty.Register<LedControl1, bool>(nameof(LedAtivo), false);
        public bool LedAtivo
        {
            get => GetValue(LedAtivoProperty); set => SetValue(LedAtivoProperty, value);
        }

        
        ///<summary>Cor para quando ativo</summary>
        public static readonly StyledProperty<Color> ColorOnProperty = AvaloniaProperty.Register<LedControl1, Color>(nameof(ColorOn));

        public Color ColorOn
        {
            get => (Color)GetValue(ColorOnProperty); set => SetValue(ColorOnProperty, value);
        }


        #endregion


    }
}
