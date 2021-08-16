
namespace ContactsApp
{
    public class Project
    {

        private static int _contactsCount = 0;
        private Contact[] _contact;

        public Contact[] contact { get => _contact; set => _contact = value; }
        public int ContatsCount { get => _contactsCount; set => _contactsCount = value; }

        /// <summary>
        /// Добавление контакта:
        /// Создается временный массив данных типа Contact
        /// с количеством _contactsCount+1.
        /// Копируются значения из основного массива в новый.
        /// В последний элемент добавляется добавляемое значение.
        /// Старый массив заменяется новым, общее количество контактов
        /// увеличено на 1.
        /// </summary>
        /// <param name="newContact"> - добавляемый контакт.</param>
        public void AddContact(Contact newContact)
        {
            Contact[] temp = new Contact[_contactsCount + 1];
            for (int i = 0; i < _contactsCount; i++)
            {
                temp[i] = _contact[i];
            }

            temp[_contactsCount] = newContact;
            _contactsCount++;
            _contact = temp;
        }


        //Сортировка взята с:
        //https://www.cyberforum.ru/csharp-beginners/thread377059.html
        /// <summary>
        /// Сортирует по алфавиту контакты.
        /// </summary>
        public void SortContactList()
        {
            string[] personSurnameAndName = new string[_contactsCount];
            for (int i = 0; i < _contactsCount; i++)
            {
                personSurnameAndName[i] = _contact[i].Surname;
                personSurnameAndName[i] += " ";
                personSurnameAndName[i] += _contact[i].Name;
            }
            for (int i = 0; i < personSurnameAndName.Length; i++)
            {
                for (int j = 0; j < personSurnameAndName.Length - 1; j++)
                {
                    if (needToReOrder(personSurnameAndName[j], personSurnameAndName[j + 1]))
                    {
                        string s = personSurnameAndName[j];
                        personSurnameAndName[j] = personSurnameAndName[j + 1];
                        personSurnameAndName[j + 1] = s;
                        Contact temp = _contact[j];
                        _contact[j] = _contact[j + 1];
                        _contact[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Сравнивает ASCII коды строк.
        /// </summary>
        /// <param name="s1">Первая строка</param>
        /// <param name="s2">Вторая строка</param>
        /// <returns>true - нужно, false - нет</returns>
        protected static bool needToReOrder(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        /// <summary>
        /// Удаление контакта:
        /// Создается новый массив элементов типа Contact
        /// с количеством значений _contactsCount-1.
        /// Переносятся все значения, кроме удаляемого.
        /// Количество уменьшается на 1.
        /// </summary>
        /// <param name="index"> - индекс удаляемого контакта.</param>
        public void RemoveContact(int index)
        {
            if (ContatsCount == 1)
            {
                _contactsCount = 0;
                _contact = null;
                return;
            }
            Contact[] temp = new Contact[ContatsCount - 1];
            for (int i = 0; i < index; i++)
            {
                temp[i] = _contact[i];
            }
            for (int i = index; i < ContatsCount - 1; i++)
            {
                temp[i] = _contact[i + 1];
            }
            _contact = temp;
            _contactsCount--;
        }

        /// <summary>
        /// Редактирование контакта:
        /// Находится старый контакт и заменяется
        /// новым экземпляром.
        /// </summary>
        /// <param name="before"> - старый контакт.</param>
        /// <param name="after"> - новый контакт.</param>
        public void EditContact(Contact before, Contact after)
        {
            for (int i = 0; i < _contactsCount; i++)
            {
                if (_contact[i] == before)
                {
                    _contact[i] = after;
                    break;
                }
            }
        }
        public Contact GetContact(int id) => _contact[id];

    }
}