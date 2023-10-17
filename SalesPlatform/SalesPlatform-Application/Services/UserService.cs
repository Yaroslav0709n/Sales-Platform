using AutoMapper;
using SalesPlatform_Application.Dtos.Auth;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities.Identity;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<ApplicationUser> userRepository,
                           IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<UserDto> GetUser(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
