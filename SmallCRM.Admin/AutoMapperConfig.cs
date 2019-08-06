using AutoMapper;
using AutoMapper.Configuration;
using SmallCRM.Admin.Models;
using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin
{
    public class AutoMapperConfig
    {
        public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Activity, ActivityViewModel>().ForMember(
        dest => dest.CampaignOwner,
        opt => opt.MapFrom(src => src.Campaign.Owner)).ForMember(
        dest => dest.CompanyOwner,
        opt => opt.MapFrom(src => src.Company.Owner)).ForMember(
        dest => dest.ContactOwner,
        opt => opt.MapFrom(src => src.Contact.Owner)).ForMember(
        dest => dest.OpportunityOwner,
        opt => opt.MapFrom(src => src.Opportunity.Owner)).ReverseMap();

            cfg.CreateMap<Contact, ContactViewModel>().ForMember(
        dest => dest.CityName,
        opt => opt.MapFrom(src => src.City.Name)).ForMember(
        dest => dest.CountryName,
        opt => opt.MapFrom(src => src.Country.Name)).ForMember(
        dest => dest.LeadSourceName,
        opt => opt.MapFrom(src => src.LeadSource.Name)).ForMember(
        dest => dest.OtherCityName,
        opt => opt.MapFrom(src => src.OtherCity.Name)).ForMember(
        dest => dest.OtherCountryName,
        opt => opt.MapFrom(src => src.OtherCountry.Name)).ForMember(
        dest => dest.OtherRegionName,
        opt => opt.MapFrom(src => src.OtherRegion.Name)).ForMember(
        dest => dest.RegionName,
        opt => opt.MapFrom(src => src.Region.Name)).ForMember(
        dest => dest.ReportsToContactOwner,
        opt => opt.MapFrom(src => src.ReportsToContact.Owner)).ReverseMap();

            Mapper.Initialize(cfg);
        }
    }
}