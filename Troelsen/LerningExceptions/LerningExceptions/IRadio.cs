
namespace LerningExceptions
{
    enum RadioStatus
    {
        Playing,
        Muted
    }

    interface IRadio
    {
        double Frequency { get; set; }

        RadioStatus currentStatus { get; }

        public string Caption { get; set; }
    }
}
