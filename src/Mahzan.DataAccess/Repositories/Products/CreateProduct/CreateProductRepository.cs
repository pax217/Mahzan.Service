using Mahzan.DataAccess.DTO.Products.CreateProduct;
using Mahzan.DataAccess.Rules.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Repositories.Products.CreateProduct
{
    public class CreateProductRepository : DataConnection,ICreateProductRepository
    {
        private readonly ICreateProductRules _createProductRules;

        public CreateProductRepository(
            IDbConnection dbConnection,
            ICreateProductRules createProductRules) : base(dbConnection)
        {
            _createProductRules = createProductRules;
        }

        public async Task HandleRepository(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
