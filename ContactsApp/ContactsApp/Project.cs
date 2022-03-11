#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Exceptions;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class Project
    {
        private List<Contact> _contacts;

        [JsonConstructor]
        public Project(List<Contact> contacts)
        {
            _contacts = contacts;
        }

        public int ContactsCount => _contacts.Count;

        public IReadOnlyList<Contact> Contacts
        {
            get => _contacts;
            protected set
            {
                _contacts = new List<Contact>();
                _contacts.AddRange(value);
            }
        }

        public Contact? GetContact(int id) => _contacts.FirstOrDefault(c => c.Id == id);

        /// <summary>
        /// Получение списка контактов по заданному фильтру
        /// </summary>
        /// <param name="nameSurnameFilter">Фильтр по имени и фамилии. Проверяется на наличие в строках:
        /// "{ФАМИЛИЯ}", "{ИМЯ}", "{ФАМИЛИЯ} {ИМЯ}", "{ИМЯ} {ФАМИЛИЯ}"</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IReadOnlyList<Contact> GetSortedContacts(string nameSurnameFilter, int page, int pageSize) =>
            pageSize > 0 && page > 0
                ? _contacts.OrderBy(c => $"{c.Surname} {c.Name}").Where(c =>
                        $"{c.Surname.ToUpper()} {c.Name.ToUpper()}".Contains(nameSurnameFilter.ToUpper()) ||
                        $"{c.Name} {c.Surname}".Contains(nameSurnameFilter) ||
                        c.Name.Contains(nameSurnameFilter) || c.Surname.Contains(nameSurnameFilter))
                    .Skip((page - 1) * pageSize).Take(pageSize).ToList()
                : _contacts.OrderBy(c => $"{c.Surname} {c.Name}").Where(c =>
                        $"{c.Surname} {c.Name}".Contains(nameSurnameFilter) ||
                        $"{c.Name} {c.Surname}".Contains(nameSurnameFilter) ||
                        c.Name.Contains(nameSurnameFilter) || c.Surname.Contains(nameSurnameFilter))
                    .ToList();

        /// <summary>
        /// Добавление контакта.
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="phoneNumber">Номер телефона в формате <see cref="PhoneNumber"/></param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="email">Адрес электронной почты</param>
        /// <param name="idVk">Идентификатор профиля ВКонтакте</param>
        public void AddContact(string surname, string name, PhoneNumber phoneNumber, DateTime birthday,
            string email, string idVk)
        {
            var last = _contacts.LastOrDefault()?.Id ?? -1;
            var contact = Contact.Create(last + 1, surname, name, phoneNumber, birthday, email, idVk);
            _contacts.Add(contact);
        }

        /// <summary>
        /// Удаление контакта из списка.
        /// </summary>
        /// <param name="index"> - индекс удаляемого контакта.</param>
        public void RemoveContact(int index)
        {
            if (_contacts.Count == 0)
            {
                throw new InvalidEditOperationException("Невозможно удалить контакт из пустого списка.");
            }

            var toRemove = _contacts.FirstOrDefault(e => e.Id == index);
            if (toRemove is null)
                throw new InvalidEditOperationException("Этого контакта нет в списке.");

            _contacts.Remove(toRemove);
        }

        /// <summary>
        /// Редактирование контакта: Находится старый контакт и заменяется новым экземпляром.
        /// </summary>
        public void EditContact(int id, string surname, string name, PhoneNumber phoneNumber, DateTime birthday,
            string email, string idVk)
        {
            var old = _contacts.FirstOrDefault(c => c.Id == id);
            if (old is null)
                throw new InvalidEditOperationException("Редактирование несуществующего элемента.");

            var contact = Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk);
            var index = _contacts.IndexOf(old);
            _contacts[index] = contact;
        }
    }
}