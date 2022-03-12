using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Менеджер проекта. Отвечает за сериализацию/десериализацию и за взаимодействие с проектом.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Базовый путь к контактам
        /// </summary>
        public static string DefaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ContactsApp");
        public static string Filename = "contacts.json";

        public string FullPath => Path.Combine(DefaultPath, Filename);
        
        //Для десериализации.
        [JsonConstructor]
        public ProjectManager(Project project)
        {
            Project = project;
        }

        public Project Project { get; protected set; }

        public void ChangePath(string path)
        {
            DefaultPath = path;
        }
        
        public void ChangeFilename(string name)
        {
            Filename = name;
        }
        
        public void Deserialize()
        {
            Project? project = null;
            try
            {
                var text = File.ReadAllText(FullPath);

                project = JsonConvert.DeserializeObject<Project>(text);
            }
            catch (Exception)
            {
                // ignored
            }

            if (project is not null)
            {
                Project = project;
            }
            else
            {
                Project = new Project(new List<Contact>());
                Serialize();
            }
        }

        public void Serialize()
        {
            var text = JsonConvert.SerializeObject(Project);

            if (!Directory.Exists(DefaultPath))
                Directory.CreateDirectory(DefaultPath);
            
            if (!File.Exists(FullPath))
                using (var stream = File.Create(FullPath))
                {
                    stream.Close();
                }
            
            File.WriteAllText(FullPath, text);
        }
    }
}