using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduling
{
    class process
    {

        private string name;
        private int priority;
        private int length;
        private int arrivaltime;
        private bool completed;
        private bool cycle;

        public int Priority

        {

            get { return priority; }

            set { priority = value; }

        }
        public string Name

        {

            get { return name; }

            set { name = value; }

        }
        public int Length

        {

            get { return length; }

            set { length = value; }

        }
        public int Arrivaltime
        {

            get { return arrivaltime; }

            set { arrivaltime = value; }

        }
        public bool Completed
        {

            get { return completed; }

            set { completed = value; }

        }
        public bool Cycle
        {

            get { return cycle; }

            set { cycle = value; }

        }

        public string toString() {

            return "Name: " + this.Name + "\r\nLength: " + this.Length.ToString() + "\r\nPriority: " + this.Priority.ToString() + "\r\nArrival time: " + this.arrivaltime.ToString() + "\r\nCompleted: " + Completed.ToString();
        }
    }
}
