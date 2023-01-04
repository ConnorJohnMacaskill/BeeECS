using Logging.Enums;
using Logging.LogWriters;
using System.Collections.Generic;
using System.Linq;

namespace Logging
{
    public static class Logger
    {
        #region Fields

        private static List<ILogWriter> logWriters;
        private static string prefix;

        private const string MESSAGE_PREFIX = "[Message]";
        private const string WARNING_PREFIX = "[Warning]";
        private const string ERROR_PREFIX = "[Error]";
        private const string UNSPECIFIED_PREFIX = "[Unspecified]";

        #endregion Fields

        #region Public Properties

        /// <summary>
        /// Enable or disable the logger, if disabled no messages will be logged.
        /// </summary>
        public static bool Enabled { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Enable the logger and set the log writers to use.
        /// </summary>
        /// <param name="prefix">Prefix to append to every logged messages.</param>
        /// <param name="logWriters">All the log writers the logger will log to.</param>
        public static void Initialise(string prefix, params ILogWriter[] logWriters)
        {
            Logger.logWriters = logWriters.ToList();
            Logger.prefix = prefix;
            Enabled = true;
        }

        /// <summary>
        /// Log a message using every log writer.
        /// </summary>
        /// <param name="logType">The type of log, affects the message prefix.</param>
        /// <param name="message">The message to log.</param>
        public static void Log(LogType logType, string message)
        {
            if(Enabled)
            {
                string formattedText = "";

                switch (logType)
                {
                    case LogType.Message:
                        formattedText = string.Format("{0} - {1}", MESSAGE_PREFIX, message);
                        break;
                    case LogType.Warning:
                        formattedText = string.Format("{0} - {1}", WARNING_PREFIX, message);
                        break;
                    case LogType.Error:
                        formattedText = string.Format("{0} - {1}", ERROR_PREFIX, message);
                        break;
                    default:
                        formattedText = string.Format("{0} - {1}", UNSPECIFIED_PREFIX, message);
                        break;

                }

                formattedText = string.Format("{0} - {1}", prefix, formattedText);

                logWriters.ForEach(x => x.Log(formattedText));
            }
        }

        #endregion Public Methods
    }
}
