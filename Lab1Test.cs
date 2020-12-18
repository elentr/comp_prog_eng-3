using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.FileWorker;
using System;
using System.IO;

namespace comp_prog_eng_3
{
    [TestClass]
public class Lab1_FileWorkerTests
{
    private static string pathToLabFolder = "/ œ≤-3/Tretyak/comp_prog_eng_3/lab1/testfiles";
    private static Random rand = new Random(DateTime.Now.Second);

    static private string RandName(string prefix)
    {
        return prefix + rand.Next();
    }

    [ClassInitialize]
    public static void BeforeAllTests(TestContext testContext)
    {
        if (Directory.Exists(pathToLabFolder))
        {
            Directory.Delete(pathToLabFolder, true);
        }
        Directory.CreateDirectory(pathToLabFolder);
    }

    [TestMethod]
    public void Write_MultiFiles_CreateIfNotExist_ReturnTrue()
    {
        string[] arrayExt = { "txt", "xml" };
        string text = "some text\nsome text\nsome text";
        foreach (string ext in arrayExt)
        {
            Boolean result = BaseFileWorker.Write(text, pathToLabFolder + "/somefile." + ext);

            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    public void Write_MultiFiles_RewriteIfExist_ReturnTrue()
    {
        string[] arrayExt = { "txt", "xml" };
        string text = "some text 1\nsome text 2\nsome text 3";
        foreach (string ext in arrayExt)
        {
            Boolean result = BaseFileWorker.Write(text, pathToLabFolder + "/somefile." + ext);

            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    public void GetFileName_FileExists_ReturnFileName()
    {
        string result = BaseFileWorker.GetFileName(pathToLabFolder + "/somefile.txt");

        Assert.AreEqual("somefile.txt", result);
    }

    [TestMethod]
    public void GetFileName_FileNotExists_ReturnNull()
    {
        string result = BaseFileWorker.GetFileName(pathToLabFolder + "/somefile2.txt");

        Assert.AreEqual(null, result);
    }

    [TestMethod]
    public void GetFilePath_FileExists_ReturnFileName()
    {
        string result = BaseFileWorker.GetFullPath(pathToLabFolder + "/somefile.txt");

        Assert.AreEqual(pathToLabFolder + "/somefile.txt", result);
    }

    [TestMethod]
    public void GetFilePath_FileNotExists_ReturnNull()
    {
        string result = BaseFileWorker.GetFullPath(pathToLabFolder + "/somefile2.txt");

        Assert.AreEqual(null, result);
    }

    [TestMethod]
    public void GetPath_FileExists_ReturnPathToFile()
    {
        string result = BaseFileWorker.GetPath(pathToLabFolder + "/somefile.txt");

        Assert.AreEqual(pathToLabFolder, result);
    }

    [TestMethod]
    public void GetPath_FileNotExists_ReturnNull()
    {
        string result = BaseFileWorker.GetPath(pathToLabFolder + "/somefile2.txt");

        Assert.AreEqual(null, result);
    }

    [TestMethod]
    public void MkDir_ReturnFolderPath()
    {
        string name = Lab1_FileWorkerTests.RandName("somefolder");

        // Create new folder
        string result = BaseFileWorker.MkDir(pathToLabFolder + "/" + name);

        Assert.AreEqual(pathToLabFolder + "/" + name, result);

        // Return exists folder
        result = BaseFileWorker.MkDir(pathToLabFolder + "/" + name);

        Assert.AreEqual(pathToLabFolder + "/" + name, result);
    }

}