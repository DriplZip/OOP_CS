using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Algorithms;
using Backups.Models;
using Backups.Tools;

namespace Backups.Entities
{
    public class BackupTask
    {
        private List<BackupObject> _backupObjects; 
        private List<RestorePoint> _restorePoints;
        private ArchiveNumber _archiveNumber = new ArchiveNumber();

        public BackupTask(string name, IStorageAlgorithm storageAlgorithm, IRepository repository)
        {
            _backupObjects = new List<BackupObject>();
            _restorePoints = new List<RestorePoint>();

            if (string.IsNullOrWhiteSpace(name)) throw new BackupsException("Incorrect backup task name");
            Name = name;
            
            StorageAlgorithm = storageAlgorithm;
            Repository = repository;
        }
        
        public string Name { get; }
        public IStorageAlgorithm StorageAlgorithm { get; }
        public IRepository Repository { get; }
        public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects.AsReadOnly();
        public IReadOnlyCollection<RestorePoint> RestorePoints => _restorePoints.AsReadOnly();

        public void AddBackupObject(BackupObject backupObject)
        {
            _backupObjects.Add(backupObject);
        }

        public void RemoveBackupObject(BackupObject backupObject)
        {
            if (_backupObjects.FirstOrDefault(backup => backup.FilePath == backupObject.FilePath) is null)
                throw new BackupsException("Backup object does not exist");

            _backupObjects.Remove(backupObject);
        }

        public void CreateBackup()
        {
            int archiveNumber = _archiveNumber.GenerateNumber();
            List<Storage> storages = StorageAlgorithm.StorageFiles(this, archiveNumber);

            RestorePoint restorePoint = new RestorePoint(DateTime.Now, storages, archiveNumber);
            
            _restorePoints.Add(restorePoint);
            
            Repository.Save(this);
        }
    }
}