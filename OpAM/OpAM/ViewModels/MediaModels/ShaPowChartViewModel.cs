using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Kernel;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using Avalonia.Media;
using Avalonia.Skia;
using LiveChartsCore.Defaults;
using Avalonia.Threading;

namespace OpAM.ViewModels.MediaModels
{
    [ObservableObject]
    public partial class ShaPowChartViewModel
    {

        #region Propriedades privadas

        private int index = 0;
        private Random random = new Random();
        private ObservableCollection<double?> observableValues;
        private ObservableCollection<double?> observableValues2;
        private static readonly SolidColorPaint glayoutColor = new SolidColorPaint(Color.Parse("#7f98c7").ToSKColor());

        #endregion

        #region Constructor
        public ShaPowChartViewModel()
        {
            observableValues= new ObservableCollection<double?>();
            observableValues2 = new ObservableCollection<double?>();

            
            

            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<double?>
                {
                    //Values = new double?[] { 2000, 1000, 3000, 5000, 3000, 4000, 6000 },
                    Values = observableValues,
                    Name= "Opti 1",
                    Fill = new SolidColorPaint(SKColors.Blue.WithAlpha(20)),
                    Stroke = new SolidColorPaint(SKColors.Blue.WithAlpha(60)) { StrokeThickness = 2 },
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 0,
                    EasingFunction=null
                },

                 new LineSeries<double?>
                {
                    //Values = new double?[] { 3000, 4000, 3000, 2000, 3000, 4000, 5000 },
                    Values = observableValues2,
                    Name= "Opti 2",
                    Fill = new SolidColorPaint(SKColors.Green.WithAlpha(20)),
                    Stroke = new SolidColorPaint(SKColors.Green.WithAlpha(60)) { StrokeThickness = 2 },
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 0,
                    EasingFunction=null
                }
            };

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) =>
            {
                removeVal();
                addRandVal();

            };

            timer.Start();

            //await Task.Delay(1000);
        }
        #endregion


        #region public methods

        public void addRandVal()
        {
            var rand = random.Next(0,6000);
            var rand2 = random.Next(0, 6000);

            observableValues.Add(rand);
            observableValues2.Add(rand2);
        }

        public void removeVal()
        {
            if(observableValues.Count()>10)
            observableValues.RemoveAt(0);

            if (observableValues2.Count() > 10)
                observableValues2.RemoveAt(0);
        }

        #endregion

        #region public props

        public ObservableCollection<ISeries> Series { get; set; }
        

        public LabelVisual Title { get; set; } =
        new LabelVisual
        {
            Text = "My chart title",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(SKColors.DarkSlateGray)
        };

        public Axis[] YAxes { get; set; } = { new Axis
            {
            
                Name = "Shaft Power",
                NamePaint =glayoutColor,
                
                LabelsPaint = glayoutColor,
                TicksPaint = glayoutColor,
                SubticksPaint = glayoutColor,
                DrawTicksPath = true,
                Labeler = (value) => value.ToString() + " kW"
            }
        };

        public RectangularSection[] Sections { get; set; } =
        {
            new RectangularSection
            {
                Yi = 4000,
                Yj = 4000,
                Stroke = new SolidColorPaint
                {
                    Color = SKColors.Red,
                    StrokeThickness = 3,
                    PathEffect = new DashEffect(new float[] { 6, 6 })
                }
            },
            
        };

        #endregion
    }
}
