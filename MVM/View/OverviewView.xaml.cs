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
using Project_Tracker.Core;

namespace Project_Tracker.MVM.View
{
    /// <summary>
    /// Interaktionslogik für OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        public OverviewView()
        {
            InitializeComponent();

            v_ProjectName.Text = AppManager.openProject.Name;
            v_ProjectDesc.Text = AppManager.openProject.Description;
        }
    }
}
