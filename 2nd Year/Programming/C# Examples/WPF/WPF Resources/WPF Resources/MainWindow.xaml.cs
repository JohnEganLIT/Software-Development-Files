using System.Windows;
using System.Windows.Media;

namespace WPF_Resources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush colour = (SolidColorBrush)TryFindResource("DynamicButtonColour");
            SolidColorBrush colour2 = new SolidColorBrush(Colors.Red);
          
            if(colour == null)
            {
                Resources["DynamicButtonColour"] = new SolidColorBrush(Colors.Green);
            }

            else if (colour.Color == Colors.Red)
            {
                Resources["DynamicButtonColour"] = new SolidColorBrush(Colors.Green);
            }

            else
            {
                Resources["DynamicButtonColour"] = new SolidColorBrush(Colors.Red);
            }
        }
    }
}

/*
Application resources are in App.xaml, they can be accessed from the entire application.
Window resources are in the each windows xaml file, they an be accessed from the current window. 
Control resources are in a control, they can only be accessed from within that control.

There are 2 types of resource, Static and Dynamic.
Static resources are resolved at compile time.It worked as you type.
Dynamic resources are resolved at runtime. It won't take affect until the program is run. Can be used for things such as language localisation.
*/
