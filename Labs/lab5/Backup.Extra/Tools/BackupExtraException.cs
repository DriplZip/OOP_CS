using System;

namespace Backup.Extra.Tools
{
    public class BackupExtraException : Exception
    {
        public BackupExtraException(string message)
            : base(message)
        {
            
        }
    }
}