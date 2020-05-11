using System;

namespace Command
{
    class AngryStatus : Status
    {
        public override void DoAction(Person p)
        {
            Console.WriteLine("Я меняюсь из злого статуса в боевой");
            
            p.Status = new BattleStatus();
        }

        public override void DoRelax(Person p)
        {
            Console.WriteLine("Я меняюсь из злого статуса в голодный");

            p.Status = new HungryStatus();
        }
    }
}
