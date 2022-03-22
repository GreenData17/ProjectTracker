using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Project_Tracker.Core;

namespace Project_Tracker.MVM.ViewModel
{
    class ProjectSettingsViewModel : ObservableObject
    {
        public RelayCommand DeleteCommand { get; set; }

        public ProjectSettingsViewModel()
        {
            DeleteCommand = new RelayCommand(o =>
            {
                File.Delete(Directory.GetCurrentDirectory() + @$"\data\{AppManager.openProject.Name}.json");
                MainViewModel.instance.CurrentView = new HomeViewModel();
            });
        }
    }
}
