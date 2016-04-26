using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparX
{
    public class QueueElementCompletedEventArgs
    {
        int _index;
        /// <summary>
        /// Contains QueueElementCompleted event args
        /// </summary>
        /// <param name="index"></param>
        public QueueElementCompletedEventArgs(int index)
        {
            _index = index;
        }
        /// <summary>
        /// The index of the completed element
        /// </summary>
        public int Index { get { return _index; } }
    }
}
