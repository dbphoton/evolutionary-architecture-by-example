namespace EvolutionaryArchitecture.Fitnet.Common.ErrorHandling;

internal static class ErrorHandlingExtensions
{
    internal static IApplicationBuilder UseErrorHandling(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ExceptionMiddleware>();

        return applicationBuilder;
    }
}