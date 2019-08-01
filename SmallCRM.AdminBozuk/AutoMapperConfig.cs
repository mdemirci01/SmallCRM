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

            // customer'daki alanların değerlerini customerViewModel'e otomatik ata; ve tersini de yap.
            cfg.CreateMap<Customer, CustomerViewModel>().ReverseMap();
            Mapper.Initialize(cfg);
        }
    }
}