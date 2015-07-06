using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMES.View
{
    /// <summary>
    /// Interaction logic for ColorPickerSelector.xaml
    /// </summary>
    public partial class ColorPickerSelector : UserControl
    {
        #region Dependency        

        public static readonly DependencyProperty MaximumProperty =
        DependencyProperty.RegisterAttached
        (
            "Maximum",
            typeof(Int32), 
            typeof(ColorPickerSelector),
            new PropertyMetadata
            (
                new PropertyChangedCallback(OnMaximumChanged)
            )
        );

        public static readonly DependencyProperty ColorProperty =
         DependencyProperty.RegisterAttached
         (
             "Color",
             typeof(Object),
             typeof(ColorPickerSelector),
             new PropertyMetadata
             (
                 new PropertyChangedCallback(OnColorChanged)
             )
         );

        #endregion Dependency

        #region Properties

        public Int32 Maximum
        {
            get
            {
                return (Int32)GetValue(MaximumProperty);
            }
            set
            {
                SetValue(MaximumProperty, value);
            }
        }

        
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        private Color _editColor;
        public Color EditColor
        {
            get 
            {
                return _editColor;
            }
            set
            {
                _editColor = value;
            }
        }


        public Int32 Red { get; set;  }
        private Int32 Green { get; set; }
        private Int32 Blue { get; set; }

        public Boolean IsInternalCall;
        #endregion Properties

        #region Constructor

        public ColorPickerSelector()
        {
            InitializeComponent();
         
        }

        #endregion Constructor

        #region Listeners

        private static void OnMaximumChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var Target = (dependencyObject as ColorPickerSelector);
            Target.RedSlider.Maximum = (Int32)e.NewValue;
            Target.GreenSlider.Maximum = (Int32)e.NewValue;
            Target.BlueSlider.Maximum = (Int32)e.NewValue;
        }

        private static void OnColorChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;
            var Target = (dependencyObject as ColorPickerSelector);
     
            if(e.NewValue is Color)
            {
              
            }

            if(Target.IsInternalCall == false)
            {
                Target.Red = ((Color)e.NewValue).R;
                Target.Green = ((Color)e.NewValue).G;
                Target.Blue = ((Color)e.NewValue).B;
                Target.RedSlider.Value = Target.Red;
                Target.GreenSlider.Value = Target.Green;
                Target.BlueSlider.Value = Target.Blue;
                Target.ColorSample.Background = new SolidColorBrush(Target.Color);
            }  
         
        }


        #endregion Listeners

        private void RecalculateColor(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsInternalCall == true)
            {
                var Sender = (sender as Slider);
                
                if(Sender.Name == "RedSlider")
                {
                    Red = (Byte)(Int32)e.NewValue;
                }
                if (Sender.Name == "GreenSlider")
                {
                    Green = (Byte)(Int32)e.NewValue;
                }
                if (Sender.Name == "BlueSlider")
                {
                    Blue = (Byte)(Int32)e.NewValue;         
                }

                EditColor = Color.FromRgb((Byte)Red, (Byte)Green, (Byte)Blue);
                ColorSample.Background = new SolidColorBrush(EditColor);

                
            }
        }


        private void DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            IsInternalCall = true;
        }

        private void DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            IsInternalCall = false;
            Color = EditColor;
        }

    }
}
