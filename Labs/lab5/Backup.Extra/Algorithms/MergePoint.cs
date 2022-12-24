using System.Linq;
using Backup.Extra.Entities;
using Backups.Algorithms;
using Backups.Entities;

namespace Backup.Extra.Algorithms
{
    public class MergePoint
    {
        public void Merge(BackupTaskExtra backupTaskExtra, RestorePoint restorePoint)
        {
            RestorePoint lastPoint = backupTaskExtra.Backups.RestorePoints.Last();
            if (backupTaskExtra.BackupAlgorithm == new SingleStorage())
            {
                backupTaskExtra.RemoveBackup(lastPoint);
                backupTaskExtra.Backups.AddRestorePoint(restorePoint.BackupObjects.ToList());
                
                return;
            }

            foreach (BackupObject backupObject in lastPoint.BackupObjects)
            {
                if (!restorePoint.BackupObjects.Contains(backupObject)) restorePoint.AddBackupObject(backupObject);
            }
            
            backupTaskExtra.Backups.AddRestorePoint(restorePoint.BackupObjects.ToList());
        }
    }
}