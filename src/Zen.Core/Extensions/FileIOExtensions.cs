namespace System.IO
{
    public static class FileIOExtensions
    {
        /// <summary>
        /// Copies the file to a directory while maintaining the timestamp information of the original file
        /// </summary>
        /// <remarks>Throws <see cref="ArgumentNullException"/> if fileInfo or destination is null</remarks>
        /// <returns>FileInfo of copied file</returns>
        /// <exception cref="ArgumentNullException"/>
        public static FileInfo CarbonCopyTo(this FileInfo fileInfo, DirectoryInfo destination)
        {
            if(fileInfo is null)
                throw new ArgumentNullException(nameof(fileInfo));
            if(destination is null)
                throw new ArgumentNullException(nameof(destination));
            if(!destination.Exists)
                destination.Create();
            var newFileName = Path.Combine(destination.FullName, fileInfo.Name);
            var newFile = fileInfo.CopyTo(newFileName, overwrite: true);
            newFile.CreationTime = fileInfo.CreationTime;
            newFile.LastWriteTime = fileInfo.LastWriteTime;
            newFile.LastAccessTime = fileInfo.LastAccessTime;
            return newFile;
        }
    }
}