using System;
using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Readers;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class TestBase
    {
        //public const string PATH = "F:\\iPod_Control\\iTunes\\";
        public const string DbFilePath = "..\\..\\Data\\";
        public TestContext TestContext { get; set; }
        internal static MhbdReader Reader { get; set; }
        public static iTunesDb Db { get; set; }

        [SetUp]
        public static void AssemblyInitialize()
        {
#if !ASYNC
            Reader = new MhbdReader();
            Db = Reader.Open(DbFilePath + "iTunesDB");
#endif
        }

        public static int DbFileSize
        {
            get { return GetFileSize(DbFilePath + "iTunesDB"); }
        }

        public static int GetFileSize(string FileName)
        {
            return Convert.ToInt32(new FileInfo(FileName).Length);
        }

        public static string DbFileName
        {
            get { return DbFilePath + "iTunesDB"; }
        }
    }
}
