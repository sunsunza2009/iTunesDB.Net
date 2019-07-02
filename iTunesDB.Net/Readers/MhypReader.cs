using System;
using System.IO;
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
            var playList = (PlayList)DbObject;
            var playlists = (PlayLists)ParentDbObject;

            var db = (iTunesDb)ParentReader.GrandparentDbObject;

            playlists.Add(playList);
            db.PlayLists.Add(playList);
            return true;
        }
    }
}
