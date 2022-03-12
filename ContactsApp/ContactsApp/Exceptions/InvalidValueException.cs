using System;

namespace ContactsApp.Exceptions
{
    /// <summary>
    /// Возникает при вводе неверного значения в объект бизнес-логики
    /// </summary>
    public class InvalidValueException:Exception
    {
        /// <summary>
        /// Создать экземпляр исключения <see cref="InvalidValueException"/>
        /// </summary>
        /// <param name="message"></param>
        public InvalidValueException(string message):base(message)
        {
            
        }
    }
}