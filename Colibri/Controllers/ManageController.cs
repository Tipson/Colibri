using Colibri.Infrastructure;
using Colibri.Models.Commands.Portfolio;
using Colibri.Models.Commands.Product;
using Colibri.Models.Commands.Review;
using Colibri.Models.Commands.Statistic;
using Colibri.Models.Commands.TeamMember;
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
    
    public async Task<IActionResult> Products(CancellationToken token = default)
    {
        ViewBag.Items = await _productService.GetAll(new GetAllProductCommand(), token);
        return View();
    }
    
    public async Task<IActionResult> Reviews(CancellationToken token = default)
    {
        ViewBag.Items = await _reviewService.GetAll(new GetAllReviewCommand(), token);
        return View();
    }
    
    public async Task<IActionResult> Statistics(CancellationToken token = default)
    {
        ViewBag.Items = await _statisticService.GetAll(new GetAllStatisticCommand(), token);
        return View();
    }
    
    public async Task<IActionResult> TeamMembers(CancellationToken token = default)
    {
        ViewBag.Items = await _teamMemberService.GetAll(new GetAllTeamMemberCommand(), token);
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
        var portfolio = await _portfolioService.Get(new GetPortfolioCommand(id), token);
        ViewBag.Item = portfolio; // Исправлено на ViewBag.Item
        return View();
    }
    
    [HttpGet]
    [Route("addProduct")]
    public ActionResult AddProduct()
    {
        return View();
    }
    
    [HttpGet]
    [Route("editProduct/{id}")] 
    public async Task<ActionResult> EditProduct([FromRoute] int id, CancellationToken token = default)
    {
        ViewBag.Item = await _productService.Get(new GetProductCommand(id), token);
        return View();
    }
    
    [HttpGet]
    [Route("addReview")]
    public ActionResult AddReview()
    {
        return View();
    }
    
    [HttpGet]
    [Route("editReview/{id}")] 
    public async Task<ActionResult> EditReview([FromRoute] int id, CancellationToken token = default)
    {
        ViewBag.Item = await _reviewService.Get(new GetReviewCommand(id), token);
        return View();
    }
    
    [HttpGet]
    [Route("addStatistic")]
    public ActionResult AddStatistic()
    {
        return View();
    }
    
    [HttpGet]
    [Route("editStatistic/{id}")] 
    public async Task<ActionResult> EditStatistic([FromRoute] int id, CancellationToken token = default)
    {
        ViewBag.Item = await _statisticService.Get(new GetStatisticCommand(id), token);
        return View();
    }
    
    [HttpGet]
    [Route("addTeamMember")]
    public ActionResult AddTeamMember()
    {
        return View();
    }
    
    [HttpGet]
    [Route("editTeamMember/{id}")] 
    public async Task<ActionResult> EditTeamMember([FromRoute] int id, CancellationToken token = default)
    {
        ViewBag.Item = await _teamMemberService.Get(new GetTeamMemberCommand(id), token);
        return View();
    }
}