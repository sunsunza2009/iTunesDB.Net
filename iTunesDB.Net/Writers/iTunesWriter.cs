using System.IO;
using iTunesDB.Net.Database;

namespace iTunesDB.Net
{
    public class iTunesWriter
    {
        public void Write(iTunesDb db, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (var writer = new BinaryWriter(fs))
            {
                MhdbWriter.Write(db, writer);
                MhsdWriter.Write(db, writer);
            }
        }
    }
}
