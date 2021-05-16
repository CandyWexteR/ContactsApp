using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта.
    /// Содержит поля Фамилия, Имя, номер телефона, дату рождения, эл. почту и ID ВКонтакте.
    /// </summary>
    public class Contact
    {
        private string _surename;
        private string _name;
        private PhoneNumber _phoneNumber = new PhoneNumber(0,0);
        private DateTime _birthday;
        private string _email;
        private string _idVk;

        public string Surename { get => this._surename; set => this._surename = value; }
        public string Name { get =>this._name; set => this._name = value; }
        public PhoneNumber Number { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => this._email;  set => this._email = value; }
        public string IdVk { get =>this._idVk; set => this._idVk = value;  }
        public DateTime BirthDay { get => this._birthday;  set => this._birthday = value; }
        public Contact(string surename, string name, PhoneNumber number, DateTime birthday, string email, string idVk)
        {
            Surename = surename;
            Name = name;
            Number = number;
            BirthDay = birthday;
            Email = email;
            IdVk = idVk;
        }

        public void CopyContactInfo(Contact contact)
        {
            Surename = contact.Surename;
            Name = contact.Name;
            Number = contact.Number;
            BirthDay = contact.BirthDay;
            Email = contact.Email;
            IdVk = contact.IdVk;
        }
    }
}
