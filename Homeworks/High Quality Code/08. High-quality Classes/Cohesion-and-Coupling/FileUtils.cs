namespace CohesionAndCoupling
{
    using System;

    public class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int lastDotIndex = fileName.LastIndexOf(".");

            if (lastDotIndex == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(lastDotIndex + 1);
            
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int lastDotIndex = fileName.LastIndexOf(".");

            if (lastDotIndex == -1)
            {
                return fileName;
            }

            string fileNameWithoutExtension = fileName.Substring(0, lastDotIndex);

            return fileNameWithoutExtension;
        }
    }
}