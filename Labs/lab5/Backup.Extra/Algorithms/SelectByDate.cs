using System;
using System.Collections.Generic;
using System.Linq;
using Backup.Extra.Entities;
using Backups.Entities;

namespace Backup.Extra.Algorithms
{
    public class SelectPointToCleaningByDate : ISelectPointToCleaningAlgorithm
    {
        private DateTime _dateTime;

        public SelectPointToCleaningByDate(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public List<RestorePoint> SelectPoints(BackupTaskExtra backupTaskExtra)
        {
            return backupTaskExtra.Backups.RestorePoints.Where(point => point.CreationTime > _dateTime).ToList();
        }
    }
}