using System;
using System.Buffers;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using Backups.Algorithms;
using Backups.Entities;
using Backups.Models;

namespace Backups.Extra
{
    class Program
    {
        static void Main(string[] args)
        {
            BackupTask backupTask = new BackupTask("backup", new SingleStorage(), new Repository("rep"), new ArchiverGz());
            backupTask.AddBackupObject(new BackupObject("e.txt"));
            backupTask.CreateBackup();
            BinaryFormatter formatter = new BinaryFormatter(); 
            formatter.Serialize(new FileStream("backup.txt", FileMode.OpenOrCreate), backupTask);

            /*string json = File.ReadAllText("backup.json");
            BackupTask backupTask = JsonSerializer.Deserialize<BackupTask>(json);*/
            
        }
    }
}