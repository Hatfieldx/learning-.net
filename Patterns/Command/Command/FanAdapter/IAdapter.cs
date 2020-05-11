
namespace Command.FanAdapter
{
    interface IAdapter<T, S>
    {   
        T ConvertTo(S adaptive);
    }
}
