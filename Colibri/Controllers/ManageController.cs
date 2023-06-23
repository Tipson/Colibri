using Colibri.Infrastructure;
using Colibri.Models.Commands.Portfolio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colibri.Controllers;

[Authorize]
[Microsoft.AspNetCore.Components.Route("[controller]")]
public class ManageController : Controller
{
    private readonly ILogger<ManageController> _logger;
    private readonly ITeamMemberService _teamMemberService;
    private readonly IStatisticService _statisticService;
    private readonly IReviewService _reviewService;
    private readonly IProductService _productService;
    private readonly IPortfolioService _portfolioService;

    public ManageController(ILogger<ManageController> logger, ITeamMemberService teamMemberService, IPortfolioService portfolioService, IProductService productService, IReviewService reviewService, IStatisticService statisticService)
    {
        _logger = logger;   
        _teamMemberService = teamMemberService;
        _portfolioService = portfolioService;
        _productService = productService;
        _reviewService = reviewService;
        _statisticService = statisticService;
    }
    
    public async Task<IActionResult> Index(CancellationToken token = default)
    {
        ViewBag.Items = await _portfolioService.GetAll(new GetAllPortfolioCommand(), token);
        return View();
    }
    
    [HttpGet]
    [Route("addPortfolio")]
    public ActionResult AddPortfolio()
    {
        return View();
    }
    
    [HttpGet]
    [Route("editPortfolio/{id}")] 
    public async Task<ActionResult> EditPortfolio([FromRoute] int id, CancellationToken token = default)
    {
        ViewBag.Item = await _portfolioService.Get(new GetPortfolioCommand(id), token);
        return View();
    }
}