using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Interfaces;
using Backups.Models;
using Backups.Tools;

namespace Backups.Entities
{
    public class BackupTask
    {
        private List<BackupObject> _backupObjects;
        private int _backupNumber = 0;

        public BackupTask(string name, IStorageAlgorithm storageAlgorithm, IRepository repository)
        {
            _backupObjects = new List<BackupObject>();

            if (string.IsNullOrWhiteSpace(name)) 
                throw new BackupsException("Incorrect backup task name");
            Name = name;
            StorageAlgorithm = storageAlgorithm;
            Repository = repository;
            Backups = new Backup();
        }
        
        public string Name { get; }
        public IStorageAlgorithm StorageAlgorithm { get; }
        public IRepository Repository { get; }
        public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects.AsReadOnly();
        public Backup Backups { get; }

        public void AddBackupObject(BackupObject backupObject)
        {
            if (backupObject is null)
                throw new BackupsException("Nothing to add");
            _backupObjects.Add(backupObject);
        }

        public void RemoveBackupObject(BackupObject backupObject)
        {
            if (_backupObjects.FirstOrDefault(backup => backup == backupObject) is null)
                throw new BackupsException("Backup object does not exist");
            _backupObjects.Remove(backupObject);
        }

        public void CreateBackup()
        {
            List<Storage> storages = StorageAlgorithm.MakingCopy(this, _backupNumber++);
            RestorePoint restorePoint = new RestorePoint(DateTime.Now, storages);
            Backups.AddRestorePoint(restorePoint);
            Repository.Save(this);
        }
    }
}