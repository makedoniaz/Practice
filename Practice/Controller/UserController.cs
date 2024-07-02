using Microsoft.AspNetCore.Mvc;
using Practice.Dtos;
using Practice.Models;
using Practice.Repositories.Base;

namespace Practice.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HomeController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public HomeController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await userRepository.GetAllAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        var changesCount = await userRepository.CreateAsync(user);

        return Ok(changesCount);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var changesCount = await userRepository.DeleteByIdAsync(userId);

        return Ok(changesCount);
    }

    [HttpPut]
    public async Task<IActionResult> PutUserAsync(LoginDto loginDto, int userId)
    {
        var changesCount = await userRepository.PutAsync(loginDto, userId);

        return Ok(changesCount);
    }
}
