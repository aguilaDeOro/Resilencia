using BusinessLogic.EstadosCuenta;
using DataAccess.EstadosCuenta;
using DataAccess.SemillaTrabajo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using UNACEM.Common.Services;
using Unity;
using Unity.Injection;

namespace API.PruebasPolly.NF452.Configuracion
{
    public class DependencyResolver
    {
        public static UnityContainer DIContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<ILog, Log>(new InjectionConstructor(ConfigurationManager.AppSettings.Get("RutaLog"),
                                                                       ConfigurationManager.AppSettings.Get("LogFile")));


            HttpClient httpClient = new HttpClient();

            container.RegisterType<IDealerAccountStateMacisa, DealerAccountStateMacisa>
                    (new InjectionConstructor(container.Resolve<ILog>(), httpClient,
                            ConfigurationManager.AppSettings.Get("Serv_Estado_Cuenta_Macisa"),
                            Convert.ToInt32(ConfigurationManager.AppSettings.Get("RetryCount")),
                            Convert.ToInt32(ConfigurationManager.AppSettings.Get("SleepDurationBasePow"))));
            container.RegisterType<IAccountStateMacisa, AccountStateMacisa>();
            container.RegisterType<IAccountStateBusinessLogic, AccountStateBusinessLogic>();

            return container;
        }
    }
}