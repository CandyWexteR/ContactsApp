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

        public void AddContact(Contact contact)
        {
            _project.AddContact(contact);
        }

        public IReadOnlyList<Contact> GetSortedContacts()
        {
            return _project.Contacts.OrderBy(c => c.Name).OrderBy(c => c.Surname).ToList();
        }

        public void RemoveContact(int index)
        {
            _project.RemoveContact(index);
        }

        public void EditContact(int indexBefore, Contact after)
        {
            _project.EditContact(indexBefore, after);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Значение массива элементов типа Contact по его индексу</returns>
        public Contact GetContact(int id) => _project.Contacts[id];


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
            var text = JsonConvert.SerializeObject(_project);
            File.WriteAllText(path, text);
        }

        public void AddContact(string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            var last = _project.Contacts.LastOrDefault()?.Id ?? 0;
            var contact = Contact.Create(last + 1, surname, name, phoneNumber, birthday, email, idVk);
            _project.AddContact(contact);
        }
    }
}