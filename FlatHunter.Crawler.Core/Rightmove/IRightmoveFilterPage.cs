namespace FlatHunter.Crawler.Core.Rightmove;

public interface IRightmoveFilterPage
{
    IRightmoveFilterPage SetMinBedrooms(int value);
    IRightmoveFilterPage SetMaxBedrooms(int value);
    IRightmoveFilterPage SetMaxPrice(int value);
    IRightmoveResultsPage ClickFindProperties();
}