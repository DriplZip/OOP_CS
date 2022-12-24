using Backups.Entities;
using Backups.Interfaces;

namespace Backup.Extra.Entities
{
    public class Restore
    {
        public void RestoreFromPoint(BackupTaskExtra backupTaskExtra, IArchiver archiver, RestorePoint restorePoint, string path = "")
        {
            BackupTaskExtra tempBackupTask;
            
            if (path == "")
            {
                tempBackupTask = new BackupTaskExtra(backupTaskExtra.BackupName,
                    backupTaskExtra.BackupAlgorithm, backupTaskExtra.Repository);
            }
            
            tempBackupTask = new BackupTaskExtra(backupTaskExtra.BackupName,
                backupTaskExtra.BackupAlgorithm, new Repository(path));
           

            foreach (BackupObject backupObject in restorePoint.BackupObjects)
            {
                tempBackupTask.AddBackupObject(backupObject);
            }
            
            tempBackupTask.DoBackup(archiver);
        }
    }
}