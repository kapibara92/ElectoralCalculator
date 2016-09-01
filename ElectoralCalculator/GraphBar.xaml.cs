using ElectoralCalculator.ViewModel;
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
using System.Windows.Shapes;

namespace ElectoralCalculator
{
    /// <summary>
    /// Interaction logic for GraphBar.xaml
    /// </summary>
    public partial class GraphBar : Window
    {
        public GraphBar()
        {
            InitializeComponent();
        }
        public GraphBar(GraphViewModel graph)
        {
            InitializeComponent();
            this.DataContext = graph;
        }
    }
}
