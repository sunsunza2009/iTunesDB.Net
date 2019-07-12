using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using iTunesDB.Net.Database;
using iTunesDB.Net.Enumerations;
using iTunesDB.Net.Events;

namespace iTunesDB.Net.Readers
{
    public class MhlaReader : iTunesReader
    {
        public override string ObjectID => "mhla";
        public override string[] ChildIDs => new[] {"mhia"};
        public override Type DatabaseType => typeof(AlbumList);

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            var albumList = (AlbumList) DbObject;
            var listContainer = (ListContainer) ParentDbObject;
            var db = (iTunesDb) GrandparentDbObject;

            if (listContainer.ListType != ListTypes.Albums)
                throw new InvalidOperationException("Invalid ListType "
                                                    + listContainer.ListType.ToString() + " for AlbumList container");

            albumList.NumberOfAlbumItems = TotalSize;

            db.Albums = albumList;
            listContainer.Add(albumList);

            return true;
        }
    }
}
