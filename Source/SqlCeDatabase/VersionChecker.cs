using System.IO;

namespace ChristianHelle.DatabaseTools.SqlCe
{
    public static class VersionChecker
    {
        public static SupportedVersions GetVersion(string file)
        {
            using (var fs = new FileStream(file, FileMode.Open))
            {
                fs.Seek(16, SeekOrigin.Begin);
                var reader = new BinaryReader(fs);
                var signature = reader.ReadInt32();

                switch (signature)
                {
                    case 0x73616261: return SupportedVersions.SqlCe20;
                    case 0x002dd714: return SupportedVersions.SqlCe31;
                    case 0x00357b9d: return SupportedVersions.SqlCe35;
                    case 0x003D0900: return SupportedVersions.SqlCe40;
                    default: return SupportedVersions.Unsupported;
                }
            }
        }
    }
}
