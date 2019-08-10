using System;
using System.IO;
using XamarinUP2018.Services;

namespace XamarinUP2018.iOS.Services
{
    public class DataBaseAccessService : IDataBaseAccessService
    {
        public string GetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, AppConstants.OFFLINE_DATABASE_NAME);
        }
    }
}