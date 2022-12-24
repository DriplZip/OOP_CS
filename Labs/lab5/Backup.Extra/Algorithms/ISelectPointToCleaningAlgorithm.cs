using System.Collections.Generic;
using Backup.Extra.Entities;
using Backups.Entities;

namespace Backup.Extra.Algorithms
{
    public interface ISelectPointToCleaningAlgorithm
    {
        public List<RestorePoint> SelectPoints(BackupTaskExtra backupTaskExtra);
    }
}