namespace Backups.Entities
{
    public interface IArchiver
    {
        public void Archive(string originalPath, string compressedPath);
    }
}