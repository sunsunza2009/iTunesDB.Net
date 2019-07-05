using System.IO;
using iTunesDB.Net.Database;
using DO = iTunesDB.Net.Enumerations.DataObjects;

namespace iTunesDB.Net.Readers.DataObjects
{
    internal class IntReader : DataObjectReader
    {
        private static DO[] dataObjectTypes = new DO[] { DO.SizingAndOrder };
        public override DO[] DataObjectTypes { get { return dataObjectTypes; } }

        public override void ParseDataObject(BinaryReader Reader)
        {
            var dotype = ((DataObject)DbObject).Type;
            var obj = ParentDbObject;

            var unk1 = ReadInt32(Reader);
            var unk2 = ReadInt32(Reader);
            var position = ReadInt32(Reader);
            var length = ReadInt32(Reader);
            var unk3 = ReadInt32(Reader);
            var unk4 = ReadInt32(Reader);

            SetDataObjectString(dotype, position);
        }
    }
}
