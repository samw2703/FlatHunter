namespace FlatHunter.Core;

public class Property
{
    public EstateAgents EstateAgent { get; set; }
    public string Url { get; set; }
    public DateTime Found { get; set; }

    public static Property Create(EstateAgents estateAgent, string url)
    {
        return new Property
        {
            EstateAgent = estateAgent,
            Url = url,
            Found = DateTime.Now
        };
    }
}

public enum EstateAgents
{
    Rightmove,
    OpenRent,
}