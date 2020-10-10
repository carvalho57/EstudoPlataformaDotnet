using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Utils;

namespace ApiAuth.Services
{
    public class AccountService
    {
        private readonly UserRepository _userRepository;
        private readonly TokenService _tokenService;
        public AccountService(UserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public AccountResult Login(LoginModel model)
        {
            var user = _userRepository.GetByEmail(model.Email);

            if (user == null || !Hash.Compare(model.Password, user.Password))
                return new AccountResult(false, "E-mail ou senha inválidos");

            var token =  _tokenService.GenerateToken(user.Email);
            return new AccountResult(true, new {token = token});
        }
        public AccountResult CreateUser(UserModel model)
        {
            var emailExist = _userRepository.EmailExist(model.Email);

            if (emailExist)
                return new AccountResult(false, "Este E-mail já esta em uso");

            model.ChangePassword(Hash.Encript(model.Password));

            _userRepository.Add(model);
            return new AccountResult(true, model);
        }
    }
}