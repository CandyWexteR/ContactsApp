using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ContactsApp.Tests;

[TestFixture]
public class ProjectManagerTests
{
    private ProjectManager GetManager() => new ProjectManager(new Project(new List<Contact>()));
    public string TestFileName => "test.json";
    public string TestFolderName => "testJson";

    [Test]
    [TestCase(2)]
    public void Serialize(int count)
    {
        // Setup
        var manager = GetManager();
        var number = 87485746352;
        var date = DateTime.Now;

        for (var i = 0; i < count; i++)
        {
            manager.Project.AddContact($"Surname {i}", $"Name {i}", number, date, null, null);
        }

        var expected = JsonConvert.SerializeObject(manager.Project);

        // Act
        manager.Serialize();

        // Assert
        var file = File.ReadAllText(manager.FullPath);

        Assert.AreEqual(expected, file);
    }

    [Test]
    [TestCase(23)]
    public void Deserialize_ValidPath(int count)
    {
        // Setup
        var number = 87485746352;
        var date = DateTime.Now;

        var manager = GetManager();
        var project = new Project(new List<Contact>());
        for (var i = 0; i < count; i++)
        {
            project.AddContact($"Surname {i}", $"Name {i}", number, date, null, null);
        }

        var validPath = Path.Combine(Directory.GetCurrentDirectory(), TestFolderName, TestFileName);
        var json = JsonConvert.SerializeObject(project);
        SaveTextInFile(json, validPath);

        // Act
        manager.Deserialize(validPath);

        // Assert
        Assert.Greater(manager.Project.ContactsCount, 0);
        foreach (var actual in project.Contacts)
        {
            var expected = project.Contacts.First(f => f.Id == actual.Id);
            Assert.AreEqual(expected, actual);
        }

        var dir = Path.GetDirectoryName(validPath);

        if (File.Exists(validPath))
            File.Delete(validPath);

        if (Directory.Exists(dir))
            Directory.Delete(dir);
    }

    [Test]
    [TestCase("TestFolder")]
    [TestCase(null)]
    public void Deserialize_InvalidPath(string testFolder)
    {
        // Setup
        var invalidPath = string.IsNullOrEmpty(testFolder)
            ? Path.Combine(Directory.GetCurrentDirectory(), Path.GetRandomFileName())
            : Path.Combine(Directory.GetCurrentDirectory(), testFolder, Path.GetRandomFileName());
        var expected = JsonConvert.SerializeObject(new Project(new List<Contact>()));
        var manager = GetManager();

        // Act
        manager.Deserialize(invalidPath);

        // Assert
        var actual = JsonConvert.SerializeObject(manager.Project);
        Assert.AreEqual(0, manager.Project.ContactsCount);
        Assert.AreEqual(expected, actual);

        var dir = Path.GetDirectoryName(invalidPath);

        if (File.Exists(invalidPath) && !string.IsNullOrEmpty(testFolder))
            File.Delete(invalidPath);

        if (Directory.Exists(dir) && !string.IsNullOrEmpty(testFolder))
            Directory.Delete(dir);
    }

    [Test]
    [TestCase("123123")]
    [TestCase(null)]
    public void Deserialize_InvalidFile(string testFolder)
    {
        // Setup
        var expected = JsonConvert.SerializeObject(new Project(new List<Contact>()));
        var path = string.IsNullOrEmpty(testFolder)
            ? Path.Combine(Directory.GetCurrentDirectory(), Path.GetRandomFileName())
            : Path.Combine(Directory.GetCurrentDirectory(), testFolder, Path.GetRandomFileName());
        var brokenFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "json", "broken.json");
        var brokenFileText = File.ReadAllText(brokenFilePath);
        SaveTextInFile(brokenFileText, path);
        var manager = GetManager();

        // Act
        manager.Deserialize(path);

        // Assert
        var actual = JsonConvert.SerializeObject(manager.Project);
        Assert.AreEqual(expected, actual);

        var dir = Path.GetDirectoryName(path);

        if (File.Exists(path))
            File.Delete(path);

        if (Directory.Exists(dir) && !string.IsNullOrEmpty(testFolder))
            Directory.Delete(dir);
    }

    private void SaveTextInFile(string text, string path)
    {
        var dir = Path.GetDirectoryName(path);
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (!File.Exists(path))
            using (var stream = File.Create(path))
            {
                stream.Close();
            }

        File.WriteAllText(path, text);
    }
}