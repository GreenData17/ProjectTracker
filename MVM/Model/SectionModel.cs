using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tracker.MVM.Model
{
    public class SectionModel
    {
        public string Name { get; set; }
        public List<CardModel> Cards { get; set; } = new List<CardModel>();
    }
}
