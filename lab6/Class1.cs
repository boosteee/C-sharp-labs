using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public partial class Army
    {
        public void Add(ISmartCreature smartCreature)
        {
            list.Add(smartCreature);
        }
        public void Del(int a)
        {
            list.RemoveAt(a);
        }
        public void Info()
        {
            Console.WriteLine($"---------------------------Армия {Branch}--------------------------------");
            foreach (var item in list)
            {
                item.Descrip();
            }
        }
    }
}
