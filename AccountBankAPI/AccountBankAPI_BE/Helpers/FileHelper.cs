namespace AccountBankAPI.Helpers
{
    public class FileHelper
    {
        public static string generateFileName(string fileName)
        {
            var name = Guid.NewGuid().ToString().Replace("-", "");
            var lastIndex = fileName.LastIndexOf('.');
            var ext = fileName.Substring(lastIndex);
            return name + ext;
        }
            public static void DeleteFile(string fileName, string webRootPath)
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    var path = Path.Combine(webRootPath, "images", fileName);
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
            }
    }
}
