using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Translate.v2;
using TranslationsResource = Google.Apis.Translate.v2.Data.TranslationsResource;

namespace google_translator
{
    class Translate
    {
        private string key;
        private string lang;

        static void Main(string[] args)
        {    
            try
            {
                new Translate().Run(args[0]).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        }                
        
        private async Task Run(string srcText)
        {

            getEnvironment();

            var service = new TranslateService(new BaseClientService.Initializer()
                {
                    ApiKey = key,
                    ApplicationName = "Translate API Sample"
                });

            var response = await service.Translations.List(srcText, lang).ExecuteAsync();            

            foreach (TranslationsResource translation in response.Translations)
            {
                Console.WriteLine(translation.TranslatedText);
            }            
        }

        public void getEnvironment()
        {
            if(!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("KEY")))
            {
                key = Environment.GetEnvironmentVariable("KEY");
            }
            else
            {
                Console.WriteLine("Please, set environment for API Key from console.developers.googlec.com");
            }

            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("LANG")))
            {
                lang = Environment.GetEnvironmentVariable("LANG");
            }
            else
            {
                lang = "Pt";
            }
        }

    }
}
