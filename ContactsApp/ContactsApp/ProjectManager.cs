﻿using System;
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
        //Для десериализации.
        [JsonConstructor]
        public ProjectManager(Project project)
        {
            Project = project;
        }

        public Project Project { get; protected set; }

        public void Deserialize(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), "contacts.json");
            }

            Project? project = null;
            try
            {
                var text = File.ReadAllText(path);

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
                Serialize(path);
            }
        }

        public void Serialize(string path)
        {
            var directory = Path.GetDirectoryName(path);
            var text = JsonConvert.SerializeObject(Project);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
            if (!File.Exists(path))
                using (var stream = File.Create(path))
                {
                    stream.Close();
                }
            
            File.WriteAllText(path, text);
        }
    }
}