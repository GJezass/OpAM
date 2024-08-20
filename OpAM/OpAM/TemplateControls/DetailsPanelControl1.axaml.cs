using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace OpAM.TemplateControls
{
    public class DetailsPanelControl1 : TemplatedControl
    {
        public static readonly StyledProperty<string> LargeTextProperty = AvaloniaProperty.Register<DetailsPanelControl1, string>(nameof(LargeText), defaultValue: "LARGE TEXT");

        public string LargeText
        {
            get => (string)GetValue(LargeTextProperty);
            set => SetValue(LargeTextProperty, value);
        }

        public static readonly StyledProperty<string> SmallTextProperty = AvaloniaProperty.Register<DetailsPanelControl1, string>(nameof(SmallText), defaultValue: "SMALL TEXT");

        public string SmallText
        {
            get => (string)GetValue(SmallTextProperty);
            set => SetValue(SmallTextProperty, value);
        }
    }
}
