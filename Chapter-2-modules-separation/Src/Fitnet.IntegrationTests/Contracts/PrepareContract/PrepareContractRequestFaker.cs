namespace EvolutionaryArchitecture.Fitnet.IntegrationTests.Contracts.PrepareContract;

using Fitnet.Contracts.Api.Prepare;

internal sealed class PrepareContractRequestFaker : Faker<PrepareContractRequest>
{
    internal PrepareContractRequestFaker(int minAge, int maxAge, int minHeight, int maxHeight)
    {
        CustomInstantiator(faker =>
            new PrepareContractRequest(
                faker.Random.Number(minAge, maxAge),
                faker.Random.Number(minHeight, maxHeight),
                faker.Date.RecentOffset().ToUniversalTime()
            )
        );
    }
}