﻿using System.Collections.Generic;
using System.Linq;
using Backups.Extra.Entities;
using Backups.Models;

namespace Backups.Extra.Algorithms
{
    public class CleanupByLimit : ICleanupAlgorithm
    {
        private List<ICleanupAlgorithm> _algorithms;
        private LimitType _limitType;
        
        public CleanupByLimit(List<ICleanupAlgorithm> algorithms, LimitType limitType)
        {
            _algorithms = algorithms;
            _limitType = limitType;
        }
        
        public List<RestorePoint> FindRestorePointsToCleanup(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> restorePoints = null;

            foreach (ICleanupAlgorithm cleanupAlgorithm in _algorithms)
            {
                List<RestorePoint> points = cleanupAlgorithm.FindRestorePointsToCleanup(backupTaskExtra);

                if (_limitType == LimitType.AtLeastOne)
                {
                    restorePoints = new List<RestorePoint>();
                    restorePoints.AddRange(points.Where(point => !restorePoints.Contains(point)));
                }
                else if (_limitType == LimitType.ForAll)
                {
                    if (restorePoints == null)
                    {
                        restorePoints = new List<RestorePoint>();
                        restorePoints = points;
                    }

                    foreach (RestorePoint restorePoint in restorePoints)
                    {
                        if (!points.Contains(restorePoint)) restorePoints.Remove(restorePoint);
                    }
                }
            }

            return restorePoints;
        }

        public void CleanupRestorePoints(BackupTaskExtra backupTaskExtra)
        {
            List<RestorePoint> restorePoints = FindRestorePointsToCleanup(backupTaskExtra);
            
            restorePoints.ForEach(backupTaskExtra.RemoveRestorePoint);
        }
    }
}