

namespace Logging.LogWriters
{
    public interface ILogWriter
    {
        /// <summary>
        /// Write the message to the log.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        void Log(string message);
    }
}
