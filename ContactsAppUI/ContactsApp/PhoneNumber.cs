using System.Text.Json.Serialization;
using ContactsApp.Exceptions;

namespace ContactsApp
{
    /// <summary>
    /// Класс для информации о номере телефона.
    /// </summary>
    public class PhoneNumber
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
        public long Number { get; set; }

        public static PhoneNumber Create(long number)
        {
            //79539244113
            //
            if (number is < 10000000000 or < 100000000000)
            {
                throw new InvalidValueException($"Неправильное значение {nameof(PhoneNumber)}.");
            }

            return new(number);
        }
    }
}
