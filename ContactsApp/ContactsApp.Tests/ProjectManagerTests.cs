using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ContactsApp.Tests;

public class ProjectManagerTests
{
    private ProjectManager _manager;

    [Test]
    [TestCase(2)]
    public void Serialize(int count)
    {
        Assert.Greater(count, 0);
        var list = new List<Contact>();
        var number = 87485746352;
        var date = DateTime.Now;
        
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, date, null, null));
        }

        var project = new Project(list);

        _manager = new ProjectManager(project);

        var expected = JsonConvert.SerializeObject(project);

        _manager.Serialize();

        var file = File.ReadAllText(_manager.FullPath);

        Assert.AreEqual(expected, file);
    }

    [Test]
    [TestCase(4, "1231213123", "xcvcxvxcvcxv", null, "mail@example.com", "dsadasdad")]
    public void Deserialize_ValidPath(int count, string surname, string name, DateTime date, string email, string idVk)
    {
        Assert.Greater(count, 0);
        var list = new List<Contact>();
        var number = 87485746352;
        
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, surname, name, number, date, email, idVk));
        }

        var project = new Project(list);

        _manager = new ProjectManager(project);

        var expected = JsonConvert.SerializeObject(project);



        _manager.Serialize();

        _manager.Deserialize();

        foreach (var item in list)
        {
            var contact = _manager.Project.GetContact(item.Id);
            Assert.IsNotNull(contact);
            Assert.AreEqual(item.Id, contact.Id);
            Assert.AreEqual(item.BirthDay, contact.BirthDay);
            Assert.AreEqual(item.PhoneNumber.Number, contact.PhoneNumber.Number);
            Assert.AreEqual(item.Email, contact.Email);
            Assert.AreEqual(item.IdVk, contact.IdVk);
            Assert.AreEqual(item.Name, contact.Name);
            Assert.AreEqual(item.Surname, contact.Surname);
        }
    }

    [Test]
    [TestCase(2)]
    public void Deserialize_InvalidPath(int count)
    {
        Assert.Greater(count, 1);
        var list = new List<Contact>();
        var number = 87485746352;
        var date = DateTime.Now;
        
        for (var i = 0; i < count; i++)
        {
            list.Add(Contact.Create(i, $"Surname {i}", $"Name {i}", number, date, null, null));
        }
        _manager = new ProjectManager(new Project(list));
        _manager.ChangeFilename(Path.GetRandomFileName());
        _manager.Deserialize();
        Assert.AreEqual(0, _manager.Project.ContactsCount);
        var file = File.ReadAllText(Path.Combine(_manager.FullPath));
        var text = JsonConvert.SerializeObject(new Project(new List<Contact>()));
        Assert.AreEqual(text, file);
    }
}