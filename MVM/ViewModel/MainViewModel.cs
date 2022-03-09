using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Tracker.Core;
using Project_Tracker.MVM.Model;

namespace Project_Tracker.MVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public static MainViewModel instance { get; set; }

        // Models //


        // Commands //
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ProjectViewCommand { get; set; }
        public RelayCommand CreationViewCommand { get; set; }

        // Views //

        // events //

        private object m_CurrentView;

        public object CurrentView
        {
            get { return m_CurrentView; }
            set
            {
                m_CurrentView = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            instance = this;

            CurrentView = new HomeViewModel();

            HomeViewCommand = new RelayCommand(o => {
                CurrentView = new HomeViewModel();
            });

            ProjectViewCommand = new RelayCommand(o => {
                CurrentView = new ProjectViewModel();
            });

            CreationViewCommand = new RelayCommand(o =>
            {
                CurrentView = new CreationViewModel();
            });
        }
    }
}
