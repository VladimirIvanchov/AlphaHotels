namespace AlphaHotel.Infrastructure.Censorship
{
    public interface ICensor
    {
        string CensorText(string text);
    }
}