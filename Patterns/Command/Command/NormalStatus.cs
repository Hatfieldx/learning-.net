using System;

namespace Command
{
    class NormalStatus : Status
    {
        public override void DoAction(Person p)
        {
            Console.WriteLine("Я меняюсь из нармального статуса в голодный");

            p.Status = new HungryStatus();
        }

        public override void DoRelax(Person p)
        {
            Console.WriteLine("Я не могу расслабить ниже нормального статуса");
        }
    }
}
