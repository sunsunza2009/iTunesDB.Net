using System;
using System.IO;
using iTunesDB.Net.Writers;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class iTunesDbWriterTests
    {
        [TestFixture]
        public class WithFilledDb : TestBase
        {
            [Test, Category("iTunesDb")]
            public void WriteToFile()
            {
            }
        }

        [TestFixture]
        public class WithEmptyDb : TestBase
        {
            [Test, Category("iTunesDb")]
            public void WriteToFile()
            {
                var writer = new iTunesWriter();
                var file = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "iTunesDb_Test");

                writer.Write(DbEmpty, file);
            }
        }
    }
}
