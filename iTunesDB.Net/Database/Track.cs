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
    }
}
