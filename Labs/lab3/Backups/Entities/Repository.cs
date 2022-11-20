using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Backups.Entities;
using Backups.Tools;

namespace Backups.Models
{
    public class Repository : IRepository
    {
        private DirectoryInfo _directoryInfo;
        
        public Repository(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath)) throw new BackupsException("Incorrect path");
            
            FullPath = Path.GetFullPath(fullPath);
            Name = Path.GetFileName(FullPath);
            _directoryInfo = new DirectoryInfo(fullPath);
        }
        
        public string FullPath { get; private set; }
        public string Name { get; }

        public void Read(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new BackupsException("Incorrect path");
            FullPath = Path.GetFullPath(path);

            _directoryInfo = new DirectoryInfo(path);
        }
        
        public void Save(BackupTask backupTask)
        {
            foreach (Storage storage in backupTask.RestorePoints.Last().Storages)
            {
                foreach (BackupObject backupObject in storage.BackupObjects)
                {
                    using FileStream originalFileStream = new FileStream($@"{backupTask.Repository.GetName()}\{backupTask.Name}\{backupObject.FileName}", FileMode.OpenOrCreate);
                    using FileStream compressedFileStream = File.Create($@"{backupTask.Repository.GetName()}\{backupTask.Name}\{storage.Name}.gz");
                    using GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                    originalFileStream.CopyTo(compressor);
                }
            }
        }

        public string GetName()
        {
            return Name;
        }
    }
}