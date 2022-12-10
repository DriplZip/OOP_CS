using System;
using System.Buffers;
using System.IO;
using System.Text.Json;
using Backups.Algorithms;
using Backups.Entities;
using Backups.Extra.Algorithms;
using Backups.Extra.Entities;
using Backups.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Backups.Extra
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
            };
            
            BackupTaskExtra backupTask = new BackupTaskExtra("backup", new SingleStorage(), new Repository("rep"), new ArchiverGz(), new CleanupByCount(2));

            AppConfig<BackupTaskExtra> appConfig = new AppConfig<BackupTaskExtra>("backup.json", backupTask);
            
            appConfig.Save();

            BackupTaskExtra test = appConfig.Load();
        }
    }
}