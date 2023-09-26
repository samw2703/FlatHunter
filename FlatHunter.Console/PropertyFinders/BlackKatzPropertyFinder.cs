namespace FlatHunter.Console.PropertyFinders;

internal class BlackKatzPropertyFinder : SimpleOneHitPropertyFinder
{
    public BlackKatzPropertyFinder(ExceptionStore exceptionStore) : base(exceptionStore)
    {
    }

    protected override string Url { get; set; } = "https://blackkatz.com/listings/4_3bedroom-min_400-max_700";
    protected override string CSSSelector { get; set; } = ".propertylist li a";
}