namespace Backups.Interfaces
{
    public interface IArchiver
    {
        public void Archive(string startPath, string compressedPath);
    }
}