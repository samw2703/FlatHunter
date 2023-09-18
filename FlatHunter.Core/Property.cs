namespace FlatHunter.Core;

public class Property
{
    public EstateAgents EstateAgent { get; set; }
    public string Url { get; set; }
    public DateTime Found { get; set; }
}

public enum EstateAgents
{
    Rightmove
}