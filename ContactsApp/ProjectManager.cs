using Newtonsoft.Json;
using System.IO;

namespace ContactsApp
{
    public class ProjectManager
    {
        private Project _project = new Project();

        public void AddContact(Contact contact)
        {
            _project.AddContact(contact);
        }

        public void SortContacts()
        {
            _project.SortContactList();
        }

        public void RemoveContact(int index)
        {
            _project.RemoveContact(index);
        }

        public int ContactsCount { get => _project.ContatsCount; }

        public void EditContact(Contact before, Contact after)
        {
            _project.EditContact(before, after);
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Значение массива элементов типа Contact по его индексу</returns>
        public Contact GetContact(int id) => _project.GetContact(id);


        public void Deserialize()
        {
            Project project = null;
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(@"D:\ContactsApp\ContactsApp\contacts.json"))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                project = serializer.Deserialize<Project>(reader);
            }

            _project.ContatsCount = project.ContatsCount;
            if (project.ContatsCount != 0)
            {
                _project.contact = project.contact;
            }
        }

        public void Serialize()
        {
            //Создаём экземпляр сериализатора
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(@"D:\ContactsApp\ContactsApp\contacts.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, _project);
            }
        }

    }
}