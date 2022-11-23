using System.Collections.Generic;
using System.IO;
using Backups.Models;
using Backups.Tools;

namespace Backups.Entities
{
    public class Storage
    {
        private List<BackupObject> _backupObjects = new List<BackupObject>();
        
        public Storage(string storagePath)
        {
            if (string.IsNullOrWhiteSpace(storagePath))
                throw new BackupsException("");
            FullPath = Path.GetFullPath(storagePath);
        }
        
        public string FullPath { get; }
        public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects.AsReadOnly();

        public void AddBackupObject(BackupObject backupObject)
        {
            if (backupObject is null) 
                throw new BackupsException("");
            _backupObjects.Add(backupObject);
        }
    }
}