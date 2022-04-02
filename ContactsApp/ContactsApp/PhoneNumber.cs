using System;
using ContactsApp.Exceptions;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс для информации о номере телефона.
    /// </summary>
    public class PhoneNumber:IEquatable<PhoneNumber>
    {
        //Означает, что этот конструктор будет использоваться для десериализации.
        [JsonConstructor]
        protected PhoneNumber(long number)
        {
            Number = number;
        }
        
        /// <summary>
        /// Номер телефона.
        /// </summary>
        public long Number { get; protected set; }

        public static PhoneNumber Create(long number)
        {
            //85746354637
            if (number < 80000000000 || number >= 90000000000)
            {
                throw new InvalidValueException($"Неправильное значение номера телефона. Номер должен начинаться" +
                                                $"с 8 и должен состоять из 11 символов.");
            }

            return new(number);
        }

        public bool Equals(PhoneNumber other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PhoneNumber)obj);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
