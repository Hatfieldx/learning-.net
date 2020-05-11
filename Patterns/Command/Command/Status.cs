
namespace Command
{
    abstract class Status : IPersonStatus
    {
        public abstract void DoAction(Person p);

        public abstract void DoRelax(Person p);
    }
}
