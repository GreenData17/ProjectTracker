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
    class HomeViewModel : ObservableObject
    {
        public ObservableCollection<ProjectModel> ProjectCards { get; set; }

        private ProjectModel m_SelectedProjectCard;

        public ProjectModel SelectedProjectCard
        {
            get { return m_SelectedProjectCard; }
            set
            {
                m_SelectedProjectCard = value;
                OnPropertyChanged();
            }
        }

        public HomeViewModel()
        {
            ProjectCards = new ObservableCollection<ProjectModel>();

            ProjectCards.Add(new ProjectModel
            {
                Name = "Project 1",
                Color = "#ffb759"
            });

            ProjectCards.Add(new ProjectModel
            {
                Name = "Project 2",
                Color = "#59f1ff"
            });

            ProjectCards.Add(new ProjectModel
            {
                Name = "Project 3",
                Color = "#f959ff"
            });

            ProjectCards.Add(new ProjectModel
            {
                Name = "Project 4",
                Color = "#f959ff"
            });
        }
    }
}
