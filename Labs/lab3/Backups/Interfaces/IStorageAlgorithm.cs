using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Interfaces
{
    public interface IStorageAlgorithm
    {
        public List<Storage> MakingCopy(BackupTask backupTask, int backupNumber);
    }
}