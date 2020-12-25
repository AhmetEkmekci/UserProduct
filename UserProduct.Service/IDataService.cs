using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserProduct.DAL.Entity;
using UserProduct.Domain;

namespace UserProduct.Service
{
    public interface IDataService
    {
        Task ClearUserCart(int UserId);
        Task DeleteCart(int UserId, int ProductId);
        Task<ProductDto> GetProduct(int Id);
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<IEnumerable<ProductDto>> GetProducts(Expression<Func<Product, bool>> predicate);
        Task<UserDto> GetUser(int Id);
        Task<List<CartDto>> GetUserCart(int UserId);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<IEnumerable<UserDto>> GetUsers(Expression<Func<User, bool>> predicate);
        Task UpdateCart(CartDto cart);
    }
}