namespace FlatHunter.Console.PropertyFinders;

internal class DavidAstburyPropertyFinder : SimplePropertyFinder
{
    public DavidAstburyPropertyFinder(ExceptionStore exceptionStore)
        : base(exceptionStore)
    {
    }

    protected override string CSSSelector { get; set; } = ".property-listing-container .featured-image picture a";

    protected override string GetUrl(string postCode)
        => $"https://www.davidastburys.com/property/to-rent/in-{postCode}/3-and-more-bedrooms/between-2000-and-3000/";
}