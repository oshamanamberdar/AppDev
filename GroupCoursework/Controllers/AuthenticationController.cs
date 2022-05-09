using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GroupCoursework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GroupCoursework.Controllers;

public class AuthenticationController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticationController(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        return View();
    }


    // GET: Authentication/Login
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(UserLoginModel loginModel)
    {
        var user = await _userManager.FindByNameAsync(loginModel.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles) authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var token = GetToken(authClaims);


            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction("UnauthorizedAccess");
    }

    // GET: Authentication/RegisterUser
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response {Status = "Error", Message = "User already exists!"});

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response
                    {Status = "Error", Message = "User creation failed! Please check user details and try again."});
        return RedirectToAction("Index", "Home");
    }

    // GET: Authentication/RegisterAdmin
    public IActionResult RegisterAdmin()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterAdmin(UserRegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response {Status = "Error", Message = "User already exists!"});

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response
                    {Status = "Error", Message = "User creation failed! Please check user details and try again."});

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        return RedirectToAction("RegisterAdmin", "Authentication");
    }

    public IActionResult UnauthorizedAccess()
    {
        return View();
    }


    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            _configuration["JWT:ValidIssuer"],
            _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
    
    public IActionResult RegisterUser()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterUser(UserRegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response {Status = "Error", Message = "User already exists!"});

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response
                    {Status = "Error", Message = "User creation failed! Please check user details and try again."});

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.User))
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        if (await _roleManager.RoleExistsAsync(UserRoles.User))
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        return RedirectToAction("Login", "Authentication");
    }
    
    
   
    public IActionResult RegisterAssistant()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegisterAssistant(UserRegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response {Status = "Error", Message = "User already exists!"});

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response
                    {Status = "Error", Message = "User creation failed! Please check user details and try again."});

        if (!await _roleManager.RoleExistsAsync(UserRoles.Assistant))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Assistant));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.Assistant))
            await _userManager.AddToRoleAsync(user, UserRoles.Assistant);
        if (await _roleManager.RoleExistsAsync(UserRoles.Assistant))
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        return RedirectToAction("Login", "Authentication");
    }
}