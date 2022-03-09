using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tracker.MVM.Model
{
    class ProjectModel
    {
        // General //
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }

        // Progress //

        public string[] Title { get; set; }
        public string[] Description { get; set; }

        public int Importance { get; set; } //0=normal 1=importand 2=urgend 3=Emergency 

        public string[] TagNames { get; set; }
        public string[] TagColor { get; set; }
        public int TagSelected { get; set; }

        public string[] ProgressStateName { get; set; }
        public int ProgressState { get; set; }

        public string[] ChecklistNames { get; set; }
        public bool[] ChecklistCheckBox { get; set; }

        public string[] PictureFilePath { get; set; }
    }
}
