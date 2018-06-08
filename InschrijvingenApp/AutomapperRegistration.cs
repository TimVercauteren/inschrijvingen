using AutoMapper;
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
                destination.Postcode = source.Ouders.Adres.Postcode;
                destination.Adres = $"{source.Ouders?.Adres?.Straat} {source.Ouders.Adres.Huisnummer} {source.Ouders.Adres.Bus}";
                destination.Email = source.Ouders.Email1;
                destination.GeboorteDatum = source.Kind.GeboorteDatum;
                destination.Naam = source.Kind.Persoon.Naam;
                destination.Voornaam = source.Kind.Persoon.Voornaam;
                destination.TelefoonNummer = source.Ouders.Telefoon1;

                return destination;
            }
        }
    }
}
