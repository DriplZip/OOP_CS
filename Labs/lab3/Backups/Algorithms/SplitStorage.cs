using System.Collections.Generic;
using Backups.Entities;
using Backups.Interfaces;
using Backups.Models;

namespace Backups.Algorithms
{
    public class SplitStorage : IStorageAlgorithm
    {
        public List<Storage> MakingCopy(BackupTask backupTask, int backupNumber)
        {
            int id = 0;
            List<Storage> storages = new List<Storage>();

            foreach (BackupObject backupObject in backupTask.BackupObjects)
            {
                Storage storage = new Storage($"{backupObject.FileName}{id++}({backupNumber})");

                storage.AddBackupObject(new BackupObject($@"{backupObject.FileName}"));
                storages.Add(storage);
            }

            return storages;
        }
    }
}