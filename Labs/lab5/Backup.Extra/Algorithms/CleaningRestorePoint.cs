using System.Collections.Generic;
using Backup.Extra.Entities;
using Backups.Entities;

namespace Backup.Extra.Algorithms
{
    public class CleanRestorePoint
    {
        public void Cleaning(BackupTaskExtra backupTaskExtra, List<RestorePoint> restorePoints)
        {
            foreach (RestorePoint restorePoint in restorePoints)
            {
                backupTaskExtra.RemoveBackup(restorePoint);
            }
        }
    }
}