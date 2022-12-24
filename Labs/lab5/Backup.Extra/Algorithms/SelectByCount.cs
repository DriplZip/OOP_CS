using System.Collections.Generic;
using System.Linq;
using Backup.Extra.Entities;
using Backup.Extra.Tools;
using Backups.Entities;

namespace Backup.Extra.Algorithms
{
    public class SelectPointToCleaningByCount : ISelectPointToCleaningAlgorithm
    {
        private int _countRestorePoints;

        public SelectPointToCleaningByCount(int countRestorePoints)
        {
            if (countRestorePoints < 0) throw new BackupExtraException("incorrect count restore point");
            _countRestorePoints = countRestorePoints;
        }

        public List<RestorePoint> SelectPoints(BackupTaskExtra backupTaskExtra)
        {
            int countPoints = backupTaskExtra.Backups.RestorePoints.Count - _countRestorePoints;

            return backupTaskExtra.Backups.RestorePoints.Take(countPoints).ToList();
        }
    }
}