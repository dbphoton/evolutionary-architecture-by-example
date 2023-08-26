namespace EvolutionaryArchitecture.Fitnet.UnitTests.Contracts.PrepareContract.RequestValidator;

using EvolutionaryArchitecture.Fitnet.Contracts.PrepareContract;

internal sealed class InvalidPrepareContractRequestTestCases : IEnumerable<object[]>
{
    private readonly DateTimeOffset _fakeNow = new Faker().Date.RecentOffset();

    public IEnumerator<object[]> GetEnumerator()
    {
        var validContractParameters = PrepareContractParameters.GetValid();

        yield return new object[] { new PrepareContractRequest(Guid.Empty, validContractParameters.MinAge, validContractParameters.MaxHeight, _fakeNow), nameof(PrepareContractRequest.CustomerId) };
        yield return new object[] { new PrepareContractRequest(Guid.NewGuid(), default, validContractParameters.MaxHeight, _fakeNow), nameof(PrepareContractRequest.CustomerAge) };
        yield return new object[] { new PrepareContractRequest(Guid.NewGuid(), validContractParameters.MinAge, default, _fakeNow), nameof(PrepareContractRequest.CustomerHeight) };
        yield return new object[] { new PrepareContractRequest(Guid.NewGuid(), validContractParameters.MinAge, validContractParameters.MaxHeight, default),  nameof(PrepareContractRequest.PreparedAt) };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}