using System.Linq;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class PlayListsTests : TestBase
    {
        [Test, Category("iTunesDb")]
        public void PlayLists_PlayListCount()
        {
            var rdrPLContainer =
                Reader.Children.FirstOrDefault(r => ((ListContainer) (r.DbObject)).ListType == ListTypes.PlayList);
            var rdrSPPLContainer = Reader.Children.FirstOrDefault(r =>
                ((ListContainer) (r.DbObject)).ListType == ListTypes.SpecialPodcastPlayList);
            var rdrPLContainerPlayLists = rdrPLContainer.Children.FirstOrDefault();
            var rdrSPPLContainerPlayLists = rdrSPPLContainer.Children.FirstOrDefault();
            Assert.AreEqual(rdrPLContainerPlayLists.TotalSize, Db.PlayLists.Count);
            Assert.AreEqual(rdrSPPLContainerPlayLists.TotalSize, Db.PlayLists.Count);
        }
    }
}
