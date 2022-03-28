using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiValueDictionary.ClassLibrary.Interfaces;
using MultiValueDictionary.ClassLibrary.Repository;
using MultiValueDictionary.ClassLibrary.Services;
using System;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
             host.Services.GetService<Worker>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => {
                    services.AddTransient<IDictionaryService, DictionaryService>();
                    services.AddTransient<IDictionaryRepository, DictionaryRepository>();
                    services.AddTransient<Worker>();

                    }
                );
        }
    }
}
