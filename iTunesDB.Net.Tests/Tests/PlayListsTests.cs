using System;
using System.ComponentModel;
using System.Linq;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class PlayListsTests : TestBase
    {
        [Test, NUnit.Framework.Category("iTunesDb")]
        public void PlayLists_PlayListCount()
        {
//            var rdrPLContainer =
//                Reader.Children.FirstOrDefault(r => ((ListContainer) r.DbObject).ListType == ListTypes.PlayList);
//            var rdrSPPLContainer = Reader.Children.FirstOrDefault(r =>
//                ((ListContainer) r.DbObject).ListType == ListTypes.SpecialPodcastPlayList);
//            var rdrPLContainerPlayLists = rdrPLContainer.Children.FirstOrDefault();
//            var rdrSPPLContainerPlayLists = rdrSPPLContainer.Children.FirstOrDefault();
//            Assert.AreEqual(rdrPLContainerPlayLists.TotalSize, Db.PlayLists.Count);
//            Assert.AreEqual(rdrSPPLContainerPlayLists.TotalSize, Db.PlayLists.Count);
        }

        [Test, NUnit.Framework.Category("iTunesDb")]
        public void PlayLists_Albums()
        {
            //var listContainer = Db.ListContainers.Single(l => l.ListType == ListTypes.Albums);
        }

        [Test, NUnit.Framework.Category("iTunesDb")]
        public void PlayLists_Artists()
        {
            //var listContainer = Db.ListContainers.Single(l => l.ListType == ListTypes.Artists);
        }

        [Test, NUnit.Framework.Category("iTunesDb")]
        public void PlayLists_Tracks()
        {
            var listContainer = Db.ListContainers.Single(l => l.ListType == ListTypes.Tracks);
            var trackList = (TrackList) listContainer[0];

            Assert.AreEqual(25, trackList.Count);
        }

        [Test, NUnit.Framework.Category("iTunesDb")]
        public void PlayLists_SmartPlayList()
        {
            var listContainer = Db.ListContainers.Single(l => l.ListType == ListTypes.SmartPlayList);
            var playlists = (PlayLists) listContainer[0];

            Assert.AreEqual(4, playlists.Count);

            // 1. Playlist -> Filme
            var playList = (PlayList) playlists[0];

            Assert.AreEqual("Filme", playList.Name);

            // 2. Playlist -> Filme
            playList = (PlayList) playlists[1];

            Assert.AreEqual("Hörbücher", playList.Name);

            // 3. Playlist -> TV-Sendungen
            playList = (PlayList) playlists[2];

            Assert.AreEqual("Musik", playList.Name);

            // 4. Playlist -> Hörbücher
            playList = (PlayList) playlists[3];

            Assert.AreEqual("TV-Sendungen", playList.Name);
        }

        [Test, NUnit.Framework.Category("iTunesDb")]
        public void PlayLists_PlayList()
        {
            var listContainer = Db.ListContainers.Single(l => l.ListType == ListTypes.PlayList);
            var playlists = (PlayLists) listContainer[0];

            Assert.AreEqual(2, playlists.Count);

            // 1. PlayList -> "MasterPlaylist"
            var playList = (PlayList) playlists[0];

            Assert.AreEqual("iPod von Klaus Moster", playList.Name);
            Assert.AreEqual(19, playList.DataObjectChildCount);
            Assert.AreEqual(25, playList.PlaylistItemCount);
            Assert.IsTrue(playList.IsMasterPlaylist);
            //Assert.AreEqual(3, playList.Unk);
            Assert.AreEqual(new DateTime(2019, 7, 1, 12, 48, 7), playList.Timestamp);
            Assert.AreEqual(676597550, playList.PersistentPlaylistId);
            Assert.AreEqual(-818757207, playList.Unk3);
            Assert.AreEqual(0, playList.StringMhodCount);
            Assert.AreEqual(0, playList.PodcastFlag);
            Assert.AreEqual(ListSortDirection.Descending, playList.ListSortOrder);

            // 2. PlayList -> "Playlist Test"
            playList = (PlayList) playlists[1];

            Assert.AreEqual("Playlist Test", playList.Name);
            Assert.AreEqual(3, playList.DataObjectChildCount);
            Assert.AreEqual(4, playList.PlaylistItemCount);
            Assert.IsFalse(playList.IsMasterPlaylist);
            //Assert.AreEqual(3, playList.Unk);
            Assert.AreEqual(new DateTime(2019, 7, 2, 13, 54, 42), playList.Timestamp);
            Assert.AreEqual(1702470952, playList.PersistentPlaylistId);
            Assert.AreEqual(-1141886561, playList.Unk3);
            Assert.AreEqual(0, playList.StringMhodCount);
            Assert.AreEqual(0, playList.PodcastFlag);
            Assert.AreEqual(ListSortDirection.Descending, playList.ListSortOrder);
        }

//        [Test, NUnit.Framework.Category("iTunesDb")]
//        public void PlayLists_SpecialPodcastPlayList()
//        {
//            var listContainer = Db.ListContainers.Single(l => l.ListType == ListTypes.SpecialPodcastPlayList);
//            var playlists = (PlayLists) listContainer[0];
//
//            Assert.AreEqual(2, playlists.Count);
//        }
    }
}
