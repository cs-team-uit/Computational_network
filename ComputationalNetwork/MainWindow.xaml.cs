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

namespace ComputationalNetwork
{
	struct Attribute
	{
		string m_type;
		string m_value;
	}
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		Attribute[] m_assumptions;
		Attribute[] m_conclusions;

        public MainWindow()
        {
            InitializeComponent();
        }

		private void AddAttribute_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Go_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
