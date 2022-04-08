using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Tracker.Core;
using Project_Tracker.MVM.Model;
using System.Text.Json;

namespace Project_Tracker.MVM.ViewModel
{
    class CreationViewModel : ObservableObject
    {
        private string m_ProjectName;
        public string ProjectName
        {
            get => m_ProjectName;
            set { m_ProjectName = value; OnPropertyChanged(); }
        }

        private string m_ProjectDescription;
        public string ProjectDescription
        {
            get => m_ProjectDescription;
            set { m_ProjectDescription = value; OnPropertyChanged(); }
        }

        private string m_ProjectColor;
        public string ProjectColor
        {
            get => m_ProjectColor;
            set { m_ProjectColor = value; OnPropertyChanged(); }
        }

        // Commands //
        public RelayCommand CreateProjectCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public CreationViewModel()
        {
            ProjectColor = "#59ecff";

            CreateProjectCommand = new RelayCommand(o => {
                SaveNewProject();
            });

            CancelCommand = new RelayCommand(o => {
                MainViewModel.instance.CurrentView = new HomeViewModel();
            });
        }
    
        void SaveNewProject()
        {
            var data = new ProjectModel()
            {
                Name = ProjectName,
                Description = ProjectDescription,
                Color = ProjectColor,
                Favorite = false,
                CreationTime = DateTime.Now,
                LastChangeTime = DateTime.Now,
                SectionNames = new string[] {"Tasks", "In_Progress", "Done"},
                Cards = new CardModel[] { new CardModel() { title = "New Task", parentSection = "Tasks", id = 0} }
            };

            string output = JsonSerializer.Serialize(data);

            File.WriteAllText(@$"{Directory.GetCurrentDirectory()}\data\{ProjectName}.json", output);

            if (File.Exists(@$"{Directory.GetCurrentDirectory()}\data\{ProjectName}.json"))
                MainViewModel.instance.CurrentView = new HomeViewModel();
        }
    }
}
