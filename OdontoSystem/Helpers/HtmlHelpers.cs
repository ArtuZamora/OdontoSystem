using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace OdontoSystem.Helpers
{
    public static class HtmlHelpers
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        public static string IsSelected(this IHtmlHelper html, string? controller = null, string? action = null, string? genericCatalogData = null, string? cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];
            string currentGenericCatalogData = (string)html.ViewData["GenericCDTitle"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            if (String.IsNullOrEmpty(genericCatalogData))
                genericCatalogData = currentGenericCatalogData;

            var result = controller == currentController && action == currentAction && genericCatalogData == currentGenericCatalogData;
            return result ? cssClass : String.Empty;
        }

        public static string? PageClass(this IHtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    }
}
