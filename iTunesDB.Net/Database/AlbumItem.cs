using System;
using iTunesDB.Net.Attributes;

namespace iTunesDB.Net.Database
{
    public class AlbumItem : IDbObject
    {
        [DataObject("AlbumListArtist")]
        public string AlbumListArtist { get; set; }

        [DataObject("AlbumListAlbum")]
        public string AlbumListAlbum { get; set; }

        [DataObject("AlbumListArtistSort")]
        public string AlbumListArtistSort { get; set; }

        public int NumberOfStrings { get; set; }
        public short Unknown1 { get; set; }
        public short AlbumId { get; set; }
        public DateTime Unknown2 { get; set; }
        public int Unknown3 { get; set; }
    }
}
