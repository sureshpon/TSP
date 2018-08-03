using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Suresh.Fun.TravelScheduler
{
    /// <summary>
    /// Implementation of IFileAccss
    /// </summary>
    /// <seealso cref="Suresh.Fun.TravelScheduler.IFileAccess" />
    internal class FileAccess : IFileAccess
    {
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAccess"/> class.
        /// </summary>
        /// <param name="filePath">The path of the file</param>
        public FileAccess(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <returns>IEnumerable of strings</returns>
        public IEnumerable<string> ReadFile()
        {
            // Assumption: file entries are valid. only removes if any empty entries are present.

            return File.ReadLines(filePath).Where(e => !string.IsNullOrEmpty(e));
        }
    }
}