using System.Collections.Generic;
using System.IO;
using Backups.Entities;
using Backups.Models;

namespace Backups.Algorithms
{
    public interface IStorageAlgorithm
    {
        public List<Storage> StorageFiles(BackupTask backupTask, int archiveNumber);
    }
}