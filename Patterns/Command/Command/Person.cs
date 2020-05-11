
namespace Command
{
    class Person
    {
        public string Name{ get; set; }

        public int Age { get; set; }

        public IPersonStatus Status { get; set; }

        public override string ToString()
        {
            return new string($"{Name} - {Age} - {Status}");
        }

        public void DoAction()
        {
            Status.DoAction(this);
        }

        public void DoRelax()
        {
            Status.DoRelax(this);
        }

        public Person(string name, int age, IPersonStatus s)
        {
            Name = name;
            Age = age;
            Status = s;
        }
    }
}
