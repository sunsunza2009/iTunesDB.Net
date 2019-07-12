using System;
using System.Collections.Generic;
using System.IO;
using iTunesDB.Net.Database;
using DO = iTunesDB.Net.Enumerations.DataObjects;

namespace iTunesDB.Net.Readers
{
    internal class MhodReader : iTunesReader
    {
        public override string ObjectID { get { return "mhod"; } }
        public override string[] ChildIDs { get { return new string[0]; } }
        public override Type DatabaseType { get { return typeof(DataObject); } }
        public static List<DO> TrackTypes = new List<DO>();
        public static List<DO> AlbumListTypes = new List<DO>();
        public static List<DO> AlbumItemTypes = new List<DO>();
        public static List<DO> PlayListTypes = new List<DO>();
        public static List<DO> PlayListItemTypes = new List<DO>();

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            ObjectSize = TotalSize;
            var dobj = (DataObject)DbObject;
            dobj.Type = ReadEnum<DO>(Reader);
            var rdr = CreateDataObjectReader(dobj.Type, this);
            rdr.ParseDataObject(Reader);

            if (ParentDbObject is Track)
            {
                var track = (Track)ParentDbObject;
                TrackTypes.Add(dobj.Type);
            }
            else if (ParentDbObject is PlayList)
            {
                var playList = (PlayList)ParentDbObject;
                PlayListTypes.Add(dobj.Type);
            }
            else if (ParentDbObject is PlayListItem)
            {
                var playListItem = (PlayListItem) ParentDbObject;
                PlayListItemTypes.Add(dobj.Type);
            }
            else if (ParentDbObject is AlbumList)
            {
                var albumList = (AlbumList) ParentDbObject;
                AlbumListTypes.Add(dobj.Type);
            }
            else if (ParentDbObject is AlbumItem)
            {
                var albumItem = (AlbumItem) ParentDbObject;
                AlbumItemTypes.Add(dobj.Type);
            }
            else throw new Exception($"Unknown mhod parent type {ParentDbObject.GetType()}");
            return true;
        }
    }
}

