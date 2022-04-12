using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Tracker.Core;
using Project_Tracker.MVM.View;

namespace Project_Tracker.MVM.ViewModel
{
    class ProjectViewModel : ObservableObject
    {
        public static ProjectViewModel instance;

        // Commands //
        public RelayCommand OverviewViewCommand { get; set; }
        public RelayCommand ProgressViewCommand { get; set; }
        public RelayCommand BugViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand CardEditViewCommand { get; set; }

        // vars //
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

        public ProjectViewModel()
        {
            instance = this;

            CurrentView = new OverviewView();

            OverviewViewCommand = new RelayCommand(o =>
            {
                CurrentView = new OverviewView();
            });

            ProgressViewCommand = new RelayCommand(o =>
            {
                CurrentView = new ProgressView();
            });

            BugViewCommand = new RelayCommand(o =>
            {
                CurrentView = new BugView();
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = new ProjectSettingsView();
            });

            CardEditViewCommand = new RelayCommand(o =>
            {
                CurrentView = new CardEditView();
            });
        }
    }
}
