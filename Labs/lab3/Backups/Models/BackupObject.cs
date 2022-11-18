using System;
using System.IO;
using Backups.Tools;

namespace Backups.Models
{
    public class BackupObject
    {
        public BackupObject(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath)) throw new BackupsException("Incorrect path name");

            FilePath = filePath;
            FileName = Path.GetFileName(filePath);
        }

        public string FilePath { get; }
        public string FileName { get; }

    }
}