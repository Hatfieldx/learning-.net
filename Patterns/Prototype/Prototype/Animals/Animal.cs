using System;


namespace Prototype
{
    [Serializable]
    class Animal : IAnimal
    {
        public IAnimalAction actionsource { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Speed { get; set; }
        public int Wheit { get; set; }

        public virtual void Move()
        {
            actionsource.Move();
        }

        public virtual void Shout()
        {
            actionsource.Shout();
        }

        public virtual void Walk()
        {
            actionsource.Walking();
        }

        public override string ToString()
        {
            return $"{Name} - {Age} - {Speed} - {Wheit}";
        }

        public Animal(string name, int age, int speed, IAnimalAction actiontype)
        {
            if (actiontype == null)
                throw new NullReferenceException("actiontype cannot be null");
            
            this.actionsource = actiontype;

            Name = name;
            Age = age;
            Speed = speed;
        }
    }
}
