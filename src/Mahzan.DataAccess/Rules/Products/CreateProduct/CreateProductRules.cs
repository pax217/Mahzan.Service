using Mahzan.DataAccess.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.DataAccess.Rules.Products.CreateProduct
{
    public class CreateProductRules : DataConnection ,ICreateProductRules
    {
        public CreateProductRules(
            IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public async Task HandleRules(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
