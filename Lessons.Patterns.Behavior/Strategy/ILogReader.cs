using System.Collections.Generic;

namespace Lessons.Patterns.Behavior.Strategy
{
    /// <summary>
    /// определяет интерфейс алгоритма
    /// </summary>
    public interface ILogReader
    {
        void AlgorithmInterface();
        IEnumerable<object> Invode();
    }
}
