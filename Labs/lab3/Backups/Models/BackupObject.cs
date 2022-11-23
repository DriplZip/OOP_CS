using System;
using System.IO;
using Backups.Tools;

namespace Backups.Models
{
    public class BackupObject
    {
        public BackupObject(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new BackupsException("");
            FileName = fileName;
            FilePath = Path.GetFullPath(fileName);
        }
        
        public string FilePath { get; }
        public string FileName { get; }

    }
}