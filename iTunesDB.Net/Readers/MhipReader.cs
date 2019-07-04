using System;
using System.IO;
using iTunesDB.Net.Database;

namespace iTunesDB.Net.Readers
{
    internal class MhipReader : iTunesReader
    {
        public override string ObjectID => "mhip";
        public override string[] ChildIDs => new[] {"mhod"};
        public override Type DatabaseType => typeof(PlayListItem);

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            var playListItem = (PlayListItem)DbObject;
            var playList = (PlayList)ParentDbObject;
            playList.Add(playListItem);

            playListItem.DataObjectChildCount = ReadInt32(Reader);
            playListItem.PodcastGroupingFlag = ReadInt16(Reader);
            playListItem.Unk4 = ReadByte(Reader);
            playListItem.Unk5 = ReadByte(Reader);
            playListItem.GroupId = ReadInt32(Reader);
            playListItem.TrackId = ReadInt32(Reader);
            playListItem.Timestamp = ReadDateTime(Reader);
            playListItem.PodcastGroupingReference = ReadInt32(Reader);

            return true;
        }
    }
}
