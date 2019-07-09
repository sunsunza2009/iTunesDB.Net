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
        private static string _dbEmptyFilePath;

        internal static MhbdReader Reader { get; set; }
        internal static MhbdReader ReaderEmpty { get; set; }

        protected static iTunesDb Db { get; set; }
        protected static iTunesDb DbEmpty { get; set; }

        [SetUp]
        public static void Setup()
        {
#if !ASYNC
            var pathToTestDirectory = TestContext.CurrentContext.TestDirectory;
            var exportXmlFilePath = Path.Combine(pathToTestDirectory, "Data", "export.xml");
            _dbFilePath = Path.Combine(pathToTestDirectory, "Data", "iTunesDB");
            _dbEmptyFilePath = Path.Combine(pathToTestDirectory, "Data", "iTunesDB_Empty");

            Reader = new MhbdReader();
            ReaderEmpty = new MhbdReader();

            Db = Reader.Open(_dbFilePath);
            DbEmpty = ReaderEmpty.Open(_dbEmptyFilePath);

            ExportXml = File.ReadAllText(exportXmlFilePath).Replace(Environment.NewLine, "");
#endif
        }

        public static string ExportXml { get; private set; }

        public static int DbFileSize => GetFileSize(_dbFilePath);

        public static int DbEmptyFileSize => GetFileSize(_dbEmptyFilePath);

        public static int GetFileSize(string fileName)
        {
            return Convert.ToInt32(new FileInfo(fileName).Length);
        }

        public static string DbFileName => _dbFilePath;

        public static string DbEmptyFileName => _dbEmptyFilePath;
    }
}
