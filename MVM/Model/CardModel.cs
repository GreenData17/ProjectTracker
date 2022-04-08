using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tracker.MVM.Model
{
    public class CardModel
    {
        // Main-Info //
        public string title { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string picturePath { get; set; }

        public uint id { get; set; }
        public string parentSection { get; set; }


        // States //
        public int importance { get; set; } // 0=normal 1=importand 2=urgend 3=Emergency 
        public int tagSelected { get; set; }
        public int progressState { get; set; }


        // Tools //
        public string[] checkListNames { get; set; }
        public bool[] checkListCheckBox { get; set; }
    }
}
