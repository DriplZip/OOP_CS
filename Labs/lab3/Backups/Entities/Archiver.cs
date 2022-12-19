using System.IO;
using System.IO.Compression;
using Backups.Interfaces;

namespace Backups.Entities
{
    public class Archiver : IArchiver
    {
        public void Archive(string startPath, string compressedPath)
        {
            using FileStream startStream = new FileStream(startPath, FileMode.OpenOrCreate);
            using FileStream compressedStream = File.Create($"{compressedPath}.gz");
            using GZipStream compressor = new GZipStream(compressedStream, CompressionMode.Compress);
            startStream.CopyTo(compressor);
        }
    }
}