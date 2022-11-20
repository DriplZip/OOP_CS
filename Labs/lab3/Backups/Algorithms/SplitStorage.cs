﻿using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Entities;
using Backups.Models;

namespace Backups.Algorithms
{
    public class SplitStorage : IStorageAlgorithm
    {
        public List<Storage> StorageFiles(BackupTask backupTask, int archiveNumber)
        {
            int id = 0;
            
            List<Storage> storages = new List<Storage>();

            foreach (BackupObject backupObject in backupTask.BackupObjects)
            {
                Storage storage = new Storage($"{backupObject.FileName}{id++}({archiveNumber})");

                storage.AddBackupObject(new BackupObject($@"{backupObject.FileName}"));
                storages.Add(storage);
            }

            return storages;
        }
    }
}