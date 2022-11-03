using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;

namespace Standard
{
    public static class cLog
    {

        private class Logger
        {
            public Logger()
            {
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

                PatternLayout patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date{HH:mm:ss} %level - %message%newline";
                patternLayout.ActivateOptions();

                RollingFileAppender roller = new RollingFileAppender();
                roller.AppendToFile = true;
                roller.File = @"logs\";
                roller.MaxFileSize = 15;
                roller.Layout = patternLayout;
                roller.MaxSizeRollBackups = 5;
                roller.MaximumFileSize = "10MB";
                roller.RollingStyle = RollingFileAppender.RollingMode.Date;
                roller.DatePattern = "yyyy-MM-dd'.log'";
                roller.StaticLogFileName = false;
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);

                MemoryAppender memory = new MemoryAppender();
                memory.ActivateOptions();
                hierarchy.Root.AddAppender(memory);

                hierarchy.Root.Level = Level.Info;
                hierarchy.Configured = true;
            }
        }
        private static Logger oLogger = new Logger();
        private static readonly ILog oLog = LogManager.GetLogger(typeof(Logger));

        public static void C_SETxLogError(object poMessage)
        {
            oLog.Error(poMessage);
        }
        public static void C_SETxLogError(object poMessage, Exception poEx)
        {
            oLog.Error(poMessage,poEx);
        }
        public static void C_SETxLogInfo(object poMessage)
        {
            oLog.Info(poMessage);
        }
        public static void C_SETxLogInfo(object poMessage, Exception poEx)
        {
            oLog.Info(poMessage, poEx);
        }
        public static void C_SETxLogDebug(object poMessage)
        {
            oLog.Debug(poMessage);
        }
        public static void C_SETxLogDebug(object poMessage, Exception poEx)
        {
            oLog.Debug(poMessage, poEx);
        }
        public static void C_SETxLogWarn(object poMessage)
        {
            oLog.Warn(poMessage);
        }
        public static void C_SETxLogWarn(object poMessage, Exception poEx)
        {
            oLog.Warn(poMessage, poEx);
        }
    }
}
