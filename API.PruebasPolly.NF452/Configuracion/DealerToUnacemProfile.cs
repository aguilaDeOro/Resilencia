using API.PruebasPolly.NF452.Utils;
using AutoMapper;
using DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.PruebasPolly.NF452.Configuracion
{
    public class DealerToUnacemProfile
        : Profile
    {
        public DealerToUnacemProfile()
        {
            #region LineaCreditoConsolidado

            CreateMap<MacisaEECCResponseDto, DTOEstadoCuenta>()
                .ForMember(destination => destination.Detalle, option => option.MapFrom(source => source.Detalle))
                .AfterMap(this.MapDTOEstadoCuentaFromMacisaEECCResponseDto);


            CreateMap<MacisaDetailEECCResponseDto, DTOEstadoCuentaDET>()
                .ForMember(destination => destination.FechDocumento, option => option.MapFrom(source => Conversions.StringToDate(source.FchDocumento)))
                .ForMember(destination => destination.FechVencimiento, option => option.MapFrom(source => Conversions.StringToDate(source.FchVencimiento)))
                .ForMember(destination => destination.FechEstadoCuenta, option => option.MapFrom(source => Conversions.StringToDate(source.FchEstadoCuenta)))
                .ForMember(destination => destination.MontoTotalLinea, option => option.MapFrom(source => source.MontoTotal));

            #endregion
        }

        private void MapDTOEstadoCuentaFromMacisaEECCResponseDto(MacisaEECCResponseDto source, DTOEstadoCuenta destination)
        {
            destination.Cabecera = new DTOEstadoCuentaCAB
            {
                RucDistribuidor = source.RUCDistribuidor,
                RucCliente = source.RUCCliente,
                NombreCliente = source.NombreCliente,
                FechEstadoCuenta = Conversions.StringToDate(source.FchEstadoCuenta),
                FechActualizacion = Conversions.StringToDate(source.FechaActualizacion),
                LineaCreditoMN = source.LineaCreditoMN,
                LineaCreditoME = source.LineaCreditoME,
                LineaDisponibleMN = source.LineaDisponibleMN,
                LineaDisponibleME = source.LineaDisponibleME,
                CreditoUtilizadoMN = Convert.ToDecimal(source.LineaCreditoMN) - source.LineaDisponibleMN,
                CreditoUtilizadoME = Convert.ToDecimal(source.LineaCreditoME) - source.LineaDisponibleME,
                DeudaTotalME = source.DeutaTotalME,
                DeudaTotalMN = source.DeutaTotalMN,
                DocsPorVencerME = source.DocsPorVencerME,
                DocsPorVencerMN = source.DocsPorVencerMN,
                DocsVencidosME = source.DocsVencidosME,
                DocsVencidosMN = source.DocsVencidosMN
            };
        }
    }
}