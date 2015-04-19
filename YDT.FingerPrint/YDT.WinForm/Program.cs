using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YDT.WinForm.Model;

namespace YDT.WinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                #region 初始化全局变量
                LogEntry.Instance.WriteInfo("Application Started.");
                DocSetting.XMLSettingFullPath = Application.StartupPath + "\\YDTSetting.xml";
                DocSetting.Load();
                #endregion

                #region 全局捕获异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                #endregion

                #region 应用程序的主入口点
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UCWindow.FrmMain());
                Application.ApplicationExit += (sender, e) => LogEntry.Instance.WriteInfo("Application Closed.");
                #endregion
            }
            catch (Exception ex)
            {
                LogEntry.Instance.WriteError("Exception", ex);
                MessageBox.Show(ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Application_ThreadException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogEntry.Instance.WriteError("Thread Exception", e.Exception);
            MessageBox.Show(e.Exception.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        /// <summary>
        /// CurrentDomain_UnhandledException
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogEntry.Instance.WriteError("Unhandled Exception", e.ExceptionObject as Exception);
            MessageBox.Show("Unhandled Exception", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
