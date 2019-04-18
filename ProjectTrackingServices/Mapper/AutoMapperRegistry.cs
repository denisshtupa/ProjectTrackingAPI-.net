using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ProjectTrackingServices.Mapper
{
    public class AutoMapperRegistry: Registry
    {
        public AutoMapperRegistry()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>();
                //cfg.AddProfile<CommunityTemplateProfile>();
                //cfg.AddProfile<OrganisationProfile>();
                //cfg.AddProfile<CustomerProfile>();
            });

            var mapper = config.CreateMapper();

            //For<IConfigurationProvider>().Use(config);
            //For<IMapper>().Use(mapper);
        }
    }
}