using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarWarsApi.Views.UserControls
{
    public partial class CharacterPortrait : UserControl
    {
        public CharacterPortrait()
        {
            InitializeComponent();
        }

        public ImageSource Headshot
        {
            get { return (ImageSource)GetValue(HeadshotProperty); }
            set { SetValue(HeadshotProperty, value); }
        }

        public static readonly DependencyProperty HeadshotProperty = DependencyProperty.Register("Headshot",
                                                                                        typeof(ImageSource),
                                                                                        typeof(CharacterPortrait));
        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public new static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background",
                                                                                             typeof(Brush),
                                                                                             typeof(CharacterPortrait));
        public new double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        public new static readonly DependencyProperty HeightProperty = DependencyProperty.Register("Height",
                                                                                             typeof(double),
                                                                                             typeof(CharacterPortrait),
                                                                                             new PropertyMetadata(200.00));
        public new double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public new static readonly DependencyProperty WidthProperty = DependencyProperty.Register("Width",
                                                                                             typeof(double),
                                                                                             typeof(CharacterPortrait),
                                                                                             new PropertyMetadata(200.00));

        
    }
}