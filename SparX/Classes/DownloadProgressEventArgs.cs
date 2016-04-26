using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparX
{
    public class DownloadProgressChangedEventArgs
    {
        int progress;
        int speed;
        public DownloadProgressChangedEventArgs(int progress, int speed)
        {
            this.progress = progress;
            this.speed = speed;
        }
        public int Progress
        {
            get { return progress; }
        }
        public int Speed
        {
            get { return speed; }
        }
    }
}
