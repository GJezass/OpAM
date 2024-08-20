using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;

namespace OpAM.TemplateControls
{
    public class ModuleBoxControl : TemplatedControl
    {
        public static readonly StyledProperty<string> LargeTextLabelProperty = AvaloniaProperty.Register<ModuleBoxControl, string>(nameof(LargeTextLabel), "Nome Modulo");
        public string LargeTextLabel
        {
            get => (string)GetValue(LargeTextLabelProperty); set => SetValue(LargeTextLabelProperty, value);
        }

        public static readonly StyledProperty<IBitmap> TextImageProperty = AvaloniaProperty.Register<ModuleBoxControl, IBitmap>(nameof(TextImage));
        public IBitmap TextImage
        {
            get => GetValue(TextImageProperty); set => SetValue(TextImageProperty, value);
        }

    }
}
