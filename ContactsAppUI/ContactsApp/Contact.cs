﻿using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact
    {
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
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Идентификатор социальной сети ВКонтакте
        /// </summary>
        public string? IdVk { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDay { get; set; }

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
        public static Contact Create(int id,string surname, string name, PhoneNumber phoneNumber, DateTime? birthday,
            string? email, string? idVk)
        {
            return new(id, surname, name, phoneNumber, birthday, email, idVk);
        }

        public Contact CopyContactInfo(int id)
        {
            return Create(id, Surname, Name, PhoneNumber, BirthDay, Email, IdVk);
        }
    }
}