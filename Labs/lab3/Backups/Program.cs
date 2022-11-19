using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.Algorithms;
using Backups.Entities;
using Backups.Models;
using Backups.Tools;

namespace Backups
{
    class Program
    {
        static void Main(string[] args)
        {
            /*BackupTask backupTask = new BackupTask("bc", new SingleStorage(), new Repository(@"D:\Desktop\C#Study\labs\Labs\lab3"));
            
            backupTask.AddBackupObject(new BackupObject(@"D:\Desktop\C#Study\labs\Labs\lab3\e.txt"));
            backupTask.CreateBackup();*/

            string start = @"D:\Desktop\C#Study\labs\Labs\lab3\e.txt";
            string compress = @"D:\Desktop\C#Study\labs\Labs\lab3\e.gz";
            BackupObject backupObject = new BackupObject(@"e.txt");
            Console.WriteLine(backupObject.FilePath);
            Console.WriteLine(backupObject.FileName);
            Console.WriteLine(Path.GetFullPath(@"e.txt"));
           // BackupObject backupObject = new BackupObject("e.txt");
            
            using FileStream originalFileStream = new FileStream(start, FileMode.OpenOrCreate);
            using FileStream compressedFileStream = File.Create(compress);
            using GZipStream compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);
            
            Console.WriteLine($"Сжатие файла {start} завершено.");
            Console.WriteLine($"Исходный размер: {originalFileStream.Length}  сжатый размер: {compressedFileStream.Length}");
        }
    }
}