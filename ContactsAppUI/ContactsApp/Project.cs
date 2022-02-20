using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Exceptions;

namespace ContactsApp
{
    public class Project
    {
        private List<Contact> _contacts;
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
            var last = Contacts.LastOrDefault()?.Id ?? 0;
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
        /// <param name="indexBefore">Индекс старого контакта</param>
        /// <param name="after">Новый контакт.</param>
        public void EditContact(Contact after)
        {
            var old = _contacts[after.Id];
            if (!_contacts.Contains(old))
                throw new InvalidEditOperationException("Редактирование несуществующего элемента.");

            _contacts[after.Id] = after;
        }
    }
}