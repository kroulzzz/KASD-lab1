using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Organization
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int YearFounded { get; set; }
        public int EmployeeCount { get; set; }

        public Organization(string name, string address, int yearFounded, int employeeCount)
        {
            Name = name;
            Address = address;
            YearFounded = yearFounded;
            EmployeeCount = employeeCount;
        }

        public virtual void ConductMeeting()
        {
            Console.WriteLine("Проводится общее собрание.");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("Организация: " + Name + " адрес: " + Address + " год основания: " + YearFounded + " сотрудников: " + EmployeeCount);
        }
    }

    class InsuranceCompany : Organization
    {
        public int PoliciesCount { get; set; }

        public InsuranceCompany(string name, string address, int yearFounded, int employeeCount, int policiesCount)
            : base(name, address, yearFounded, employeeCount)
        {
            PoliciesCount = policiesCount;
        }

        public void IssuePolicy()
        {
            Console.WriteLine("Страховая компания оформляет новый полис!");
        }

        public override void ConductMeeting()
        {
            Console.WriteLine("Страховая компания проводит собрание по оценке рисков.");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Количество страховых полисов: " + PoliciesCount);
        }
    }

    class OilGasCompany : Organization
    {
        public bool HasRefinery { get; set; }

        public OilGasCompany(string name, string address, int yearFounded, int employeeCount, bool hasRefinery)
            : base(name, address, yearFounded, employeeCount)
        {
            HasRefinery = hasRefinery;
        }

        public void DrillWell()
        {
            Console.WriteLine("Нефтегазовая компания начинает бурение скважины!");
        }

        public override void ConductMeeting()
        {
            Console.WriteLine("Нефтегазовая компания проводит собрание по добыче ресурсов.");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Имеет нефтеперерабатывающий завод: " + (HasRefinery ? "да" : "нет"));
        }
    }

    class Factory : Organization
    {
        public Factory(string name, string address, int yearFounded, int employeeCount)
            : base(name, address, yearFounded, employeeCount)
        {
        }

        public void StartProduction()
        {
            Console.WriteLine("Завод запускает производственную линию!");
        }

        public override void ConductMeeting()
        {
            Console.WriteLine("Завод проводит собрание по вопросам производства.");
        }

        public void Stop()
        {
            Console.WriteLine("Завод остановлен.");
        }
    }

    class LargeFactory : Factory
    {
        public LargeFactory(string name, string address, int yearFounded, int employeeCount)
            : base(name, address, yearFounded, employeeCount)
        {
        }

        public override void ConductMeeting()
        {
            Console.WriteLine("Крупный завод проводит стратегическое собрание по развитию.");
        }

        public void Stop()
        {
            Console.WriteLine("Крупный завод остановлен с сохранением всех производственных мощностей.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            InsuranceCompany insurance = new InsuranceCompany("Страховая защита", "Москва, ул. Страховая, 1", 1995, 250, 15000);
            OilGasCompany oilCompany = new OilGasCompany("НефтеГазПром", "Тюмень, ул. Нефтяников, 15", 1978, 5000, true);
            Factory factory = new Factory("МеталлПром", "Екатеринбург, пр. Заводской, 25", 1950, 800);
            LargeFactory largeFactory = new LargeFactory("АвтоВАЗ", "Тольятти, пр. Ленина, 1", 1966, 35000);

            insurance.DisplayInfo();
            insurance.ConductMeeting();
            insurance.IssuePolicy();
            Console.WriteLine();

            oilCompany.DisplayInfo();
            oilCompany.ConductMeeting();
            oilCompany.DrillWell();
            Console.WriteLine();

            factory.DisplayInfo();
            factory.ConductMeeting();
            factory.StartProduction();
            factory.Stop();
            Console.WriteLine();

            largeFactory.DisplayInfo();
            largeFactory.ConductMeeting();
            largeFactory.StartProduction();
            largeFactory.Stop();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
