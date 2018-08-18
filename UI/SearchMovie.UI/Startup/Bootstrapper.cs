using System.Configuration;
using Autofac;
using Prism.Events;
using RestSharp;
using SearchMovie.IService.ModelBuilder;
using SearchMovie.IService.Provider;
using SearchMovie.IService.RequestBuilder;
using SearchMovie.Service.ModelBuilder;
using SearchMovie.Service.Provider;
using SearchMovie.Service.RequestBuilder;
using SearchMovie.UI.ViewModel;

namespace SearchMovie.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var settings = ConfigurationManager.AppSettings;
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<RestClient>().As<IRestClient>().SingleInstance();

            builder.Register(x =>
                {
                    var domain = settings["domain"];
                    var appKey = settings["appkey"];
                    return new GatewaySettingsProvider(domain, appKey);
                })
                .As<IGatewaySettingsProvider>();

            builder.RegisterType<SearchProvider>().As<ISearchProvider>();
            builder.RegisterType<SearchResultModelBuilder>().As<ISearchResultModelBuilder>();
            builder.RegisterType<SearchRequestBuilder>().As<ISearchRequestBuilder>();

            builder.RegisterType<MainViewModel>().AsSelf();

            return builder.Build();
        }
    }
}
