using System.IO;

namespace FileRenamer
{
    public class FileProcessor
    {
        public static void ProcessFolder(string folderPath, string userInput)
        {
            var files = Directory.GetFiles(folderPath);
            int count = 1;

            foreach (var filePath in files)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                if (fileInfo.Length <= 4096 || fileInfo.Extension == ".xmp")
                {
                    File.Delete(filePath);
                }
                else
                {
                    string newFileName = userInput + "-" + count.ToString() + fileInfo.Extension;
                    string newFilePath = Path.Combine(folderPath, newFileName);

                    if (!File.Exists(newFilePath))
                    {
                        File.Move(filePath, newFilePath);
                        count++;
                    }
                }
            }
        }
    }
}
