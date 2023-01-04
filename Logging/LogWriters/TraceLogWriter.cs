using System.Diagnostics;

namespace Logging.LogWriters
{
    public sealed class TraceLogWriter : ILogWriter
    {
        #region Public Methods

        public void Log(string message)
        {
            Trace.WriteLine(message);
        }

        #endregion Public Methods
    }
}
