using Backups.Algorithms;
using Backups.Entities;
using Backups.Models;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace BackupsTests
{
    public class UnitTest1
    {
        [Fact]
        public void WhenBackupTask_AndAdd2BackupObjectsWithSplitStorageDelete1BackupObject_ThenRestorePointShouldBe2StorageShouldBe3()
        {
            // Arrange.
            BackupObject backupObject1 = new BackupObject(@"\1.txt");
            BackupObject backupObject2 = new BackupObject(@"\2.txt");
            BackupTask backupTask = new BackupTask("backupSplit", new SplitStorage(), new Repository(@"\repository"));

            // Act.
            backupTask.AddBackupObject(backupObject1);
            backupTask.AddBackupObject(backupObject2);
            backupTask.CreateBackup();
            
            backupTask.RemoveBackupObject(backupObject2);
            backupTask.CreateBackup();

            // Assert.
            Assert.Equal(2, backupTask.RestorePoints.Count);
            Assert.Equal(3, backupTask.RestorePoints.Sum(point => point.Storages.Count));
        }

        [Fact]
        public void WhenBackupTask_AndAdd2BackupObjectsWithSingleStorage_ThenFoldersAndFilesShouldBeCreated()
        {
            // Arrange.
            BackupObject backupObject1 = new BackupObject(@"1.txt");
            BackupObject backupObject2 = new BackupObject(@"2.txt");
            Repository repository = new Repository(@"repository");
            BackupTask backupTask = new BackupTask("backupSingle", new SingleStorage(), repository);

            DirectoryInfo directoryInfo1 =
                new DirectoryInfo(Path.Combine(repository.FullPath, backupTask.Name, backupObject1.FileName));
            DirectoryInfo directoryInfo2 =
                new DirectoryInfo(Path.Combine(repository.FullPath, backupTask.Name, backupObject2.FileName));

            // Act.
            backupTask.AddBackupObject(backupObject1);
            backupTask.AddBackupObject(backupObject2);
            backupTask.CreateBackup();
            
            // Assert.
            Assert.True(directoryInfo1.Exists);
            Assert.True(directoryInfo2.Exists);
        }
    }
}