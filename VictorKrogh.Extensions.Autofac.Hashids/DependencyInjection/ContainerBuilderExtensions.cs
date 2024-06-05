using HashidsNet;
using VictorKrogh.Extensions.HashidsNet;

namespace Autofac.Extensions.DependencyInjection;

public static class ContainerBuilderExtensions
{
    public static ContainerBuilder RegisterHashIds(this ContainerBuilder containerBuilder, HashIdsOptions? hashIdsOptions)
    {
        ArgumentNullException.ThrowIfNull(hashIdsOptions, nameof(hashIdsOptions));

        containerBuilder.Register((cc, p) =>
        {
            return new Hashids(hashIdsOptions.Salt, hashIdsOptions.MinLength, hashIdsOptions.Alphabet, hashIdsOptions.Seps);
        }).As<IHashids>();

        containerBuilder.RegisterType<HashIdService>()
                        .As<IHashIdService>()
                        .SingleInstance();

        return containerBuilder;
    }
}