using System.Diagnostics;

namespace Logging.LogWriters
{
    public sealed class DebugLogWriter : ILogWriter
    {
        #region Public Methods

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }

        #endregion Public Methods
    }
}
