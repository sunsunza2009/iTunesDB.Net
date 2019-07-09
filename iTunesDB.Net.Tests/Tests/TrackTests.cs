using System;
using System.Linq;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using NUnit.Framework;

namespace iTunesDB.Net.Tests
{
    [TestFixture]
    public class TrackTests
    {
        [TestFixture]
        public class WithFilledDb : TestBase
        {
            [Test, Category("iTunesDb")]
            public void Tracks()
            {
                // This test validates "AC/DC - Rock or Bust" from the Playlist

                var playlists = Db.PlayLists.Cast<PlayList>().ToArray();
                var playlist = playlists.FirstOrDefault(p => p.Name == "Playlist Test");

                Assert.IsTrue(playlist != null);
                Assert.AreEqual(4, playlist.Count);

                var trackId = playlist[0].TrackId;
                var track = Db.Tracks.Cast<Track>().First(t => t.TrackID == trackId);

                Assert.AreEqual(9, track.NumberOfStrings);
                Assert.AreEqual(4951, track.TrackID);
                Assert.AreEqual(true, track.Visible);
                Assert.AreEqual("MP3", track.FileType);
                Assert.AreEqual(CodingFormats.Mp3Vbr, track.CodingFormat);
                Assert.AreEqual(false, track.Compilation);
                Assert.AreEqual(0, track.Rating);
                Assert.AreEqual(new DateTime(2016, 8, 29, 13, 16, 54), track.LastModified);
                Assert.AreEqual(new TimeSpan(0, 0, 3, 3, 92), track.Length);
                Assert.AreEqual(1, track.TrackNumber);
                Assert.AreEqual(11, track.TrackCount);
                Assert.AreEqual(2014, track.Year);
                Assert.AreEqual(266, track.BitRate);
                Assert.AreEqual(44100.0d, track.SampleRate);
                Assert.AreEqual(0, track.Volume);
                Assert.AreEqual(TimeSpan.Zero, track.StartTime);
                Assert.AreEqual(null, track.StopTime);
                Assert.AreEqual(0, track.SoundCheck);
                Assert.AreEqual(0, track.PlayCount);
                Assert.AreEqual(0, track.PlayCountSinceLastSync);
                Assert.AreEqual(null, track.LastPlayed);
                Assert.AreEqual(1, track.DiscNumber);
                Assert.AreEqual(1, track.DiscCount);
                Assert.AreEqual(new DateTime(2016, 8, 29, 14, 16, 57), track.DateAdded);
                Assert.AreEqual(TimeSpan.Zero, track.BookmarkTime);
                Assert.AreEqual("180782E193C9C733", track.PersistentID);
                Assert.AreEqual(true, track.Checked);
                Assert.AreEqual(0, track.ApplicationRating);
                Assert.AreEqual(0, track.BPM);
                Assert.AreEqual(1, track.ArtworkCount);
            }
        }
    }
}
