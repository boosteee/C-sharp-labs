using System;
using System.Collections.Generic;

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
                Console.WriteLine($"\n-------------------Боевые единицы {a} года рождения(выпуска):-------------------");
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
                Console.WriteLine($"\n------------------Имена трансформеров с  мощностью {power}---------------------");
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
                Console.WriteLine($"\nКоличество боевых единиц в армии - {army.list.Count}\n");
            }

        }
    }
    struct Date
    {
        public int day;
        public int month;
        public int year;
        enum Months
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        public void DateInfo()
        {
            Console.WriteLine($"Дата боевой операции {day} {(Months)month}(я) {year} года");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Army.Human Daniil = new() { name = "Даниил", age = 2003 };
            Army.Human Mikhail = new() { name = "Михаил", age = 2002 };
            Army.Human Ivan = new() { name = "Иван", age = 2002 };
            Army.Transformer Megatron = new() { name = "Мегатрон",age= 2020,power = 9};
            Army.Transformer Rachel = new() { name = "Рэчел", age = 2002, power = 8 };
            Army.Transformer Optimus = new() { name = "Оптимус Прайм",age= 2020,power = 9};
            Army army = new() { Branch = "Пехотинцы" };
            army.Add(Daniil);
            army.Add(Mikhail);
            army.Add(Ivan);
            army.Add(Megatron);
            army.Add(Rachel);
            army.Add(Optimus);
            army.Info();
            Army.Controller ac = new();
            ac.Power(army,9);
            ac.Age(army, 2002);
            ac.HowMuch(army);
            Date myDate = new() { day = 20, month = 1, year = 2027 };
            myDate.DateInfo();
        }
    }
}
