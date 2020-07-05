using AutoMapper;
using Mahzan.Business.Events.Products.CreateProduct;
using Mahzan.DataAccess.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            #region Product

            CreateMap<CreateProductEvent, CreateProductDto>();

            #endregion
        }
    }
}
