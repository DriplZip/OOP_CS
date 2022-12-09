using Backups.Algorithms;
using Backups.Entities;
using Backups.Models;

namespace Backups.Extra.Entities
{
    public class BackupTaskExtra : BackupTask
    {
        public BackupTaskExtra(string name, IStorageAlgorithm storageAlgorithm, IRepository repository, IArchiver archiver) : base(name, storageAlgorithm, repository, archiver)
        {
        }
    }
}