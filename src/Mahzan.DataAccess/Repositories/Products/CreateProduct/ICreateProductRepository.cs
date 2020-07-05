using Mahzan.DataAccess.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Products.CreateProduct
{
    public interface ICreateProductRepository
    {
        Task HandleRepository(CreateProductDto createProductDto);
    }
}
