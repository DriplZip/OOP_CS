using System.Collections.Generic;
using System.Linq;
using Backups.Tools;

namespace Backups.Entities
{
    public class Backup
    {
        private List<RestorePoint> _restorePoints;
        
        public Backup()
        {
            _restorePoints = new List<RestorePoint>();
        }

        public IReadOnlyCollection<RestorePoint> RestorePoints => _restorePoints.AsReadOnly();

        public void AddRestorePoint(List<BackupObject> backupObjects)
        {
            if (backupObjects is null)
                throw new BackupsException("incorrect storages input");
            _restorePoints.Add(new RestorePoint(backupObjects));
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            if (!_restorePoints.Contains(restorePoint))
                throw new BackupsException("you can't remove non-existent restorePoint");
            _restorePoints.Remove(restorePoint);
        }

        public RestorePoint GetLastRestorePoint()
        {
            if (_restorePoints.Count is 0)
                throw new BackupsException("backup is empty");
            return _restorePoints.Last();
        }
    }
}