using System.IO;
using Backups.Algorithms;
using Backups.Entities;
using Backups.Interfaces;
using Xunit;

namespace BackupsTests
{
    public class BackupTest
    {
        [Fact]
        public void Add2BackupObjectCreateBackupThenRemove1BackupObject()
        {
            BackupTask backupTask = new BackupTask("Test1", new SplitStorage(), new Repository("Repository"));
            BackupObject backupObject1 = new BackupObject("File1.txt", @"\File1.txt");
            BackupObject backupObject2 = new BackupObject("File2.txt", @"\File2.txt");
            backupTask.AddBackupObject(backupObject1);
            backupTask.AddBackupObject(backupObject2);
            backupTask.DoBackup();
            backupTask.RemoveBackupObject(backupObject1);
            backupTask.DoBackup();
            Assert.Equal(2, backupTask.Backups.RestorePoints.Count);
            Assert.Equal(3, backupTask.GetStorageCount());
        }
        
        [Fact]
        public void Add2BackupObjectCreateBackupFileCreated()
        {
            BackupTask backupTask = new BackupTask("Test2", new SingleStorage(), new Repository("Repository"));
            BackupObject backupObject1 = new BackupObject("File1.txt", @"\File1.txt");
            BackupObject backupObject2 = new BackupObject("File2.txt", @"\File2.txt");
            backupTask.AddBackupObject(backupObject1);
            backupTask.AddBackupObject(backupObject2);
            backupTask.DoBackup();
            Assert.True(Directory.Exists(backupTask.BackupPath));
        }
        
    }
}