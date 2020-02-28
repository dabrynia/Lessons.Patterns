using System;

namespace Lessons.Patterns.Behavior.Strategy
{
    public class LogProcessor
    {
        private ILogReader logReader;

        public LogProcessor(ILogReader logReader)
        {
            this.logReader = logReader;
        }

        public void ProcessLogs()
        {
            foreach(var LogEntry in logReader.Invode())
            {
                SaveLogEntry(LogEntry);
            }
        }

        private void SaveLogEntry(object logEntry)
        {
            throw new NotImplementedException();
        }
    }
}
