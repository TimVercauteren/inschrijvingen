using AutoMapper;
using InschrijvenPietieterken.Entities;
using InschrijvingPietieterken.Controllers;
using InschrijvingPietieterken.Entities;
using InschrijvingPietieterken.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace InschrijvingPietieterken
{
    public static class AutoMapperRegistration
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(IEnumerable<>), typeof(List<>));
                cfg.CreateMap(typeof(List<>), typeof(List<>));
                cfg.CreateMap(typeof(ICollection<>), typeof(List<>));

                cfg.AddProfile<DataContractsToBusinessEntities>();
            });

            services.AddSingleton(Mapper.Configuration);

            return services;
        }

        class DataContractsToBusinessEntities : Profile
        {
            public DataContractsToBusinessEntities()
            {
                CreateMap<AdresModel, Adres>().ReverseMap();
                CreateMap<InschrijvingModel, Inschrijving>().ReverseMap();
                CreateMap<KindModel, Kind>().ReverseMap();
                CreateMap<MedischModel, Medisch>().ReverseMap();
                CreateMap<OudersModel, Ouders>().ReverseMap();
                CreateMap<PersoonModel, Persoon>().ReverseMap();
                CreateMap<Inschrijving, ChildPrintModel>().ConvertUsing(new AutoMapperConversions.ChildPrintModelConverter());
                CreateMap<Inschrijving, SearchKindModel>()
                    .ForMember(skm => skm.Id, opt => opt.MapFrom(i => i.Id))
                    .ForMember(skm => skm.Naam, opt => opt.MapFrom(i => i.Kind.Persoon.Naam))
                    .ForMember(skm => skm.Voornaam, opt => opt.MapFrom(i => i.Kind.Persoon.Voornaam));

            }
        }
    }

    public class AutoMapperConversions
    {
        public class ChildPrintModelConverter : ITypeConverter<Inschrijving, ChildPrintModel>
        {
            public ChildPrintModel Convert(Inschrijving source, ChildPrintModel destination, ResolutionContext context)
            {
                destination = new ChildPrintModel
                {
                    Postcode = source.Ouders.Adres.Postcode,
                    Adres = $"{source.Ouders?.Adres?.Straat} {source.Ouders.Adres.Huisnummer} {source.Ouders.Adres.Bus}",
                    Gemeente = source.Ouders.Adres.Gemeente,
                    Email = source.Ouders.Email1,
                    GeboorteDatum = source.Kind.GeboorteDatum.ToShortDateString(),
                    Naam = source.Kind.Persoon.Naam,
                    Voornaam = source.Kind.Persoon.Voornaam,
                    TelefoonNummer = source.Ouders.Telefoon1,
                    HeeftMaandAbonnement = source.HeeftMaandAbonnement
                };

                return destination;
            }
        }
    }
}
