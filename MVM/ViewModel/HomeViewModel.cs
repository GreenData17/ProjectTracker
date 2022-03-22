using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Tracker.Core;
using Project_Tracker.MVM.Model;
using Project_Tracker.MVM.View;

namespace Project_Tracker.MVM.ViewModel
{
    class HomeViewModel : ObservableObject
    {
        public ObservableCollection<ProjectModel> FavProjectCards { get; set; }
        public ObservableCollection<ProjectModel> AllProjectCards { get; set; }
        public ObservableCollection<ProjectModel> LatestProjectCards { get; set; }

        private ProjectModel m_SelectedFavProjectCard;
        private ProjectModel m_SelectedAllProjectCard;
        private ProjectModel m_SelectedLatestProjectCard;

        public ProjectModel SelectedFavProjectCard
        {
            get { return m_SelectedFavProjectCard; }
            set
            {
                m_SelectedFavProjectCard = value;
                OpenProject(value);
                OnPropertyChanged();
            }
        }

        public ProjectModel SelectedAllProjectCard
        {
            get { return m_SelectedAllProjectCard; }
            set
            {
                m_SelectedAllProjectCard = value;
                OpenProject(value);
                OnPropertyChanged();
            }
        }

        public ProjectModel SelectedLatestProjectCard
        {
            get { return m_SelectedLatestProjectCard; }
            set
            {
                m_SelectedLatestProjectCard = value;
                OpenProject(value);
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            MainViewModel.LoadProjectList();

            LatestProjectCards = new ObservableCollection<ProjectModel>();
            FavProjectCards = new ObservableCollection<ProjectModel>();
            AllProjectCards = new ObservableCollection<ProjectModel>();

            // -- -- //

            List<ProjectModel> temp = new List<ProjectModel>();
            foreach (ProjectModel pm in MainViewModel.loadedProjects)
            {
                temp.Add(pm);
            }
            temp.Sort((x, y) => DateTime.Compare(x.LastChangeTime, y.LastChangeTime));
            foreach (ProjectModel pm in temp)
            {
                LatestProjectCards.Add(pm);
            }

            // -- -- //

            foreach (ProjectModel pm in MainViewModel.loadedProjects)
            {
                AllProjectCards.Add(pm);
            }

            // -- -- //

            foreach (ProjectModel pm in MainViewModel.loadedProjects)
            {
                if(pm.Favorite)
                    FavProjectCards.Add(pm);
            }
        }

        void OpenProject(ProjectModel project)
        {
            AppManager.openProject = project;
            MainViewModel.instance.CurrentView = new ProjectView();
        }
    }
}
