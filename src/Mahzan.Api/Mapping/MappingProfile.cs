﻿using AutoMapper;
using Mahzan.Api.Commands.SalesDepartments.CreateSaleDepartmentFull;
using Mahzan.DataAccess.DTO.SalesDepartments.CreateSalesDepartmentsFull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateSalesCategoriesFullCommand, CreateSalesCategoriesFullDto>();
            CreateMap<CreateSalsesSectionsFullCommand, CreateSalsesSectionsFullDto>()
                .ForMember(
                    dest => dest.ListCreateSalesCategoriesFullDto,
                    opt => opt.MapFrom(
                            src => src.ListCreateSalesCategoriesFullCommand
                        )
                );

            CreateMap<CreateSaleAreasFullCommand, CreateSaleAreasFullDto>()
                .ForMember(
                    dest => dest.ListCreateSalsesSectionsFullDto,
                    opt => opt.MapFrom(
                            src => src.CreateSalsesSectionsFullCommand
                        )
                );
            CreateMap<CreateSalesDepartmentFullCommand, CreateSalesDepartmentFullDto>()
                .ForMember(
                    dest => dest.ListCreateSaleAreasFullDto,
                    opt => opt.MapFrom(
                            src => src.ListCreateSaleAreasFullCommand
                        )
                );
            CreateMap<CreateSalesDepartmentsFullCommand, CreateSalesDepartmentsFullDto>()
                .ForMember(
                    dest => dest.ListCreateSalesDepartmentFullDto,
                    opt => opt.MapFrom(
                            src => src.ListCreateSalesDepartmentFullCommand
                        )
                );


        }
    }
}
