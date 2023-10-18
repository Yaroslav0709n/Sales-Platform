using AutoMapper;
using Microsoft.AspNetCore.Http;
using SalesPlatform_Application.Dtos.Auth;
using SalesPlatform_Application.Dtos.User;
using SalesPlatform_Application.Extensions;
using SalesPlatform_Application.IServices;
using SalesPlatform_Domain.Entities.Identity;
using SalesPlatform_Infrastructure.Repositories;

namespace SalesPlatform_Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IRepository<ApplicationUser> userRepository,
                           IMapper mapper,
                           IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<UserDto> GetUserAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            return _mapper.Map<UserDto>(user);
        }
        public async Task<UserDto> GetCurrentUser()
        {
            var userId = _contextAccessor.HttpContext!.User.GetCurrentUserId().ToString();

            var user = await _userRepository.GetByIdAsync(userId);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUser)
        {
            var userId = _contextAccessor.HttpContext!.User.GetCurrentUserId().ToString();

            var userExist = await _userRepository.GetByIdAsync(userId);

            userExist.FirstName = updateUser.FirstName;
            userExist.LastName = updateUser.LastName;
            userExist.Email = updateUser.Email;
            userExist.City = updateUser.City;
            userExist.PhoneNumber = updateUser.PhoneNumber;

            var user = await _userRepository.UpdateAsync(userExist);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }
    }
}
