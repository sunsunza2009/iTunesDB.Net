using System.Collections.Generic;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Database
{
    public class iTunesDb : IDbObject
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int DeviceSupportsCompressedDb { get; set; }
        public int Version { get; set; }
        public byte[] Id { get; set; }
        public Platform Platform { get; set; }
        public string Language { get; set; }
        public byte[] LibraryPersistantId { get; set; }
        public int TimezoneOffsetInSeconds { get; set; }
        public byte[] UnknownBytes { get; set; }
        public AlbumList Albums { get; set; }
        public TrackList Tracks { get; set; }
        public PlayLists PlayLists { get; set; }
        public List<ListContainer> ListContainers { get; set; }
        public byte[] UnknownAt0X22 { get; set; }
        public byte[] UnknownAt0X24 { get; set; }
        public byte[] UnknownAt0X2C { get; set; }
        public short UnknownAt0X30 { get; set; }
        public byte[] UnknownAt0X32 { get; set; }
        public int UnknownAt0X50 { get; set; }
        public int UnknownAt0X54 { get; set; }
        public byte[] UnknownAt0X58 { get; set; }
    }
}
