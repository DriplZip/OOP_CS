using System;
using System.Collections.Generic;
using Backups.Interfaces;
using Backups.Tools;

namespace Backups.Entities
{
    public class RestorePoint
    {
        private List<BackupObject> _backupObjects;
        public RestorePoint(List<BackupObject> backupObjects)
        {
            _backupObjects = backupObjects;
            CreationTime = DateTime.Now;
        }

        public DateTime CreationTime { get; }
        public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects.AsReadOnly();
    }
}