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
            cfg.AllowNullCollections = true;
            cfg.AllowNullDestinationValues = true;
            cfg.CreateMap<Activity, ActivityViewModel>().ForMember(
            dest => dest.CampaignOwner,
            opt => opt.MapFrom(src => src.Campaign.Owner)).ForMember(
            dest => dest.CompanyOwner,
            opt => opt.MapFrom(src => src.Company.Owner)).ForMember(
            dest => dest.ContactOwner,
            opt => opt.MapFrom(src => src.Contact.Owner)).ForMember(
            dest => dest.OpportunityOwner,
            opt => opt.MapFrom(src => src.Opportunity.Owner)).ReverseMap().ForMember(
                dest => dest.Contact, opt => opt.Ignore()).ForMember(
                dest => dest.Company, opt => opt.Ignore()).ForMember(
                dest => dest.Opportunity, opt => opt.Ignore()).ForMember(
                dest => dest.Campaign, opt => opt.Ignore());

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
            opt => opt.MapFrom(src => src.ReportsToContact.Owner)).ReverseMap().ForMember(dest => dest.Company, opt => opt.Ignore()).ForMember(dest => dest.LeadSource, opt => opt.Ignore()).ForMember(dest => dest.ReportsToContact, opt => opt.Ignore()).ForMember(dest => dest.ChildContacts, opt => opt.Ignore()).ForMember(dest => dest.Activities, opt => opt.Ignore()).ForMember(dest => dest.Opportunities, opt => opt.Ignore()).ForMember(dest => dest.Country, opt => opt.Ignore()).ForMember(dest => dest.City, opt => opt.Ignore()).ForMember(dest => dest.Region, opt => opt.Ignore()).ForMember(dest => dest.OtherCountry, opt => opt.Ignore()).ForMember(dest => dest.OtherCity, opt => opt.Ignore()).ForMember(dest => dest.OtherRegion, opt => opt.Ignore()).ForMember(dest => dest.Country, opt => opt.Ignore()); ;

            cfg.CreateMap<Campaign, CampaignViewModel>().ReverseMap().ForMember(dest => dest.Activities, opt => opt.Ignore());

            cfg.CreateMap<CampaignSource, CampaignSourceViewModel>().ReverseMap().ForMember(dest => dest.Opportunities, opt => opt.Ignore());

            cfg.CreateMap<City, CityViewModel>().ForMember(
            dest => dest.CountryName,
            opt => opt.MapFrom(src => src.Country.Name)).ReverseMap().ForMember(dest => dest.Country, opt => opt.Ignore()).ForMember(dest => dest.Regions, opt => opt.Ignore()).ForMember(dest => dest.Leads, opt => opt.Ignore()).ForMember(dest => dest.PostalContacts, opt => opt.Ignore()).ForMember(dest => dest.OtherContacts, opt => opt.Ignore()).ForMember(dest => dest.InvoiceCompanies, opt => opt.Ignore()).ForMember(dest => dest.DeliveryCompanies, opt => opt.Ignore());

            cfg.CreateMap<Company, CompanyViewModel>().ForMember(
            dest => dest.CompanyTypeName,
            opt => opt.MapFrom(src => src.CompanyType.Name)).ForMember(
            dest => dest.DeliveryCityName,
            opt => opt.MapFrom(src => src.DeliveryCity.Name)).ForMember(
            dest => dest.DeliveryCountryName,
            opt => opt.MapFrom(src => src.DeliveryCountry.Name)).ForMember(
            dest => dest.DeliveryRegionName,
            opt => opt.MapFrom(src => src.DeliveryRegion.Name)).ForMember(
            dest => dest.InvoiceCityName,
            opt => opt.MapFrom(src => src.InvoiceCity.Name)).ForMember(
            dest => dest.InvoiceCountryName,
            opt => opt.MapFrom(src => src.InvoiceCountry.Name)).ForMember(
            dest => dest.InvoiceRegionName,
            opt => opt.MapFrom(src => src.InvoiceRegion.Name)).ForMember(
            dest => dest.MainCompanyOwner,
            opt => opt.MapFrom(src => src.MainCompany.Owner)).ForMember(
            dest => dest.SectorName,
            opt => opt.MapFrom(src => src.Sector.Name)).ReverseMap();

            cfg.CreateMap<CompanyType, CompanyTypeViewModel>().ReverseMap();

            cfg.CreateMap<Country, CountryViewModel>().ReverseMap();

            cfg.CreateMap<Document, DocumentViewModel>().ReverseMap().ForMember(dest => dest.Feeds, opt => opt.Ignore());

            cfg.CreateMap<Lead, LeadViewModel>().ForMember(
            dest => dest.RegionName,
            opt => opt.MapFrom(src => src.Region.Name)).ForMember(
            dest => dest.CityName,
            opt => opt.MapFrom(src => src.City.Name)).ForMember(
            dest => dest.CountryName,
            opt => opt.MapFrom(src => src.Country.Name)).ForMember(
            dest => dest.LeadSourceName,
            opt => opt.MapFrom(src => src.LeadSource.Name)).ForMember(
            dest => dest.LeadStatusName,
            opt => opt.MapFrom(src => src.LeadStatus.Name)).ForMember(
            dest => dest.SectorName,
            opt => opt.MapFrom(src => src.Sector.Name)).ReverseMap().ForMember(dest => dest.Country, opt => opt.Ignore());


            cfg.CreateMap<LeadSource, LeadSourceViewModel>().ReverseMap();

            cfg.CreateMap<LeadStatus, LeadStatusViewModel>().ReverseMap();

            cfg.CreateMap<Opportunity, OpportunityViewModel>().ForMember(
            dest => dest.CampaignSourceName,
            opt => opt.MapFrom(src => src.CampaignSource.Name)).ForMember(
            dest => dest.CompanyOwner,
            opt => opt.MapFrom(src => src.Company.Owner)).ForMember(
            dest => dest.ContactOwner,
            opt => opt.MapFrom(src => src.Contact.Owner)).ForMember(
            dest => dest.LeadSourceName,
            opt => opt.MapFrom(src => src.LeadSource.Name)).ReverseMap();

            cfg.CreateMap<Project, ProjectViewModel>().ReverseMap().ForMember(dest => dest.StartDate, opt => opt.Ignore()).ForMember(dest => dest.WorkItemStatus, opt => opt.Ignore()).ForMember(dest => dest.WorkItems, opt => opt.Ignore()).ForMember(dest => dest.TimeSpendings, opt => opt.Ignore());

            cfg.CreateMap<Region, RegionViewModel>().ForMember(
            dest => dest.CityName,
            opt => opt.MapFrom(src => src.City.Name)).ReverseMap();

            cfg.CreateMap<Report, ReportViewModel>().ReverseMap();

            cfg.CreateMap<Sector, SectorViewModel>().ReverseMap();

            cfg.CreateMap<WorkItem, WorkItemViewModel>().ForMember(
            dest => dest.ProjectName,
            opt => opt.MapFrom(src => src.Project.Name)).ReverseMap();
            Mapper.Initialize(cfg);

            cfg.CreateMap<TimeSpending, TimeSpendingViewModel>().ForMember(
            dest => dest.ProjectName,
            opt => opt.MapFrom(src => src.Project.Name)).ForMember(
            dest => dest.WorkItemName,
            opt => opt.MapFrom(src => src.WorkItem.Name)).ReverseMap();

            cfg.CreateMap<Feed, FeedViewModel>().ForMember(
            dest => dest.DocumentName,
            opt => opt.MapFrom(src => src.Document.Name)).ReverseMap().ForMember(dest => dest.Document, opt => opt.Ignore());
        }
    }
}