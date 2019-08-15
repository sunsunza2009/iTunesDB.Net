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
        private static string _dbNanoPodFilePath;
        private static string _dbEmptyFilePath;

        internal static MhbdReader Reader { get; set; }
        internal static MhbdReader ReaderNanoPod { get; set; }
        internal static MhbdReader ReaderEmpty { get; set; }

        protected static iTunesDb Db { get; set; }
        protected static iTunesDb DbNanoPod { get; set; }
        protected static iTunesDb DbEmpty { get; set; }

        [SetUp]
        public static void Setup()
        {
#if !ASYNC
            var pathToTestDirectory = TestContext.CurrentContext.TestDirectory;
            _dbFilePath = Path.Combine(pathToTestDirectory, "Data", "iTunesDB");
            _dbNanoPodFilePath = Path.Combine(pathToTestDirectory, "Data", "iTunesDB_NanoPod");
            _dbEmptyFilePath = Path.Combine(pathToTestDirectory, "Data", "iTunesDB_Empty");

            Reader = new MhbdReader();
            ReaderEmpty = new MhbdReader();
            ReaderNanoPod = new MhbdReader();

            Db = Reader.Open(_dbFilePath);
            DbEmpty = ReaderEmpty.Open(_dbEmptyFilePath);
//            DbNanoPod = ReaderNanoPod.Open(_dbNanoPodFilePath);
#endif
        }

        public static int DbFileSize => GetFileSize(_dbFilePath);

        public static int DbNanoPodFileSize => GetFileSize(_dbNanoPodFilePath);

        public static int DbEmptyFileSize => GetFileSize(_dbEmptyFilePath);

        public static int GetFileSize(string fileName)
        {
            return Convert.ToInt32(new FileInfo(fileName).Length);
        }

        public static string DbFileName => _dbFilePath;

        public static string DbNanoPodFileName => _dbNanoPodFilePath;

        public static string DbEmptyFileName => _dbEmptyFilePath;
    }
}
