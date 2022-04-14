using System;
using System.Collections.Generic;
using System.Linq;
using ContactsApp.Exceptions;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта.
    /// </summary>
    public class Contact : ICloneable, IEquatable<Contact>
    {
        [JsonConstructor]
        protected Contact(int id, string surname, string name, PhoneNumber phoneNumber, DateTime birthday,
            string email, string idVk)
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
        public string Email { get; protected set; }

        /// <summary>
        /// Идентификатор социальной сети ВКонтакте
        /// </summary>
        public string IdVk { get; protected set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; protected set; }

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
        public static Contact Create(int id, string surname, string name, long phoneNumber, DateTime birthday,
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

            if (!string.IsNullOrWhiteSpace(email))
            {
                var emailMessage = "Адрес электронной почты должен вводиться в формате user.mail@mail.domain.ru";
                if (email.Contains("@"))
                {
                    var str = email.Split('@').Last();
                    if (!str.Contains("."))
                    {
                        exceptions.Add(new InvalidValueException(emailMessage));
                    }
                }
                else
                {
                    exceptions.Add(new InvalidValueException(emailMessage));
                }

                if (email.Length > 50)
                    exceptions.Add(new InvalidValueException(
                        "Длина адреса электронной почты должна быть быть в диапазоне от 1 до 50 символов"));
            }

            PhoneNumber phone = null;

            try
            {
                phone = PhoneNumber.Create(phoneNumber);
            }
            catch (InvalidValueException e)
            {
                exceptions.Add(e);
            }


            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);

            return new Contact(id, surname, name, phone, birthday, email, idVk);
        }

        public object Clone()
        {
            return new Contact(Id, Surname, Name, PhoneNumber, BirthDay, Email, IdVk);
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && 
                   Surname == other.Surname && 
                   Name == other.Name &&
                   Equals(PhoneNumber, other.PhoneNumber) && 
                   Email == other.Email && 
                   IdVk == other.IdVk &&
                   BirthDay.Equals(other.BirthDay);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Contact)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Surname != null ? Surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (IdVk != null ? IdVk.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ BirthDay.GetHashCode();
                return hashCode;
            }
        }
    }
}