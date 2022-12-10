using System.Linq;
using Backups.Algorithms;
using Backups.Entities;
using Backups.Extra.Algorithms;
using Backups.Models;

namespace Backups.Extra.Entities
{
    public class BackupTaskExtra : BackupTask
    {
        public BackupTaskExtra(string name, IStorageAlgorithm storageAlgorithm, IRepository repository, IArchiver archiver) : base(name, storageAlgorithm, repository, archiver)
        {
        }

        public ICleanupAlgorithm _cleanupAlgorithm { get;  }

        public void MergeRestorePoint(RestorePoint oldPoint, RestorePoint newPoint)
        {
            if (StorageAlgorithm.GetType() == new SingleStorage().GetType()) RemoveRestorePoint(oldPoint);

            foreach (Storage pointStorage in oldPoint.Storages)
            {
                if (!newPoint.Storages.Contains(pointStorage)) newPoint.AddStorage(pointStorage);
            }
        }
    }
}