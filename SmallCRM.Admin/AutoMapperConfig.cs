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
            cfg.CreateMap<Campaign, CampaignViewModel>().ReverseMap();

            Mapper.Initialize(cfg);
        }
    }
}