using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Service.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;

namespace eCommerceApp.Application.Implementation
{
    public class ProductService(IGeneric<Product> productInterface, IMapper mapper) : IProductService
    {
        public async Task<ServiceResponse> AddAsync(CreateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Product added successfully") :
    new ServiceResponse(false, "Product failed to be added");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await productInterface.DeleteAsync(id);
            return result > 0 ? new ServiceResponse(true, "Product deleted successfully") :
                new ServiceResponse(false, "Product not found");
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {
            var rawData = await productInterface.GetAllAsync();
            if (!rawData.Any()) return [];

            return mapper.Map<IEnumerable<GetProduct>>(rawData);
        }

        public async Task<GetProduct> GetByIdAsync(Guid id)
        {
            var rawData = await productInterface.GetByIdAsync(id);
            if (rawData is null) return new GetProduct();

            return mapper.Map<GetProduct>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProduct product)
        {
            var mappedData = mapper.Map<Product>(product);
            int result = await productInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Product updated successfully") :
    new ServiceResponse(false, "Product failed to be updated");
        }
    }
}
