using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Project_Tracker.MVM.Model;

namespace Project_Tracker.Core
{
    public class AppManager { 

        public static ProjectModel openProject;

        public static void SaveProject()
        {
            string output = JsonSerializer.Serialize(openProject);

            File.WriteAllText(@$"{Directory.GetCurrentDirectory()}\data\{openProject.Name}.json", output);

            if (File.Exists(@$"{Directory.GetCurrentDirectory()}\data\{openProject.Name}.json"))
                openProject = JsonSerializer.Deserialize<ProjectModel>(File.ReadAllText(@$"{Directory.GetCurrentDirectory()}\data\{openProject.Name}.json"));
        }
    }
}
