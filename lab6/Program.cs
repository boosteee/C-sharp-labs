using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public partial class Army
    {
        public string Branch { get; set; }
        public List<ISmartCreature> list = new();
        
        public interface ISmartCreature
        {
            void Descrip();
            int GetAge();
            int GetPower();
            string GetName();
           
        }
        public class Human:ISmartCreature
        {
            public string name;
            public int age;

            public virtual void Descrip()
            {
                Console.WriteLine($"Солдат {name} {age} года рождения");
            }

            public int GetAge()
            {
                return age;
            }

            public string GetName()
            {
                return name;
            }

            public virtual int GetPower()
            {
                return 0;
            }
        }
        public class Transformer:Human,ISmartCreature
        {
            public int power;
            public override void Descrip()
            {
                Console.WriteLine($"Трансформер {name} {age} года выпуска имеет мощность {power}");
            }
            public override int GetPower()
            {
                return power;
            }

        }
        public class Controller
        {
            public void Age(Army army,int a)
            {
                Console.WriteLine($"Боевые единицы {a} года рождения(выпуска):");
                foreach (var item in army.list)
                {
                    if (item.GetAge()==a)
                    {
                        item.Descrip();
                    }
                }
            }
            public void Power(Army army,int power)
            {
                foreach (var item in army.list)
                {
                    if (item is Transformer)
                    {
                        if (item.GetPower() == power)
                        {
                            Console.WriteLine(item.GetName());
                        }
                        else continue;
                    }
                    else continue;
                }
            }
            public void HowMuch(Army army)
            {
                Console.WriteLine($"Количество боевых единиц в армии - {army.list.Count}");
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
