using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Kernel;
using System;
using System.Linq;


namespace OpAM.TemplateControls
{
    public partial class ArcGaugeControl1 : UserControl
    {

        #region Propriedades

        private string _gaugeTitle;

        public static readonly DirectProperty<ArcGaugeControl1,string> GaugeTitleProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, string>(nameof(GaugeTitle), o=>o.GaugeTitle, (o,v) => o.GaugeTitle = v);
        public string GaugeTitle
        {
            get => _gaugeTitle; set => SetAndRaise(GaugeTitleProperty, ref _gaugeTitle,value);
        }


        private string _gaugeUnits;

        public static readonly DirectProperty<ArcGaugeControl1,string> GaugeUnitsProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, string>(nameof(GaugeUnits), o => o.GaugeUnits, (o, v) => o.GaugeUnits = v);
        public string GaugeUnits
        {
            get => _gaugeUnits; set => SetAndRaise(GaugeUnitsProperty, ref _gaugeUnits, value);
        }



        private double _maxValue;

        public static readonly DirectProperty<ArcGaugeControl1, double> MaxValueProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, double>(nameof(MaxValue), o => o.MaxValue, (o, v) => o.MaxValue = v);
        public double MaxValue
        {
            get => _maxValue; set => SetAndRaise(MaxValueProperty, ref _maxValue, value);
        }


        private double _minValue;

        public static readonly DirectProperty<ArcGaugeControl1, double> MinValueProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, double>(nameof(MinValue), o => o.MinValue, (o, v) => o.MinValue = v);
        public double MinValue
        {
            get => _minValue; set => SetAndRaise(MinValueProperty, ref _minValue, value);
        }


        private double _value;

        public static readonly DirectProperty<ArcGaugeControl1, double> ValueProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, double>(nameof(Value), o => o.Value, (o, v) => o.Value = v);
        public double Value
        {
            get => _value; set => SetAndRaise(ValueProperty, ref _value, value);
        }


        private double _settingValue;

        public static readonly DirectProperty<ArcGaugeControl1, double> SettingValueProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, double>(nameof(SettingValue), o => o.SettingValue, (o, v) => o.SettingValue = v);
        public double SettingValue
        {
            get => _settingValue; set => SetAndRaise(SettingValueProperty, ref _settingValue, value);
        }


        private ImmutableSolidColorBrush _gaugeColor;

        public static readonly DirectProperty<ArcGaugeControl1, ImmutableSolidColorBrush> GaugeColorProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, ImmutableSolidColorBrush>(nameof(GaugeColor), o=>o.GaugeColor, (o,v)=>o.GaugeColor = v);
        public ImmutableSolidColorBrush GaugeColor
        {
            get => _gaugeColor; set => SetAndRaise(GaugeColorProperty, ref _gaugeColor,value);
        }

        private ImmutableSolidColorBrush _settingGaugeColor;

        public static readonly DirectProperty<ArcGaugeControl1, ImmutableSolidColorBrush> SettingGaugeColorProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, ImmutableSolidColorBrush>(nameof(SettingGaugeColor), o => o.SettingGaugeColor, (o, v) => o.SettingGaugeColor = v);
        public ImmutableSolidColorBrush SettingGaugeColor
        {
            get => _settingGaugeColor; set => SetAndRaise(SettingGaugeColorProperty, ref _settingGaugeColor, value);
        }


        private bool _maxReached;

        public static readonly DirectProperty<ArcGaugeControl1, bool> MaxReachedProperty = AvaloniaProperty.RegisterDirect<ArcGaugeControl1, bool>(nameof(MaxReached), o => o.MaxReached, (o, v) => o.MaxReached = v);
        public bool MaxReached
        {
            get => _maxReached; set => SetAndRaise(MaxReachedProperty, ref _maxReached, value);
        }

        #endregion



        readonly double FULLRANGE_ANGLE = 270;
        readonly double START_ANGLE_OFFSET = 90.0;


        public ArcGaugeControl1()
        {

            InitializeComponent();
            var path = this.FindControl<Path>("Arco");

            // Initialize the timer to change the arc segment every second
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) =>
            {
                Random_Values();
                SetupArcSegment(path);
                SetLimValue();


            };

            // Start the timer
            timer.Start();





        }

        private void Random_Values()
        {
            Random rnd_value = new Random();
            int temp = rnd_value.Next(-1000, 1000);
            Value = temp * 0.1;

            if (Value >= SettingValue)
            {
                MaxReached = true;
            }
            else
            {
                MaxReached = false;
            }
            //Random rnd_setting = new Random();
            //int temp2 = rnd_setting.Next(-1000, 1000);
            //SettingValue = temp2 * 0.1;

        }


        #region metodos privados

        private void SetupArcSegment(Path path)
        {
            MaxValue = 100;
            MinValue = -100;

            var getGaugeProp = SetGaugePos();

            // Create a new PathGeometry with a new ArcSegment
            var pathGeometry = new PathGeometry();
            var pathFigure = new PathFigure { StartPoint = new Point(160, 160) };
            var lineSegment = new LineSegment { Point = new Point(160, 320) };
            var lineSegment2 = new LineSegment { Point = new Point(160, 160) };
            var arcSegment = new ArcSegment
            {
                Size = new Size(160, 160),
                //Point = new Point(150 + DateTime.Now.Second, 150 + DateTime.Now.Second),
                //IsLargeArc = true,
                Point = getGaugeProp.Item1,
                IsLargeArc = getGaugeProp.Item2,
                SweepDirection = SweepDirection.Clockwise
            };
            pathFigure.Segments.Add(lineSegment);
            pathFigure.Segments.Add(arcSegment);
            pathFigure.Segments.Add(lineSegment2);
            pathGeometry.Figures.Add(pathFigure);

            // Set the Path's Data property to the new PathGeometry
            path.Data = pathGeometry;

            
            

            
        }



        private Tuple<Point,bool> SetGaugePos()
        {
            Point point;
            bool largeArc;

            if (Value >= MaxValue)
            {
                point = new Point(320, 160);

                largeArc = true;



            }
            else if (Value <= MinValue)
            {
                point = new Point(160, 320);
                largeArc = false;
            }
            else
            {
                double angle = FULLRANGE_ANGLE / (MaxValue - MinValue) * (Value - MinValue);
                double rad = (Math.PI / 180.0) * (angle + START_ANGLE_OFFSET);
                double x = 160 * Math.Cos(rad) + 160;
                double y = 160 * Math.Sin(rad) + 160;

                point = new Point(x, y);

                largeArc = angle > 180;
            }

            return Tuple.Create(point, largeArc);

        }

        private void SetLimValue() 
        { 
            if (SettingValue >= MaxValue)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.Angle = -90;
                ptSetup.RenderTransform = rotate;

            }
            else if (SettingValue <= MinValue)
            {
                RotateTransform rotate = new RotateTransform();
                rotate.Angle = 0;
                ptSetup.RenderTransform = rotate;
            }
            else
            {
                double angle = FULLRANGE_ANGLE  / (MaxValue - MinValue) * (SettingValue - MinValue);
                if (angle <= 180)
                {
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = angle;
                    ptSetup.RenderTransform = rotate;
                }
                else
                {
                    RotateTransform rotate = new RotateTransform();
                    rotate.Angle = -360 + angle;
                    ptSetup.RenderTransform = rotate;
                }
            }
        }




        #endregion


        //public override void Render(DrawingContext context)
        //{

        //    base.Render(context);
        //    RenderGauge();
        //}


    }
}
