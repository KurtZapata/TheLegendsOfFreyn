using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Trial1_Movement_Classes_COMPROGPROJ
{
    internal class questTracking
    {
        private bool[] quest1;
        private bool[] quest2;

        public questTracking(int size)
        {
            quest1 = new bool[size];
            quest2 = new bool[size];
        }

        public bool[] Flags
        {
            get { return quest1; }
            set { quest1 = value; }
        }

        public bool[] Flags2
        {
            get { return quest2; }
            set { quest2 = value; }
        }

        public void Setquest1(int index, bool value)
        {
                Flags[index] = value;
        }
        public void Setquest2(int index, bool value)
        {
                Flags2[index] = value;
        }
    }
}
