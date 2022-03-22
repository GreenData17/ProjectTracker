using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Text.Json;
using Project_Tracker.Core;
using Project_Tracker.MVM.Model;

namespace Project_Tracker.MVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public static MainViewModel instance { get; set; }

        // Models //
        public static List<ProjectModel> loadedProjects = new List<ProjectModel>();

        // Commands //
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ProjectViewCommand { get; set; }
        public RelayCommand CreationViewCommand { get; set; }

        // Views //

        // events //

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


            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data")) 
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data");

            LoadProjectList();
        }

        public static void LoadProjectList()
        {
            loadedProjects = new List<ProjectModel>();
            foreach (string s in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\data"))
            {
                string input = File.ReadAllText(s);

                loadedProjects.Add(JsonSerializer.Deserialize<ProjectModel>(input));
            }
        }
    }
}
