using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Backups.Interfaces;
using Backups.Tools;

namespace Backups.Entities
{
    public class BackupTask
    {
        private List<BackupObject> _backupObjects;
        private int _storageCounter = 0;

        public BackupTask(string backupName, IAlgorithm algorithm, IRepository repository)
        {
            if (string.IsNullOrWhiteSpace(backupName))
                throw new BackupsException("incorrect backupName input");
            BackupName = backupName;
            BackupPath = Path.GetFullPath(backupName);
            _backupObjects = new List<BackupObject>();
            BackupAlgorithm = algorithm;
            Repository = repository;
            Backups = new Backup();
        }
        public string BackupName { get; }
        public string BackupPath { get; private set; }
        public IAlgorithm BackupAlgorithm { get; private set; }
        public IRepository Repository { get; }
        public Backup Backups { get; }
        public IReadOnlyCollection<BackupObject> BackupObjects => _backupObjects.AsReadOnly();

        public void SetStorageAlgorithm(IAlgorithm algorithm)
        {
            if (algorithm is null)
                throw new BackupsException("incorrect algorithm input");
            BackupAlgorithm = algorithm;
        }

        public void SetBackupPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new BackupsException("incorrect path input");
            BackupPath = path;
        }

        public void DoBackup()
        {
            Repository.Create(this);
            Storage storage = BackupAlgorithm.SaveFile(_backupObjects, this);
            _storageCounter += storage.StorageCount;
            Backups.AddRestorePoint(_backupObjects);
            for (int i = 0; i < _backupObjects.Count; i++)
            {
                using FileStream startStream = new FileStream(_backupObjects[i].GetFullPath(), FileMode.OpenOrCreate);
                using FileStream compressedStream = File.Create($"{storage.GetBackupObjectPath(i)}.gz");
                using GZipStream compressor = new GZipStream(compressedStream, CompressionMode.Compress);
                startStream.CopyTo(compressor);
            }
        }

        public void RemoveBackup(RestorePoint restorePoint)
        {
            Backups.RemoveRestorePoint(restorePoint);
        }

        public void AddBackupObject(BackupObject backupObject)
        {
            _backupObjects.Add(backupObject);
        }

        public void RemoveBackupObject(BackupObject backupObject)
        {
            if (!_backupObjects.Contains(backupObject))
                throw new BackupsException("you can't remove non-existent backupObject");
            _backupObjects.Remove(backupObject);
        }

        public int GetStorageCount()
        {
            return _storageCounter;
        }
    }
}