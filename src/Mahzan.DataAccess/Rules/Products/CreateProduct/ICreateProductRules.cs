using Mahzan.DataAccess.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Products.CreateProduct
{
    public interface ICreateProductRules
    {
        Task HandleRules(CreateProductDto createProductDto);
    }
}
