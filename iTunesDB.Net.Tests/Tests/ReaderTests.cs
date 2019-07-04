using System;
using System.Linq;
using iTunesDB.Net.Readers;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class ReaderTests : TestBase
    {
        [Test, Category("Reader")]
        public void CanCreateKnownObjectID()
        {
            var obj = iTunesReader.CreateReader("mhbd", null);
            Assert.AreEqual("mhbd", obj.ObjectID);
            Assert.AreEqual(typeof(MhbdReader), obj.GetType());
        }

        [Test, Category("Reader")]
        public void CannotCreateUnknownObjectID()
        {
            Assert.That(() => iTunesReader.CreateReader("xxxx", null), Throws.TypeOf<ArgumentException>());
        }

        [Test, Category("Reader")]
        public void CanOpenAndParse()
        {
            Assert.AreEqual(453, Reader.AllChildren.Count());
        }
    }
}
