using System.Collections.Generic;
using Backups.Entities;
using Backups.Interfaces;
using Backups.Models;

namespace Backups.Algorithms
{
    public class SingleStorage : IStorageAlgorithm
    {
        public List<Storage> MakingCopy(BackupTask backupTask, int backupNumber)
        {
            List<Storage> storages = new List<Storage>();
            Storage storage = new Storage($"Single_{backupTask.Name}({backupNumber})");
            
            foreach (BackupObject backupObject in backupTask.BackupObjects)
            {
                storage.AddBackupObject(new BackupObject($@"{backupObject.FileName}"));
            }
            
            storages.Add(storage);
            return storages;
        }
    }
}