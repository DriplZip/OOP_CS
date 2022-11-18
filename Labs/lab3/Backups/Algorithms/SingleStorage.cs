using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Entities;
using Backups.Models;

namespace Backups.Algorithms
{
    public class SingleStorage : IStorageAlgorithm
    {
        public List<Storage> StorageFiles(BackupTask backupTask, int archiveNumber)
        {
            List<Storage> storages = new List<Storage>();

            Storage storage = new Storage($"SingleArchive{archiveNumber}.gz");
            
            foreach (BackupObject backupObject in backupTask.BackupObjects)
            {
                using FileStream originalFileStream = new FileStream(backupObject.FileName, FileMode.OpenOrCreate);
                using FileStream compressedFileStream = File.Create(backupObject.FileName + ".gz");
                using GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                originalFileStream.CopyTo(compressor);
                
                storage.AddBackupObject(new BackupObject(compressedFileStream.Name));
            }
            
            storages.Add(storage);

            return storages;
        }
    }
}