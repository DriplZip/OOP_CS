using System.Collections.Generic;
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

        public void AddRestorePoint(List<Storage> storages)
        {
            if (storages is null)
                throw new BackupsException("incorrect storages input");
            _restorePoints.Add(new RestorePoint(storages));
        }

        public void RemoveRestorePoint(RestorePoint restorePoint)
        {
            if (!_restorePoints.Contains(restorePoint))
                throw new BackupsException("you can't remove non-existent restorePoint");
            _restorePoints.Remove(restorePoint);
        }
    }
}