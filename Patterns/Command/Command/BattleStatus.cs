using System;


namespace Command
{
    class BattleStatus : Status
    {
        public override void DoAction(Person p)
        {
            Console.WriteLine("Я не могу быть хуже боевого статуса. Расслабьте меня!!!");
        }

        public override void DoRelax(Person p)
        {
            Console.WriteLine("Я меняюсь из боевого статуса в злой");

            p.Status = new AngryStatus();
        }
    }
}
