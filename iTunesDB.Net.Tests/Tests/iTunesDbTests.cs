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
            Assert.AreEqual(20747208, Db.FileSize);
            Assert.AreEqual(DbFileSize, Db.FileSize);
        }

        [Test, Category("iTunesDb")]
        public void iTunesDb_Version()
        {
            Assert.AreEqual(new Version(1, 18, 3), Db.Version);
        }

        [Test, Category("iTunesDb")]
        public void iTunesDb_UnknownBytes()
        {
            Assert.AreEqual(80, Db.UnknownBytes.Length);
        }
    }
}
