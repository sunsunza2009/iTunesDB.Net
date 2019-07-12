using System.Collections.Generic;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Database
{
    public class iTunesDb : IDbObject
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int Version { get; set; }
        public Platform Platform { get; set; }
        public string Language { get; set; }
        public int TimezoneOffsetInSeconds { get; set; }
        public byte[] UnknownBytes { get; set; }
        public AlbumList Albums { get; set; }
        public TrackList Tracks { get; set; }
        public PlayLists PlayLists { get; set; }
        public List<ListContainer> ListContainers { get; set; }
    }
}
