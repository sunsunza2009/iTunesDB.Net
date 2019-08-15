using System;
using System.IO;
using iTunesDB.Net.Database;

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

            // 0x0C (4 bytes) - number of mhods
            playList.DataObjectChildCount = ReadInt32(Reader);

            // 0x10 (4 bytes) - number of playlist items (mhip)
            playList.PlaylistItemCount = ReadInt32(Reader);

            // 0x14 (1 byte) - masterplaylist
            //     0 = not the master playlist
            //     1 = master playlist
            playList.IsMasterPlaylist = ParseBool(ReadByte(Reader), "IsMasterPlaylist");

            // 0x15 (3 bytes) - unknown
            playList.UnkByte1 = ReadByte(Reader);
            playList.UnkByte2 = ReadByte(Reader);
            playList.UnkByte3 = ReadByte(Reader);

            // 0x18 (4 bytes) - playlist creation time
            playList.Timestamp = ReadDateTime(Reader);

            // 0x1C (8 bytes) - playlist id
            playList.PersistentPlaylistId = ReadUint32(Reader);

            // 0x24 (4 bytes) - unknown (always 0?)
            playList.Unk3 = ReadInt32(Reader);

            // 0x28 (2 bytes) - number of string mhods? (type < 50)
            //     As it seams, this is should be 1 for the title?
            playList.StringMhodCount = ReadInt16(Reader);

            // 0x2A (2 bytes) - podcast
            //     0 = normal playlist
            //     1 = podcast playlist
            playList.PodcastFlag = ReadInt16(Reader);

            // 0x2C (4 bytes) - list sort order
            playList.ListSortOrder = ReadInt32(Reader);

            var db = (iTunesDb) ParentReader.GrandparentDbObject;

            playlists.Add(playList);
            db.PlayLists.Add(playList);
            return true;
        }
    }
}
