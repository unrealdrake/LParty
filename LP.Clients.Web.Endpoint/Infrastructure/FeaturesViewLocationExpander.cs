using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace LP.Clients.Web.Endpoint.Infrastructure
{
    public sealed class FeaturesViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(FeaturesViewLocationExpander);
        }

        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            var viewLocationFormats = new[]
            {
                "~/Features/{1}/{0}.cshtml",
                "~/Features/{1}/{0}/{0}.cshtml",
                "~/Features/Shared/{0}.cshtml"
            };
            return viewLocationFormats;
        }
    }
}
