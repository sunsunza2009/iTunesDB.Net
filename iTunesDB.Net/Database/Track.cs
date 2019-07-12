using System;
using iTunesDB.Net.Attributes;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Database
{
    public class Track : IDbObject
    {
        [DataObject("Title")]
        public string Name { get; set; }
        [DataObject("FileType")]
        public string Kind { get; set; }
        [DataObject("Comment")]
        public string Comments { get; set; }
        [DataObject("Unknown3")]
        public string Unknown3 { get; set; }

        public int NumberOfStrings { get; set; }
        public int TrackID { get; set; }
        public bool Visible { get; set; }
        public string FileType { get; set; }
        public CodingFormats CodingFormat { get; set; }
        public bool Compilation { get; set; }
        public byte Rating { get; set; }
        public DateTime LastModified { get; set; }
        public uint SizeBytes { get; set; }
        public TimeSpan Length { get; set; }
        public int TrackNumber { get; set; }
        public int TrackCount { get; set; }
        public int Year { get; set; }
        public int BitRate { get; set; }
        public double SampleRate { get; set; }
        public int Volume { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan? StopTime { get; set; }
        public uint SoundCheck { get; set; }
        public int PlayCount { get; set; }
        public int PlayCountSinceLastSync { get; set; }
        public DateTime? LastPlayed { get; set; }
        public int DiscNumber { get; set; }
        public int DiscCount { get; set; }
        public uint? UserID { get; set; }
        public DateTime DateAdded { get; set; }
        public TimeSpan BookmarkTime { get; set; }
        public string PersistentID { get; set; }
        public bool Checked { get; set; }
        public byte ApplicationRating { get; set; }
        public short BPM { get; set; }
        public int ArtworkCount { get; set; }


        // ...


        public MediaType MediaType { get; set; }

        // ...

        public short GaplessTrackFlag { get; set; }
        public short GaplessAlbumFlag { get; set; }

        // ...

        public ulong AlbumId { get; set; }

        // ...

        public short Unk9 { get; set; }
        public uint ArtworkSizeBytes { get; set; }
        public int Unk11 { get; set; }
        public DateTime DateReleased { get; set; }

        public double SizeMB { get { return SizeBytes / 1048576d; } }
        public double SoundCheckDB { get { return 30 - 10 * Math.Log(SoundCheck); } }
        public int ApplicationStars { get { return Convert.ToInt32(Math.Round(ApplicationRating / 20d, 0)); } }
        public int Stars { get { return Convert.ToInt32(Math.Round(Rating / 20d, 0)); } }
        public double ArtworkSizeMB { get { return ArtworkSizeBytes / 1048576d; } }

        // Not read so far:

        public string Artist { get; set; }
        public string Composer { get; set; }
        public string Album { get; set; }
        public string Grouping { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public string LocationWindows { get; set; }
        public string EQSetting { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        // --
    }
}
