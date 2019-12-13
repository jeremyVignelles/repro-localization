using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using System;
using System.Globalization;

namespace JeremyVignelles.TestLocalization
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = Options.Create(new LocalizationOptions {ResourcesPath = "Resources"});
            var factory = new Net5ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);// Use the implementation from aspnet/Extensions master
            
            CultureInfo.CurrentUICulture = new CultureInfo("en");
            var valuesLoc = factory.Create(typeof(Program));
            Console.WriteLine(valuesLoc["String1"]); // Expected: "EnglishValue"

            CultureInfo.CurrentUICulture = new CultureInfo("fr");
            Console.WriteLine(valuesLoc["String1"]); // Expected: "FrenchValue"
        }
    }
}
