using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_FinalProj
{
    internal class LocItems
    {
        public string[] itemname;
        public int[] itemquan;

        public int[] playerstats;

        public string[] name1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
        public int[] quan1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        public int[] location;

        public LocItems()
        {
            itemname = name1;
            itemquan = quan1;
            playerstats = new int[8];
            location = new int[2];
            location[0] = 123;
            location[1] = 409;
        }

        public int[] location1
        {
            get { return location; }
            set { location = value; }
        }
        public string[] name
        {
            get { return itemname; }
            set { itemname = value; }
        }

        public int[] quan
        {
            get { return itemquan; }
            set { itemquan = value; }
        }

        public void setlocation(int index, int value)
        {
            location1[index] = value;
        }
        public void Setquest1(int index, string value)
        {
            name[index] = value;
        }

        public void setstats(int index, int value)
        {
            playerstats[index] = value;
        }

        public void addstats(string operation, int[] value)
        {
            if (operation == "add")
            {
                for (int i = 0; i < playerstats.Length; i++)
                {
                    playerstats[i] += value[i];
                }

            }
            else if (operation == "minus")
            {
                for (int i = 0; i < playerstats.Length; i++)
                {
                    playerstats[i] -= value[i];
                }
            }

        }
        public void quantity(int index, int value)
        {
            quan[index] = value;
        }

        public int[] availableItems()
        {
            int[] availableItem = new int[15];
            int[] itemindex = new int[15];
            for (int i = 0; i < itemname.Length; i++)
            {
                if (itemquan[i] != 0)
                {
                    for (int x = 0; x < itemname.Length; x++)
                    {
                        if (itemindex[0] == 0)
                        {
                            itemindex[x] = i;
                            break;
                        }
                        else if (itemindex[x] == 0 && x != 0)
                        {
                            itemindex[x] = i;
                            break;
                        }
                    }
                }
            }
            return itemindex;
        }

    }
}
