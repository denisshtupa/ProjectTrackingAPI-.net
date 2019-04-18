// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ProjectTrackingServices.DependencyResolution {
    using AutoMapper;
    using ProjectTrackingServices.Models;
    using ProjectTrackingServices.Repository;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using System;
    using System.Linq;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {

            //Get all Profiles
            var profiles = from t in typeof(DefaultRegistry).Assembly.GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);

            //For each Profile, include that profile in the MapperConfiguration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            });

            //Create a mapper that will be used by the DI container
            var mapper = config.CreateMapper();

            //Register the DI interfaces with their implementation
            For<IMapperConfigurationExpression>();
            For<IMapper>().Use(mapper);

            //Register the ProjectsRepository and pass instance of Mapper to its constructor
            For<IProjectsRepository>().Use<ProjectsRepository>().Ctor<IMapper>().Is(mapper);

            //Register the EmployeeRepository and pass instance of Mapper to its constructor
            For<IEmployeesRepository>().Use<EmployeesRepository>().Ctor<IMapper>().Is(mapper);

            //Register the EmployeeRepository and pass instance of Mapper to its constructor
            For<IManagerCommentsRepository>().Use<ManagerCommentsRepository>().Ctor<IMapper>().Is(mapper);
            
            //Register the EmployeeRepository and pass instance of Mapper to its constructor
            For<IProjectTasksRepository>().Use<ProjectTasksRepository>().Ctor<IMapper>().Is(mapper);

            //Register the EmployeeRepository and pass instance of Mapper to its constructor
            For<IUserStoriesRepository>().Use<UserStoriesRepository>().Ctor<IMapper>().Is(mapper);

            //Scan(
            //    scan => {
            //        scan.TheCallingAssembly();
            //        scan.WithDefaultConventions();
            //    });
            //For<IExample>().Use<Example>();
        }

        #endregion
    }
}