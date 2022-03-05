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

        public IReadOnlyList<Contact> Contacts => _contacts;

        /// <summary>
        /// Добавление контакта.
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="phoneNumber">Номер телефона в формате <see cref="PhoneNumber"/></param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="email">Адрес электронной почты</param>
        /// <param name="idVk">Идентификатор профиля ВКонтакте</param>
        public void AddContact(string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            var last = Contacts.LastOrDefault()?.Id ?? -1;
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

            var toRemove = _contacts.FirstOrDefault(e=>e.Id == index);
            
            if (toRemove is null)
                throw new InvalidEditOperationException("Этого контакта нет в списке.");

            _contacts.Remove(toRemove);
        }

        /// <summary>
        /// Редактирование контакта: Находится старый контакт и заменяется новым экземпляром.
        /// </summary>
        public void EditContact(int id, string surname, string name, PhoneNumber phoneNumber, DateTime? birthday, string? email, string? idVk)
        {
            var old = _contacts.FirstOrDefault(c=>c.Id == id);
            if (old is null)
                throw new InvalidEditOperationException("Редактирование несуществующего элемента.");

            var contact = Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk);

            var index = _contacts.IndexOf(old);
            
            _contacts[index] = contact;
        }
    }
}