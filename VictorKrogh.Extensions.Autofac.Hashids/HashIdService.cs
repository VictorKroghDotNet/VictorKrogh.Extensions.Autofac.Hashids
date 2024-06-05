using HashidsNet;

namespace VictorKrogh.Extensions.HashidsNet;

public interface IHashIdService
{
    ValueTask<bool> TryDecodeAsync(string? hash, out int id);

    ValueTask<int> DecodeAsync(string? hash);
    ValueTask<string> EncodeAsync(int x);
}

internal sealed class HashIdService(IHashids hashids) : IHashIdService
{
    public ValueTask<int> DecodeAsync(string? hash)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(hash);

        return ValueTask.FromResult(hashids.DecodeSingle(hash));
    }

    public ValueTask<string> EncodeAsync(int x)
    {
        return ValueTask.FromResult(hashids.Encode(x));
    }

    public ValueTask<bool> TryDecodeAsync(string? hash, out int id)
    {
        if (string.IsNullOrWhiteSpace(hash))
        {
            id = default;
            return ValueTask.FromResult(false);
        }

        try
        {
            return ValueTask.FromResult(hashids.TryDecodeSingle(hash, out id));
        }
        catch (Exception)
        {
            id = default;
            return ValueTask.FromResult(false);
        }
    }
}
