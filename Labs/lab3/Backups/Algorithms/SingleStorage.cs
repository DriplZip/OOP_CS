using System.Collections.Generic;
using System.IO;
using Backups.Entities;
using Backups.Interfaces;
using Backups.Tools;

namespace Backups.Algorithms
{
    public class SingleStorage : IAlgorithm
    {
        public Storage SaveFile(List<BackupObject> backupObjects, BackupTask backupTask)
        {
            if (backupTask is null)
                throw new BackupsException("incorrect backupTask input");
            string storageName = "Single";
            List<BackupObject> storageBackupObjects = new List<BackupObject>();
            foreach (BackupObject backupObject in backupObjects)
            {
                storageBackupObjects.Add(new BackupObject(backupObject.FileName, $@"{backupTask.BackupPath}\{storageName}"));
            }
            Storage storage = new Storage(storageName, storageBackupObjects);
            storage.StorageCount++;
            return storage;
        }
    }
}