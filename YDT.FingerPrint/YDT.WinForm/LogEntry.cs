
namespace YDT.WinForm
{
    using log4net;
    using log4net.Config;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// LogEntry
    /// </summary>
    public class LogEntry
    {
        #region Members
        /// <summary>
        /// The log
        /// </summary>
        private ILog log;

        /// <summary>
        /// The entry
        /// </summary>
        private static LogEntry entry;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static LogEntry Instance
        {
            get
            {
                if (entry == null)
                    entry = new LogEntry();
                return entry;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEntry"/> class.
        /// </summary>
        public LogEntry()
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Writes the error.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="e">The e.</param>
        public void WriteError(string msg, Exception e)
        {
            log.Error(GetExceptionMsg(e, msg));

            //  log.Error(msg, e);
        }

        /// <summary>
        /// Writes the information.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void WriteInfo(string msg)
        {
            log.Info(msg);
        }

        /// <summary>
        /// Writes the debug.
        /// Note: Out put only on debug condition 
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void WriteDebug(string msg)
        {
#if DEBUG
            log.Debug(msg);
#endif
        }
        #endregion

        #region Private Method
        /// <summary>
        /// GetExceptionMsg
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="backStr"></param>
        /// <returns></returns>
        private static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(System.Environment.NewLine);
            sb.AppendLine("-Time：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("-Exception Type：" + ex.GetType().Name);
                sb.AppendLine("-Exception Info：" + ex.Message);
                sb.AppendLine("-Stack Track：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("-Unhandled：" + backStr);
            }
            return sb.ToString();
        }
        #endregion
    }
}
