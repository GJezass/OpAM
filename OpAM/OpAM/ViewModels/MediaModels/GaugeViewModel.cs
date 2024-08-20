using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.Defaults;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace OpAM.ViewModels.MediaModels
{
    [ObservableObject]
    public partial class GaugeViewModel
    {
        private readonly Random _random = new Random();

        [ObservableProperty]
        private bool _maxReached = false;

        public GaugeViewModel()
        {
            SKColor[] sKColors = new[] { new SKColor(220, 237, 194), new SKColor(255, 140, 148) };
            Fill = new LinearGradientPaint(sKColors, new SKPoint(0.2f, 0), new SKPoint(0.9f, 1));
            OValue = new ObservableValue { Value = 30};
            Series = new GaugeBuilder()
             

            .WithMaxColumnWidth(175)
            .WithBackgroundMaxRadialColumnWidth(200)
            .WithLabelsSize(40)
            .WithInnerRadius(75)
            .WithBackground(new SolidColorPaint(new SKColor(100, 181, 246, 90)))
            .WithLabelsPosition(PolarLabelsPosition.ChartCenter)
            .AddValue(OValue, "Total Shaft Power (KW)", Fill, Fill) // defines the value and the color 
            .BuildSeries();
        }

        public ObservableValue OValue { get; set; } 
        public IEnumerable<ISeries> Series { get; set; }

        public LinearGradientPaint Fill;



        [RelayCommand]
        public void DoRandomValue()
        {
            OValue.Value = _random.Next(0,100);
            if (OValue.Value >= 60) MaxReached = true;
            else MaxReached = false;
        }

    }
}
