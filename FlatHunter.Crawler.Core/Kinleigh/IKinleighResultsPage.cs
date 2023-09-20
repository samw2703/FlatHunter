namespace FlatHunter.Crawler.Core.Kinleigh;

public interface IKinleighResultsPage : IWebPage
{
    IEnumerable<string> GetLinks();
}