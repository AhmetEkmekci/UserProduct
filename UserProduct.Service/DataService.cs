using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserProduct.DAL.Entity;
using UserProduct.DAL.Repository;
using UserProduct.Domain;

namespace UserProduct.Service
{
    public class DataService : IDataService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Cart> _cartRepository;
        public DataService(
                IRepository<User> userRepository,
                IRepository<Product> productRepository,
                IRepository<Cart> cartRepository,
                IMapper mapper
            )
        {
            this._userRepository = userRepository;
            this._productRepository = productRepository;
            this._cartRepository = cartRepository;
            this._mapper = mapper;
        }

        #region User
        public async Task<UserDto> GetUser(int Id)
        {
            var user = await _userRepository.GetById(Id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.Get(x => !x.IsDeleted && x.IsActive);
            return _mapper.Map<IEnumerable<UserDto>>(users.OrderBy(x => x.FirstName).ThenBy(x => x.LastName));
        }
        public async Task<IEnumerable<UserDto>> GetUsers(Expression<Func<User, bool>> predicate)
        {
            var users = await _userRepository.Get(x => !x.IsDeleted);
            return _mapper.Map<IEnumerable<UserDto>>(users.OrderBy(x => x.FirstName).ThenBy(x => x.LastName));
        }
        #endregion

        #region Product
        public async Task<ProductDto> GetProduct(int Id)
        {
            var Product = await _productRepository.GetById(Id);
            return _mapper.Map<ProductDto>(Product);
        }
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var Products = await _productRepository.Get(x => !x.IsDeleted && x.IsActive);
            return _mapper.Map<IEnumerable<ProductDto>>(Products.OrderBy(x => x.Name).ThenBy(x => x.Price));
        }
        public async Task<IEnumerable<ProductDto>> GetProducts(Expression<Func<Product, bool>> predicate)
        {
            var Products = await _productRepository.Get(x => !x.IsDeleted);
            return _mapper.Map<IEnumerable<ProductDto>>(Products.OrderBy(x => x.Name).ThenBy(x => x.Price));
        }
        #endregion

        #region Cart
        public async Task<List<CartDto>> GetUserCart(int UserId)
        {
            var result = await _cartRepository.Get(x => x.UserId == UserId);
            return _mapper.Map<List<CartDto>>(result);
        }
        public async Task UpdateCart(CartDto cart)
        {
            await _cartRepository.DeleteRange(x=>x.UserId == cart.UserId && x.ProductId == cart.ProductId);

            await _cartRepository.Insert(_mapper.Map<Cart>(cart));
        }
        public async Task DeleteCart(int UserId, int ProductId)
        {
            await _cartRepository.DeleteRange(x => x.UserId == UserId && x.ProductId == ProductId);
        }
        public async Task ClearUserCart(int UserId)
        {
            await _cartRepository.DeleteRange(x=>x.UserId == UserId);
        }
        #endregion

    }
}
