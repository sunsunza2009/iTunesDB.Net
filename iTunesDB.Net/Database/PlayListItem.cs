using System;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Database
{
    public class PlayListItem : IDbObject
    {
        [Attributes.DataObject("SizingAndOrder")]
        public int SizingAndOrder { get; set; }

        public int DataObjectChildCount { get; set; }
        public short PodcastGroupingFlag { get; set; }
        public byte Unk4 { get; set; }
        public byte Unk5 { get; set; }
        public int GroupId { get; set; }
        public int TrackId { get; set; }
        public DateTime Timestamp { get; set; }
        public int PodcastGroupingReference { get; set; }
    }
}
