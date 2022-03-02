using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ProjectManager
    {
        private Project? _project;

        //Для десериализации.
        [JsonConstructor]
        public ProjectManager(Project project)
        {
            _project = project;
        }

        public int ContactsCount => _project.Contacts.Count;

        public IReadOnlyList<Contact> GetSortedContacts()
        {
            return _project.Contacts.OrderBy(c => c.Name).OrderBy(c => c.Surname).ToList();
        }

        public void RemoveContact(int index)
        {
            _project.RemoveContact(index);
        }

        public void EditContact(Contact after)
        {
            _project.EditContact(after);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Значение массива элементов типа Contact по его индексу</returns>
        public Contact? GetContact(int id) => _project.Contacts.FirstOrDefault(c=>c.Id == id);


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
                _project = project;
            }
            else
            {
                _project = new Project(new List<Contact>());
                Serialize(path);
            }
        }

        public void Serialize(string path)
        {
            var directory = Path.GetDirectoryName(path);
            var text = JsonConvert.SerializeObject(_project);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
            if (!File.Exists(path))
                using (var stream = File.Create(path))
                {
                    stream.Close();
                }
            
            File.WriteAllText(path, text);
        }

        public void AddContact(string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            _project.AddContact(surname, name, phoneNumber, birthday, email, idVk);
        }
    }
}