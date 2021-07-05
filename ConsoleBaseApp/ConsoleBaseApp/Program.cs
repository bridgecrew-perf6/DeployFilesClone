using ConsoleBaseApp.Utils;
using log4net;
using System;
using System.IO;

namespace ConsoleBaseApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //UnhandledExceptionイベントハンドラを登録
            System.Threading.Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);

            var logUtil = new LogUtil();
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                //すでに起動していると判断する
                logUtil.ConsoleWriteLineWithErrorLog("二重起動されました。", new Exception("Multi Executed Application"));
            }
            else
            {
                try
                {
                    logUtil.ConsoleWriteLineWithInfoLog("Start App.");
                    #region Write Your Program
                    
                    #endregion
                    logUtil.ConsoleWriteLineWithInfoLog("End App.");
                }
                catch (Exception ex)
                {
                    logUtil.ConsoleWriteLineWithErrorLog("Failed ConsoleBaseApp", ex);
                }
            }
        }

        private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //UIスレッド以外での予期しない例外発生時にプロセスを落とす（これをやっておかないとWindowsのアラートが出てプロセスが生きたままになってしまい死活監視での再起動ができない）
            try
            {
                var logUtil = new LogUtil();
                logUtil.ConsoleWriteLineWithErrorLog("Failed CollectLogs.Application_UnhandledException: ", (Exception)e.ExceptionObject);
            }
            finally
            {
                Environment.Exit(1);
            }
        }
    }
}
