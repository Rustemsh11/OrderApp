using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderApp.Service.Contract;
using OrderApp.Shared;

namespace OrderApp.Controllers
{
    public class HomeController:Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public HomeController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var orders =await _serviceManager.OrderService.GetAllOrders(false);
            var orderView = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return View(orderView);
        }

        [HttpGet(Name ="CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {
            var providers = await _serviceManager.ProviderService.GetProvidersAsync(false);
            ViewBag.Providers = new SelectList(providers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(IEnumerable<OrderForCreateViewModel> orderForCreateViewModels)
        {          
            await _serviceManager.OrderService.CreateOrder(orderForCreateViewModels.FirstOrDefault());
            await _serviceManager.OrderItemService.CreateRangeOrderItem(orderForCreateViewModels);

            return RedirectToAction("Index");

        }

        //[HttpGet]
        //public async Task<IActionResult> GetOrderDetails(int id)
        //{
        //    var order = await _serviceManager.OrderItemService.GetOrderItemsByOrderId(id, trackChanges:true);
        //    return View(order);
        //}
    }
}
