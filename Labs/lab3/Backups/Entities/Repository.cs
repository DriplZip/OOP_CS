using System.IO;
using System.IO.Compression;
using Backups.Interfaces;
using Backups.Models;
using Backups.Tools;

namespace Backups.Entities
{
    public class Repository : IRepository
    {
        public Repository(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) 
                throw new BackupsException("Incorrect path");
            
            RepositoryPath = Path.GetFullPath(path);
            Name = Path.GetFileName(RepositoryPath);
        }
        
        public string RepositoryPath { get; }
        public string Name { get; }

        public void Save(BackupTask backupTask)
        {
            foreach (Storage storage in backupTask.RestorePoints.Last().Storages)
            {
                foreach (BackupObject backupObject in storage.BackupObjects)
                {
                    using FileStream originalFileStream = new FileStream($@"{backupTask.Repository}\{backupTask.Name}\{backupObject.FileName}", FileMode.OpenOrCreate);
                    using FileStream compressedFileStream = File.Create($@"{backupTask.Repository}\{backupTask.Name}\{storage.Name}.gz");
                    using GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                    originalFileStream.CopyTo(compressor);
                }
            }
        }
    }
}