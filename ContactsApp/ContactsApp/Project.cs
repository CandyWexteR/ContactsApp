using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Exceptions;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class Project
    {

        [JsonConstructor]
        public Project(List<Contact> contacts)
        {
            Contacts = contacts;
        }

        public List<Contact> Contacts { get; }

        public int ContactsCount => Contacts.Count;

        public Contact GetContact(int id) => Contacts.FirstOrDefault(c => c.Id == id);

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
                ? Contacts.OrderBy(c => $"{c.Surname.ToUpper()} {c.Name.ToUpper()}".Contains(nameSurnameFilter.ToUpper()) ||
                                         $"{c.Name} {c.Surname}".Contains(nameSurnameFilter) ||
                                         c.Name.Contains(nameSurnameFilter) || c.Surname.Contains(nameSurnameFilter))
                    .Skip((page - 1) * pageSize).Take(pageSize).ToList()
                : Contacts.OrderBy(c => $"{c.Surname} {c.Name}".Contains(nameSurnameFilter) ||
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
        public void AddContact(string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            var last = Contacts.LastOrDefault()?.Id ?? -1;
            var contact = Contact.Create(last + 1, surname, name, phoneNumber, birthday, email, idVk);
            Contacts.Add(contact);
        }

        /// <summary>
        /// Удаление контакта из списка.
        /// </summary>
        /// <param name="index"> - индекс удаляемого контакта.</param>
        public void RemoveContact(int index)
        {
            if (Contacts.Count == 0)
            {
                throw new InvalidEditOperationException("Невозможно удалить контакт из пустого списка.");
            }

            var toRemove = Contacts.FirstOrDefault(e => e.Id == index);

            if (toRemove is null)
                throw new InvalidEditOperationException("Этого контакта нет в списке.");

            Contacts.Remove(toRemove);
        }

        /// <summary>
        /// Редактирование контакта: Находится старый контакт и заменяется новым экземпляром.
        /// </summary>
        public void EditContact(int id, string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            var old = Contacts.FirstOrDefault(c => c.Id == id);
            if (old is null)
                throw new InvalidEditOperationException("Редактирование несуществующего элемента.");

            var contact = Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk);

            var index = Contacts.IndexOf(old);

            Contacts[index] = contact;
        }
    }
}