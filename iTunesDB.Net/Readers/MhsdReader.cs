using System;
using System.IO;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;

namespace iTunesDB.Net.Readers
{
    internal class MhsdReader : iTunesReader
    {
        public override string ObjectID { get { return "mhsd"; } }
        public override string[] ChildIDs { get { return new string[] { "mhla", "mhia", "mhlt", "mhlp" }; } }
        public override Type DatabaseType { get { return typeof(ListContainer); } }

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            var listContainer = (ListContainer)DbObject;
            var db = (iTunesDb)ParentDbObject;

            // 0x0D (4 bytes) - list type
            //     1 = Track list - contains an MHLT
            //     2 = Playlist List - contains an MHLP
            //     3 = Podcast List - optional, probably. Contains an MHLP also.
            //         This MHLP is basically the same as the full playlist section,
            //         except it contains the podcasts in a slightly different way.
            //     4 = Album List, first seen with iTunes 7.1.
            //     5 = New Playlist List with Smart Playlists, first seen with iTunes 7.3.
            listContainer.ListType = ReadEnum<ListTypes>(Reader);

            db.ListContainers.Add(listContainer);
            return true;
        }
    }
}
