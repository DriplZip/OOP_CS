using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Interfaces
{
    public interface IAlgorithm
    {
        public Storage SaveFile(List<BackupObject> backupObjects, BackupTask backupTask);
    }
}