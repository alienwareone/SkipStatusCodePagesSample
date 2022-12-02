using Microsoft.AspNetCore.Mvc;

public static class SkipStatusCodePagesMetadataExtensions
{
    public static IEndpointConventionBuilder SkipStatusCodePagesForApiControllers(this IEndpointConventionBuilder builder)
    {
        builder.Add(endpointBuilder =>
        {
            var apiControllerAttribute = endpointBuilder.Metadata
                .OfType<ApiControllerAttribute>()
                .FirstOrDefault();

            if (apiControllerAttribute == null)
            {
                return;
            }

            endpointBuilder.Metadata.Add(new SkipStatusCodePagesAttribute());
        });

        return builder;
    }
}