using System.Text;

namespace DesignPatterns_HW3.FileSystemProvider
{
    public class FileSystemProvider : IFileSystemProvider
    {
        public ulong GetFileSize(string path)
        {
            // TODO: maybe unify with the is file flag
            return (ulong)new FileInfo(path).Length;
        }

        public IEnumerable<string> GetFileSystemEntries(string path)
        {
            return SystemDirectory.EnumerateFileSystemEntries(path);
        }

        public bool IsDirectory(string path)
        {
            return SystemDirectory.Exists(path);
        }

        public bool IsFile(string path)
        {
            return SystemFile.Exists(path);
        }

        public FileStream OpenFile(string path, FileMode mode = FileMode.Open)
        {
            return SystemFile.Open(path, mode);
        }


        // TODO: spend too much and didn't understand how to follow shortcut
        // looked like a simple task, did as in the documentation, but didn't work
        // for now it will be in this dummy way
        public bool IsShortcut(string path, out string target)
        {
            var fileInfo = new FileInfo(path);
            if (fileInfo.Extension != ".lnk")
            {
                target = "";
                return false;
            }

            try
            {
                target = GetLnkTargetPath(path);
                target = Path.GetRelativePath(Environment.CurrentDirectory, target);
            }
            catch (Exception) // In case of exception => invalid shortcut
            {
                target = "";
                return false;
            }

            return true;
        }

        // TODO: one sunny day fix
        // wasted too much time on findind the correct way to follow shortcut/symlink
        // copy pasted function which is not perfect, but would work for windows
        private static string GetLnkTargetPath(string filepath)
        {
            using (var br = new BinaryReader(SystemFile.OpenRead(filepath)))
            {
                // skip the first 20 bytes (HeaderSize and LinkCLSID)
                br.ReadBytes(0x14);
                // read the LinkFlags structure (4 bytes)
                uint lflags = br.ReadUInt32();
                // if the HasLinkTargetIDList bit is set then skip the stored IDList 
                // structure and header
                if ((lflags & 0x01) == 1)
                {
                    br.ReadBytes(0x34);
                    var skip = br.ReadUInt16(); // this counts of how far we need to skip ahead
                    br.ReadBytes(skip);
                }
                // get the number of bytes the path contains
                var length = br.ReadUInt32();
                // skip 12 bytes (LinkInfoHeaderSize, LinkInfoFlgas, and VolumeIDOffset)
                br.ReadBytes(0x0C);
                // Find the location of the LocalBasePath position
                var lbpos = br.ReadUInt32();
                // Skip to the path position 
                // (subtract the length of the read (4 bytes), the length of the skip (12 bytes), and
                // the length of the lbpos read (4 bytes) from the lbpos)
                br.ReadBytes((int)lbpos - 0x14);
                var size = length - lbpos - 0x02;
                var bytePath = br.ReadBytes((int)size);
                var path = Encoding.UTF8.GetString(bytePath, 0, bytePath.Length);
                return path;
            }
        }
    }
}
