using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using iTunesDB.Net.Database;
using iTunesDB.Net.Events;

namespace iTunesDB.Net.Readers
{
    public class MhiaReader : iTunesReader
    {
        public override string ObjectID => "mhia";
        public override string[] ChildIDs => new[] {"mhod"};
        public override Type DatabaseType => typeof(AlbumItem);

        protected override bool ParseiTunesObject(BinaryReader Reader)
        {
            var albumItem = (AlbumItem)DbObject;
            var listContainer = (ListContainer) ParentDbObject;
            var albumList = listContainer.First(l => l is AlbumList);
            albumList.Add(albumItem);

            albumItem.NumberOfStrings = ReadInt32(Reader);
            albumItem.Unknown1 = ReadInt16(Reader);
            albumItem.AlbumId = ReadInt16(Reader);
            albumItem.Unknown2 = ReadDateTime(Reader);
            albumItem.Unknown3 = ReadInt32(Reader);

            return true;
        }
    }
}
