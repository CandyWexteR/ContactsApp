using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс для номера телефона.
    /// Содержит поле Номер телефона типа Long
    /// </summary>
    public class PhoneNumber
    {
        private int _number;
        private int _code;

        public int NumberPhone { get => _number; set => _number = value; }
        public int Code { get => _code; set => _code = value; }
        
        public PhoneNumber(int number, int code)
        {
            NumberPhone = number;
            Code = code;
        }
    }
}
