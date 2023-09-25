namespace FlatHunter.Console.PropertyFinders;

internal class StonehousePropertyFinder : SimpleOneHitPropertyFinder
{
    public StonehousePropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }

    protected override string Url { get; set; } = "https://stonehouse-estates.co.uk/property-search/?department=residential-lettings&minimum_price=&maximum_price=&minimum_rent=2000&maximum_rent=3000&minimum_bedrooms=3";
    protected override string CSSSelector { get; set; } = ".properties .thumbnail a";
}