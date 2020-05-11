using System;

namespace Command
{
    class HungryStatus : Status
    {
        public override void DoAction(Person p)
        {
            Console.WriteLine("Я меняюсь из голодного статуса в злой");

            p.Status = new AngryStatus();
        }

        public override void DoRelax(Person p)
        {
            Console.WriteLine("Я меняюсь из голодного статуса в нормальный");

            p.Status = new NormalStatus();
        }
    }
}
