namespace FaultAlert
{
    public interface ISender
    {
        bool Send(string subject, string message);
    }
}
