using System;

namespace Prototype.IncapsulateActions
{
    [Serializable]
    class HorseActions : AnimalActions
    {
        public override void Shout()
        {
            Console.WriteLine("HORSE IS SHOUTING!! IGO-GO");
        }

        public override void Move()
        {
            Console.WriteLine("Horse is moving faster");
        }
    }
}
