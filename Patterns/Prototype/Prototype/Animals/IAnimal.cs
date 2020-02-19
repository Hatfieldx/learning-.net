

namespace Prototype
{
    interface IAnimal
    {
        IAnimalAction actionsource { get; set; }
        string Name { get; set; }

        int Age { get; set; }

        int Speed { get; set; }

        int Wheit { get; set; }
       
        void Move();

        void Walk();

        void Shout();
    }
}
