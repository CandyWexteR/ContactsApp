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
        [System.Text.Json.Serialization.JsonConstructor]
        public ProjectManager(Project project)
        {
            _project = project;
        }

        public int ContactsCount => _project.Contacts.Count;

        public void AddContact(Contact contact)
        {
            _project.AddContact(contact);
        }

        public IReadOnlyList<Contact> GetSortedContacts(Func<Contact, string> keySelector)
        {
            return _project.Contacts.OrderBy(keySelector).ToList();
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


        public void Deserialize()
        {
            Project? project = null;
            //Создаём экземпляр сериализатора
            var serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (var sr = new StreamReader(@"D:\ContactsAppVS\ContactsAppVS\contacts.json"))
            using (var reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                project = serializer.Deserialize<Project>(reader);
            }

            if (project != null)
            {
                _project = project;
            }
            else
            {
                _project = new Project(new List<Contact>());
            }
        }

        public void Serialize()
        {
            //Создаём экземпляр сериализатора
            var serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (var sw = new StreamWriter(@"D:\ContactsAppVS\ContactsAppVS\contacts.json"))
            using (var writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, _project);
            }
        }
    }
}