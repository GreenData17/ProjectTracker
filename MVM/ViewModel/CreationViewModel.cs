using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Tracker.Core;

namespace Project_Tracker.MVM.ViewModel
{
    class CreationViewModel : ObservableObject
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectColor { get; set; }

        // Commands //
        public RelayCommand CreateProjectCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public CreationViewModel()
        {
            ProjectColor = "#59ecff";

            CreateProjectCommand = new RelayCommand(o => {
                
            });

            CancelCommand = new RelayCommand(o => {
                MainViewModel.instance.CurrentView = new HomeViewModel();
            });
        }
    }
}
