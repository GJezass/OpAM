using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Media.Imaging;

namespace OpAM.TemplateControls
{
    public class OverrideControl1 : TemplatedControl
    {

        public static readonly StyledProperty<string> LargeTextLabelProperty = AvaloniaProperty.Register<OverrideControl1, string>(nameof(LargeTextLabel), "Nome Modulo");
        public string LargeTextLabel
        {
            get => (string)GetValue(LargeTextLabelProperty); set => SetValue(LargeTextLabelProperty, value);
        }

        public static readonly StyledProperty<IBitmap> TextImageProperty = AvaloniaProperty.Register<OverrideControl1, IBitmap>(nameof(TextImage));
        public IBitmap TextImage
        {
            get => GetValue(TextImageProperty); set => SetValue(TextImageProperty, value);
        }

    }
}
