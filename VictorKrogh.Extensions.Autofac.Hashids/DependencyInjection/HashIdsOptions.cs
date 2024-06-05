namespace Autofac.Extensions.DependencyInjection;

public class HashIdsOptions
{
    public const string HashIds = "HashIds";

    public string? Salt { get; set; }
    public int MinLength { get; set; } = 10;
    public string Alphabet { get; set; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    public string Seps { get; set; } = "cfhistuCFHISTU";
}
