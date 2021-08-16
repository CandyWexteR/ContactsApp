
using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Exceptions;

namespace ContactsApp
{
    public class Project
    {
        private List<Contact> _contacts { get; set; }
        public Project(List<Contact> contacts)
        {
            _contacts = contacts;
        }


        /// <summary>
        /// Добавление контакта.
        /// </summary>
        /// <param name="newContact"> - добавляемый контакт.</param>
        public void AddContact(Contact newContact)
        {
            _contacts.Add(newContact);
        }


        /// <summary>
        /// Сортирует по алфавиту контакты по указанному полю.
        /// </summary>
        public IReadOnlyList<Contact> SortContactList(Func<Contact,string> keySelector)
        {
            return _contacts.OrderBy(keySelector).ToList();
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

            var toRemove = _contacts[index];
            
            if (!_contacts.Contains(toRemove))
                throw new InvalidEditOperationException("Контакта уже нет в списке.");

            _contacts.Remove(toRemove);
        }

        /// <summary>
        /// Редактирование контакта: Находится старый контакт и заменяется новым экземпляром.
        /// </summary>
        /// <param name="indexBefore">Индекс старого контакта</param>
        /// <param name="after">Новый контакт.</param>
        public void EditContact(int indexBefore, Contact after)
        {
            var old = _contacts[indexBefore];
            if (!_contacts.Contains(old))
                throw new InvalidEditOperationException("Редактирование несуществующего элемента.");

            _contacts[indexBefore] = after;
        }
    }
}