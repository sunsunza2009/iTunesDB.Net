using System;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class iTunesDbTests : TestBase
    {
        [Test, Category("iTunesDb")]
        public void iTunesDb_FileName()
        {
            Assert.AreEqual(DbFileName, Db.FileName);
        }

        [Test, Category("iTunesDb")]
        public void iTunesDb_FileSize()
        {
            Assert.AreEqual(57012, Db.FileSize);
            Assert.AreEqual(DbFileSize, Db.FileSize);
        }

        [Test, Category("iTunesDb")]
        public void iTunesDb_Version()
        {
            Assert.AreEqual(new Version(1, 115, 5), Db.Version);
        }

        [Test, Category("iTunesDb")]
        public void iTunesDb_UnknownBytes()
        {
            Assert.AreEqual(220, Db.UnknownBytes.Length);
        }
    }
}
