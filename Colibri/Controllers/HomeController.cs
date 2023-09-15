using System.Diagnostics;
using System.Globalization;
using Colibri.Infrastructure;
using Colibri.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Colibri.Models;
using Colibri.Models.Commands.Partners;
using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Commands.Product;
using Colibri.Models.Commands.Review;
using Colibri.Models.Commands.Statistic;
using Colibri.Models.Commands.TeamMember;

namespace Colibri.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITeamMemberService _teamMemberService;
    private readonly IStatisticService _statisticService;
    private readonly IReviewService _reviewService;
    private readonly IProductService _productService;
    private readonly IPortfolioService _portfolioService;
    private readonly IPartnersService _partnersService;

    public HomeController(ILogger<HomeController> logger, 
        ITeamMemberService teamMemberService,
        IPortfolioService portfolioService,
        IProductService productService, IReviewService reviewService,
        IStatisticService statisticService,
        IPartnersService partnersService)
    {
        _logger = logger;
        _teamMemberService = teamMemberService;
        _portfolioService = portfolioService;
        _productService = productService;
        _reviewService = reviewService;
        _statisticService = statisticService;
        _partnersService = partnersService;
    }

    public async Task<IActionResult> Index(CancellationToken token = default)
    {
        ViewBag.TeamMembers = await _teamMemberService.GetAll(new GetAllTeamMemberCommand(), token);
        ViewBag.Statistics = await _statisticService.GetAll(new GetAllStatisticCommand(), token);
        ViewBag.Portfolios = await _portfolioService.GetAll(new GetAllPortfolioCommand(), token);
        ViewBag.Favorites = await _reviewService.GetAll(new GetAllReviewCommand(), token);
        ViewBag.Topics = await _productService.GetAll(new GetAllProductCommand(), token);    
        ViewBag.Partners = await _partnersService.GetAll(new GetAllPartnerCommand(), token);    

        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}