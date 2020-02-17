
namespace LerningExceptions
{
    enum CarStatus
    {
        Moving,
        Stopped
    }

    interface ICar
    {
        string Model { get; set; }

        string Factory { get; set; }

        int MaxSpeed { get; }
        int CurrentSpeed { get; }

        CarStatus CurrentStatus { get; }

        void Start();

        void Stop();
    }
}
