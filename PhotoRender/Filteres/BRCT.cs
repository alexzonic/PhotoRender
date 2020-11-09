using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
// нашел в инете может пригодится в один момент
namespace PhotoRender.Filteres
{
    class BRCT : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty =
        ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BRCT), 0);

        public static readonly DependencyProperty BrightnessProperty =
            DependencyProperty.Register(nameof(Brightness), typeof(double), typeof(BRCT), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ContrastProperty =
            DependencyProperty.Register(nameof(Contrast), typeof(double), typeof(BRCT), new UIPropertyMetadata(0.0, PixelShaderConstantCallback(1)));


        public BRCT(Uri uri)
        {
            PixelShader = new PixelShader() { UriSource = uri};
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(BrightnessProperty);
            UpdateShaderValue(ContrastProperty);
        }

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public double Brightness
        {
            get { return (double)GetValue(BrightnessProperty); }
            set { SetValue(BrightnessProperty, value); }
        }

        public double Contrast
        {
            get { return (double)GetValue(ContrastProperty); }
            set { SetValue(ContrastProperty, value); }
        }
    }
}
