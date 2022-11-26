using System.IO;
using Backups.Tools;

namespace Backups.Entities
{
    public class BackupObject
    {
        public BackupObject(string fileName, string filePath)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new BackupsException("incorrect fileName input");
            if (string.IsNullOrWhiteSpace(filePath))
                throw new BackupsException("incorrect filePath input");
            FileName = fileName;
            FilePath = filePath;
        }

        public string FileName { get; }
        public string FilePath { get; }

        public string GetFullPath()
        {
            return Path.GetFullPath(FileName);
        }
    }
}