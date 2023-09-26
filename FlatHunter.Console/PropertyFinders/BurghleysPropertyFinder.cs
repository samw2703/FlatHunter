namespace FlatHunter.Console.PropertyFinders;

internal class BurghleysPropertyFinder : SimpleOneHitPropertyFinder
{
    public BurghleysPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }

    protected override string Url { get; set; } = "https://burghleys.com/property-to-rent/property/3-bed/all-location?pmin=450&pmax=3000";
    protected override string CSSSelector { get; set; } = "div > .card-image-container";
}