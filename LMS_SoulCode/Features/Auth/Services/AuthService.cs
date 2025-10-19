using Microsoft.AspNetCore.Identity;
using LMS_SoulCode.Features.Auth.Models;
using LMS_SoulCode.Features.Auth.Repositories;

namespace LMS_SoulCode.Features.Auth.Services;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
public class AuthService : IAuthService
{
    private readonly IUserRepository _users;
    private readonly JwtTokenService _jwt;

    public AuthService(IUserRepository users, JwtTokenService jwt)
    {
        _users = users;
        _jwt = jwt;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await _users.GetByUsernameOrEmailAsync(request.UsernameOrEmail);
        if (user == null || user.PasswordHash != request.Password) // plain text
            throw new Exception("Invalid username or password");

        var (token, expires) = _jwt.CreateToken(user);
        return new LoginResponse(token, expires);
    }
}
