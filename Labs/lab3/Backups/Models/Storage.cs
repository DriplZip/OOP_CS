using System.Collections.Generic;
using Backups.Algorithms;
using Backups.Tools;

namespace Backups.Models
{
    public class Storage
    {
        private List<BackupObject> _storages;
        
        public Storage(string path)
        {
            Path = path;
        }
        
        public string Path { get; }
        
        public void AddBackupObject(BackupObject backupObject)
        {
            if (backupObject is null) throw new BackupsException("Empty object");

            _storages.Add(backupObject);
        }
    }
}