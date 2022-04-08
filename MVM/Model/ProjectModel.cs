using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tracker.MVM.Model
{
    public class ProjectModel
    {
        // General //
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public bool Favorite { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }


        // Progress //
        public string[] SectionNames { get; set; }
        public CardModel[] Cards { get; set; }


        public string[] TagNames { get; set; }
        public string[] TagColor { get; set; }

        public string[] ProgressStateName { get; set; }
    }
}
