using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace iTunesDB.Net.Database
{
    public class PlayList : List<PlayListItem>, IDbObject
    {
        [Attributes.DataObject("Title")]
        public string Name { get; set; }

        [Attributes.DataObject("Unknown2")]
        public string Unknown2 { get; set; }

        [Attributes.DataObject("SizingAndOrder")]
        public int SizingAndOrder { get; set; }

        [Attributes.DataObject("LibraryPlaylistIndex")]
        public int PlaylistIndex { get; set; }

        [Attributes.DataObject("LibraryPlaylistIndexLetterJumpTable")]
        public int PlaylistIndexLetterJumpTable { get; set; }

        public int DataObjectChildCount { get; set; }
        public int PlaylistItemCount { get; set; }
        public bool IsMasterPlaylist { get; set; }
        public byte[] Unk { get; set; }
        public DateTime Timestamp { get; set; }
        public uint PersistentPlaylistId { get; set; }
        public int Unk3 { get; set; }
        public short StringMhodCount { get; set; }
        public short PodcastFlag { get; set; }
        public ListSortDirection ListSortOrder { get; set; }
    }
}
