using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using OpAM.TemplateControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpAM.ViewModels.MediaModels
{
    public partial class ArcGaugeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string? _gaugeTitle;
        private string? _gaugeUnits;
        private double _maxValue;
        private double _minValue;
        private double _value;
        private double _settingValue;

        public string? GaugeTitle
        {
            get { return _gaugeTitle; }
            set
            {
                _gaugeTitle = value;
                OnPropertyChanged("GaugeTitle");
            }
        }

        public string? GaugeUnits
        {
            get { return _gaugeUnits; }
            set
            {
                _gaugeUnits = value;
                OnPropertyChanged("GaugeUnits");
            }
        }

        public double MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                OnPropertyChanged("MaxValue");
            }
        }

        public double Min
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                OnPropertyChanged("MinValue");
            }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public double SettingValue
        {
            get { return _settingValue; }
            set
            {
                _settingValue = value;
                OnPropertyChanged("SettingValue");
            }
        }

        
    }
}

