using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ContactsApp.Tests;

public class ContactTests
{
    public Contact Contact(int id,string surname, string name)
    {
        var phoneNumber = PhoneNumber.Create(2569234220);
        return ContactsApp.Contact.Create(id, surname, name, phoneNumber, null, null, null);
    }
    [Test]
    public void Contact_Valid()
    {
    }
}