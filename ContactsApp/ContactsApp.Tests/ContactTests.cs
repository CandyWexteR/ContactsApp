using System;
using System.Linq;
using ContactsApp.Exceptions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ContactsApp.Tests;

public class ContactTests
{
    private static DateTime _previousDate;
    private static DateTime _forthcomingDate;
    [SetUp]
    public void Setup()
    {
        _previousDate = DateTime.Now.AddDays(-1);
        _forthcomingDate = DateTime.Now.AddDays(1);
    }
    
    [Test]
    [TestCase(1, "someName", "someSurname", null, null, null)]
    public void Contact_Valid(int id,string surname, string name, DateTime? birthday, string? email, string? idVk)
    {
        if (id < 0)
            Assert.Fail(("Идентификатор не может быть меньше 0"));

        if (string.IsNullOrWhiteSpace(surname))
            Assert.Fail(("Фамилия не может быть пустой строкой"));

        if (string.IsNullOrWhiteSpace(name))
            Assert.Fail(("Имя не может быть пустой строкой"));

        if (surname.Length > 50)
            Assert.Fail(("Длина фамилии не может быть больше 50 символов"));

        if (name.Length > 50)
            Assert.Fail(("Длина имени не может быть больше 50 символов"));

        if (idVk is not null && (idVk.Length > 15 || string.IsNullOrWhiteSpace(idVk)))
            Assert.Fail((
                    "Длина адреса ВКонтакте должна быть быть в диапазоне от 1 до 15 символов"));
            
        if (birthday is not null && birthday > DateTime.Now)
            Assert.Fail((
                    "День рождения должен быть указан не позднее текущей даты"));
            
        if (email is not null && (email.Length > 50 || string.IsNullOrWhiteSpace(email)))
            Assert.Fail((
                    "Длина адреса электронной почты должна быть быть в диапазоне от 1 до 50 символов"));
        
        var phoneNumber = PhoneNumber.Create(2569234220);
        
        var contact = Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk);
        
        Assert.AreEqual(id, contact.Id);
        Assert.AreEqual(surname, contact.Surname);
        Assert.AreEqual(name, contact.Name);
        Assert.AreEqual(birthday, contact.BirthDay);
        Assert.AreEqual(email, contact.Email);
        Assert.AreEqual(phoneNumber, contact.PhoneNumber);
        Assert.AreEqual(idVk, contact.IdVk);
    }
    
    [Test]
    [TestCase(-1, "someName", "someSurname", null, null, null)]
    public void Contact_Invalid(int id,string surname, string name, DateTime? birthday, string? email, string? idVk)
    {
        var expectedMessages = new string[]
        {
            "Идентификатор не может быть меньше 0",
            "Фамилия не может быть пустой строкой",
            "Имя не может быть пустой строкой",
            "Длина фамилии не может быть больше 50 символов",
            "Длина имени не может быть больше 50 символов",
            "Длина адреса ВКонтакте должна быть быть в диапазоне от 1 до 15 символов",
            "День рождения должен быть указан не позднее текущей даты",
            "Длина адреса электронной почты должна быть быть в диапазоне от 1 до 50 символов"
        };
        var phoneNumber = PhoneNumber.Create(2569234220);


        Assert.Catch<AggregateException>(() => Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk));

        try
        {
            var contact = Contact.Create(id, surname, name, phoneNumber, birthday, email, idVk);
        }
        catch (AggregateException e)
        {
            Assert.Greater(e.InnerExceptions.Count, 0);
            foreach (var item in e.InnerExceptions)
            {
                if (item is InvalidValueException ex)
                {
                    Assert.AreEqual(typeof(InvalidValueException), ex.GetType());
                    Assert.That(expectedMessages.Contains(ex.Message));
                    continue;
                }
                    
                Assert.Fail("Тип ошибки не соответствует ожиданию");

            }
        }
    }
}