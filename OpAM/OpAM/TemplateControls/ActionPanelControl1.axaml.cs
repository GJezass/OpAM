using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Media.Imaging;

namespace OpAM.TemplateControls
{
    public class ActionPanelControl1 : TemplatedControl
    {
        public static readonly StyledProperty<string> LargeTextLabelProperty = AvaloniaProperty.Register<ModuleBoxControl, string>(nameof(LargeTextLabel), "Nome Modulo");
        public string LargeTextLabel
        {
            get => (string)GetValue(LargeTextLabelProperty); set => SetValue(LargeTextLabelProperty, value);
        }

        public static readonly StyledProperty<IBitmap> ButtonTextImageProperty = AvaloniaProperty.Register<ModuleBoxControl, IBitmap>(nameof(ButtonTextImage));
        public IBitmap ButtonTextImage
        {
            get => GetValue(ButtonTextImageProperty); set => SetValue(ButtonTextImageProperty, value);
        }

        public static readonly StyledProperty<IBitmap> TextImageProperty = AvaloniaProperty.Register<ModuleBoxControl, IBitmap>(nameof(TextImage));
        public IBitmap TextImage
        {
            get => GetValue(TextImageProperty); set => SetValue(TextImageProperty, value);
        }


        #region metodos privados



        #endregion
    }
}
