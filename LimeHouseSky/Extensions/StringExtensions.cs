using LimeHouseSky.Strings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.ApplicationModel.Resources;

using static System.Reflection.MethodBase;

namespace LimeHouseSky.Extensions
{
    public static class StringExtensions
    {
        public static string GetLocalizedString(this string resourceName, PathResources resourcePath = PathResources.Resources)
        {
            string notFoundErrorString = $"{GetCurrentMethod()?.DeclaringType?.Name}.{GetCurrentMethod()?.Name}(): Can not found";
            string nullErrorString = $"{GetCurrentMethod()?.DeclaringType?.Name}.{GetCurrentMethod()?.Name}(): Null parameters";

            if (string.IsNullOrEmpty(resourceName))
            {
                Debug.WriteLine(nullErrorString);
                return resourceName;
            }

            var resourceLoader = ResourceLoader.GetForCurrentView(resourcePath.ToString());
            if (resourceLoader == null)
            {
                Debug.WriteLine($"{notFoundErrorString} {resourcePath.ToString()}");
                return resourceName;
            }

            var text = resourceLoader.GetString(resourceName);
            if (string.IsNullOrEmpty(text))
            {
                Debug.WriteLine($"{notFoundErrorString} {resourceName}");
                return resourceName;
            }

            return text;
        }
    }
}
