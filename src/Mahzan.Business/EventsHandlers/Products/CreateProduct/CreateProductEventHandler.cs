using AutoMapper;
using Mahzan.Business.Events.Products.CreateProduct;
using Mahzan.DataAccess.DTO.Products.CreateProduct;
using Mahzan.DataAccess.Repositories.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Products.CreateProduct
{
    public class CreateProductEventHandler : ICreateProductEventHandler
    {
        private readonly ICreateProductRepository _createProductRepository;

        private readonly IMapper _mapper;

        public CreateProductEventHandler(
            ICreateProductRepository createProductRepository, 
            IMapper mapper)
        {
            _createProductRepository = createProductRepository;
            _mapper = mapper;
        }

        public async Task HandleEvent(CreateProductEvent createProductEvent)
        {
            await _createProductRepository
                .HandleRepository(
                    _mapper.Map<CreateProductDto>(createProductEvent)
                );
        }
    }
}
