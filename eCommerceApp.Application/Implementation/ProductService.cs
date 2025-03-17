using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Service.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Implementation
{
    class ProductService(IGeneric<Product> productInterface) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            int result = await productInterface.AddAsync(product);
        }

        public Task<ServiceResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CreateProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProduct> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
