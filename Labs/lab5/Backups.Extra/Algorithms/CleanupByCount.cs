using System.Collections.Generic;
using System.Linq;
using Backups.Extra.Entities;
using Backups.Extra.Tools;
using Backups.Models;

namespace Backups.Extra.Algorithms
{
    public class CleanupByCount : ICleanupAlgorithm
    {
        private int _restorePointsAmount;
        
        public CleanupByCount(int restorePointsAmount)
        {
            if (restorePointsAmount < 0) throw new BackupExtraException("Restore points amount cannot be less than 0");
            _restorePointsAmount = restorePointsAmount;
        }
        
        public List<RestorePoint> FindRestorePointsToCleanup(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> restorePoints = backupTaskExtra.RestorePoints.Take(backupTaskExtra.RestorePoints.Count - _restorePointsAmount).ToList();
            return restorePoints;
        }

        public void CleanupRestorePoints(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> restorePoints = FindRestorePointsToCleanup(backupTaskExtra);
            
            restorePoints.ForEach(backupTaskExtra.RemoveRestorePoint);
        }
    }
}