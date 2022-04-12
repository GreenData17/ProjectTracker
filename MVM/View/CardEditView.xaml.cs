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
using Project_Tracker.MVM.Model;
using Project_Tracker.MVM.ViewModel;

namespace Project_Tracker.MVM.View
{
    /// <summary>
    /// Interaktionslogik für CardEditView.xaml
    /// </summary>
    public partial class CardEditView : UserControl
    {
        public CardEditView()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            CardModel temp = AppManager.openProject.Sections[AppManager.openSection].Cards[AppManager.openCard];
            TitleName.Text = temp.title;
            DescriptionTextBox.Text = temp.description;

            BackButton.Click += ReturnToProjectView;
            SaveButton.Click += SaveCard;
            DeleteButton.Click += DeleteCard;
        }

        private void ReturnToProjectView(object sender, RoutedEventArgs e)
        {
            ProjectViewModel.instance.CurrentView = new ProgressViewModel();
        }

        private void SaveCard(object sender, RoutedEventArgs args)
        {
            CardModel temp = AppManager.openProject.Sections[AppManager.openSection].Cards[AppManager.openCard];

            temp.title = TitleName.Text;
            temp.description = DescriptionTextBox.Text;

            AppManager.openProject.Sections[AppManager.openSection].Cards[AppManager.openCard] = temp;
            AppManager.SaveProject();
        }

        private void DeleteCard(object sebder, RoutedEventArgs args)
        {
            AppManager.openProject.Sections[AppManager.openSection].Cards.RemoveAt(AppManager.openCard);

            AppManager.SaveProject();
            ProjectViewModel.instance.CurrentView = new ProgressViewModel();
        }
    }
}
