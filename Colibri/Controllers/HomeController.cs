using System.Diagnostics;
using Colibri.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Colibri.Models;
using Colibri.Models.Commands.TeamMember;
using Colibri.Models.TeamMembers;

namespace Colibri.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITeamMemberService _teamMemberService;

    public HomeController(ILogger<HomeController> logger, ITeamMemberService teamMemberService)
    {
        _logger = logger;
        _teamMemberService = teamMemberService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}