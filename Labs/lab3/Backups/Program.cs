using System;
using Backups.Algorithms;
using Backups.Entities;
using Backups.Interfaces;

namespace Backups
{
    class Program
    {
        static void Main(string[] args)
        {
            BackupTask backupTask = new BackupTask("Test", new SingleStorage(), new Repository("Repository"));
            
            backupTask.AddBackupObject(new BackupObject("1.txt", @"D:\Desktop\C#Study\labs\Labs\lab3\Backups\bin\Debug\net5.0\1.txt"));
            backupTask.AddBackupObject(new BackupObject("2.txt", @"D:\Desktop\C#Study\labs\Labs\lab3\Backups\bin\Debug\net5.0\2.txt"));
            backupTask.DoBackup();
        }
    }
}