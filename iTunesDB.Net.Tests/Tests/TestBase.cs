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
        private static string _dbFilePath;
        internal static MhbdReader Reader { get; set; }
        protected static iTunesDb Db { get; set; }

        [SetUp]
        public static void Setup()
        {
#if !ASYNC
            var pathToTestDirectory = TestContext.CurrentContext.TestDirectory;
            _dbFilePath = Path.Combine(pathToTestDirectory, "Data", "iTunesDB");

            Reader = new MhbdReader();
            Db = Reader.Open(_dbFilePath);
#endif
        }

        public static int DbFileSize => GetFileSize(_dbFilePath);

        public static int GetFileSize(string fileName)
        {
            return Convert.ToInt32(new FileInfo(fileName).Length);
        }

        public static string DbFileName => _dbFilePath;
    }
}
