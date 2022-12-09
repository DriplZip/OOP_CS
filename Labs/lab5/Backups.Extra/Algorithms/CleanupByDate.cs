using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Extra.Entities;
using Backups.Models;

namespace Backups.Extra.Algorithms
{
    public class CleanupByDate : ICleanupAlgorithm
    {
        private TimeSpan _storageInterval;

        public CleanupByDate(TimeSpan storageInterval)
        {
            _storageInterval = storageInterval;
        }
        
        public List<RestorePoint> FindRestorePointsToCleanup(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> restorePoints =
                backupTaskExtra.RestorePoints.Where(point => (DateTime.Now.Subtract(point.Date)) < _storageInterval).ToList();

            return restorePoints;
        }

        public void CleanupRestorePoints(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> restorePoints = FindRestorePointsToCleanup(backupTaskExtra);
            
            restorePoints.ForEach(backupTaskExtra.RemoveRestorePoint);
        }
    }
}