using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.PruebasPolly.NF452.Configuracion
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DealerToUnacemProfile>();
            });
        }
    }
}