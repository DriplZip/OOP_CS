using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Entities;
using Backups.Models;

namespace Backups.Algorithms
{
    public class SplitStorage : IStorageAlgorithm
    {
        public List<Storage> StorageFiles(BackupTask backupTask, int archiveNumber)
        {
            int id = 0;
            
            List<Storage> storages = new List<Storage>();

            foreach (BackupObject backupObject in backupTask.BackupObjects)
            {
                Storage storage = new Storage($"SplitArchive{id++}({archiveNumber}).gz");
                
                using FileStream originalFileStream = new FileStream(backupObject.FileName, FileMode.OpenOrCreate);
                using FileStream compressedFileStream = File.Create(backupObject.FileName + ".gz");
                using GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                originalFileStream.CopyTo(compressor);
                
                storage.AddBackupObject(new BackupObject(compressedFileStream.Name));
                storages.Add(storage);
            }

            return storages;
        }
    }
}