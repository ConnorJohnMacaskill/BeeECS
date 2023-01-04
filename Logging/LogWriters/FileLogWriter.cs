using System;
using System.IO;

namespace Logging.LogWriters
{
    public sealed class FileLogWriter : ILogWriter
    {
        #region Fields

        private string filePath;

        #endregion Fields

        #region Constructor

        public FileLogWriter(string filePath)
        {
            this.filePath = filePath;
        }

        #endregion Constructor

        #region Public Methods

        public void Log(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }

        #endregion Public Methods
    }
}
