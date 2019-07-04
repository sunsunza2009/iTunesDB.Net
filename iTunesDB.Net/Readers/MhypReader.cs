using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Readers
{
    internal class MhypReader : iTunesReader
    {
        public override string ObjectID { get { return "mhyp"; } }
        public override string[] ChildIDs { get { return new string[] { "mhod", "mhip" }; } }
        public override Type DatabaseType { get { return typeof(PlayList); } }

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            var playList = (PlayList) DbObject;
            var playlists = (PlayLists) ParentDbObject;

            playList.DataObjectChildCount = ReadInt32(Reader);
            playList.PlaylistItemCount = ReadInt32(Reader);
            playList.IsMasterPlaylist = ParseBool(ReadByte(Reader), "IsMasterPlaylist");
            playList.Unk = ReadBytes(Reader, 3);
            playList.Timestamp = ReadDateTime(Reader);
            playList.PersistentPlaylistId = ReadUint32(Reader);
            playList.Unk3 = ReadInt32(Reader);
            playList.StringMhodCount = ReadInt16(Reader);
            playList.PodcastFlag = ReadInt16(Reader);
            playList.ListSortOrder = ReadEnum<ListSortDirection>(Reader);

            var db = (iTunesDb) ParentReader.GrandparentDbObject;

            playlists.Add(playList);
            db.PlayLists.Add(playList);
            return true;
        }
    }
}
