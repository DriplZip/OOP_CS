using System.Collections.Generic;
using System.IO;
using Backups.Entities;
using Backups.Interfaces;
using Backups.Tools;

namespace Backups.Algorithms
{
    public class SplitStorage : IAlgorithm
    {
        public Storage SaveFile(List<BackupObject> backupObjects, BackupTask backupTask)
        {
            if (backupTask is null)
                throw new BackupsException("incorrect backupTask input");
            string storageName = "Split";
            if (!Directory.Exists(Path.Combine(backupTask.BackupPath, storageName)))
                Directory.CreateDirectory(Path.Combine(backupTask.BackupPath, storageName));
            List<BackupObject> storageBackupObjects = new List<BackupObject>();
            foreach (BackupObject backupObject in backupObjects)
            {
                storageBackupObjects.Add(new BackupObject(backupObject.FileName, $@"{backupTask.BackupPath}\{storageName}\{Path.GetFileNameWithoutExtension(backupObject.FileName)}"));
            }
            Storage storage = new Storage(storageName, storageBackupObjects);
            storage.StorageCount += storageBackupObjects.Count;
            return storage;
        }
    }
}