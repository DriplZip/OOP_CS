using Backups.Entities;
using Backups.Interfaces;

namespace Backup.Extra.Entities
{
    public class BackupTaskExtra : BackupTask
    {
        public BackupTaskExtra(string backupName, IAlgorithm algorithm, IRepository repository, string logFilePath = "") : base(backupName, algorithm, repository)
        {
            if (logFilePath == "")
            {
                Logger = new ConsoleLogger();
            }
            else
            {
                Logger = new FileLogger(logFilePath);
            }
        }
        
        public ILogger Logger { get; }
        
    }
}