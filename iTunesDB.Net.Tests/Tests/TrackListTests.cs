using System.Linq;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class TrackListTests : TestBase
    {
        [Test, Category("iTunesDb")]
        public void TrackList_TrackCount()
        {
            var rdrListContainer =
                Reader.Children.FirstOrDefault(r => ((ListContainer) (r.DbObject)).ListType == ListTypes.Tracks);
            var rdrTrackList = rdrListContainer.Children.FirstOrDefault();
            Assert.AreEqual(rdrTrackList.TotalSize, Db.Tracks.Count);
        }
    }
}
