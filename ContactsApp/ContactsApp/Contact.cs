using System;
using System.Collections.Generic;
using ContactsApp.Exceptions;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact : ICloneable
    {
        [JsonConstructor]
        protected Contact(int id, string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            Surname = surname;
            Name = name;
            PhoneNumber = phoneNumber;
            BirthDay = birthday;
            Email = email;
            IdVk = idVk;
            Id = id;
        }

        /// <summary>
        /// Идентификатор контакта.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; protected set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get; protected set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string? Email { get; protected set; }

        /// <summary>
        /// Идентификатор социальной сети ВКонтакте
        /// </summary>
        public string? IdVk { get; protected set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDay { get; protected set; }

        /// <summary>
        /// Создать новый контакт.
        /// </summary>
        /// <param name="id">Идентификатор контакта.</param>
        /// <param name="surname">Фамилия. Обязательное поле. Не больше 50 символов.</param>
        /// <param name="name">Имя. Обязательное поле. Не больше 50 символов.</param>
        /// <param name="phoneNumber">Класс номера телефона. Обязательное поле.</param>
        /// <param name="birthday">Дата рождения. Может быть null.</param>
        /// <param name="email">Электронная почта.</param>
        /// <param name="idVk">Идентификатор ВКонтакте.</param>
        /// <returns>Экземпляр контакта(<see cref="Contact"/>).</returns>
        public static Contact Create(int id, string surname, string name, PhoneNumber phoneNumber, DateTime birthday,
            string email, string idVk)
        {
            var exceptions = new List<InvalidValueException>();
            if (id < 0)
                exceptions.Add(new InvalidValueException("Идентификатор не может быть меньше 0"));

            if (string.IsNullOrWhiteSpace(surname))
            {
                exceptions.Add(new InvalidValueException("Фамилия не может быть пустой строкой"));
            }
            else if (surname.Length > 50)
            {
                exceptions.Add(new InvalidValueException("Длина фамилии не может быть больше 50 символов"));
            }


            if (string.IsNullOrWhiteSpace(name))
            {
                exceptions.Add(new InvalidValueException("Имя не может быть пустой строкой"));
            }
            else if (name.Length > 50)
            {
                exceptions.Add(new InvalidValueException("Длина имени не может быть больше 50 символов"));
            }


            if (!string.IsNullOrWhiteSpace(idVk) && (idVk.Length > 15 || string.IsNullOrWhiteSpace(idVk)))
                exceptions.Add(
                    new InvalidValueException(
                        "Длина адреса ВКонтакте должна быть быть в диапазоне от 1 до 15 символов"));

            if (birthday > DateTime.Now)
                exceptions.Add(new InvalidValueException("День рождения должен быть указан не позднее текущей даты"));

            if (!string.IsNullOrWhiteSpace(email) && (email.Length > 50 || string.IsNullOrWhiteSpace(email)))
                exceptions.Add(new InvalidValueException(
                        "Длина адреса электронной почты должна быть быть в диапазоне от 1 до 50 символов"));

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);

            return new Contact(id, surname, name, phoneNumber, birthday, email, idVk);
        }

        public object Clone()
        {
            return new Contact(Id, Surname, Name, PhoneNumber, BirthDay, Email, IdVk);
        }
    }
}