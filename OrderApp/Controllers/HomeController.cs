using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderApp.Entity.Models;
using OrderApp.Models;
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
        public async Task<IActionResult> Index()
        {
            var fields = new List<FilterModel> {
                new FilterModel(){Id = 1, Name = "Номер заказа"},
                new FilterModel(){Id = 2, Name = "Поставщик"},
                new FilterModel(){Id = 3, Name = "Название товара"},
                new FilterModel(){Id = 4, Name = "Ед. измерения"},

            };      
            ViewBag.Fields = new SelectList(fields, "Id", "Name");
            
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

        [HttpGet]
        public async Task<IActionResult> Filter(int filedId, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                var orders = await _serviceManager.OrderService.GetAllOrders(false);
                var orderView = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
                return PartialView("TableOrdersView", orderView);
            }
            else if (filedId == 1)
            {
                var orders = await _serviceManager.OrderService.GetAllOrders(false);
                var filterOrder = orders.Where(c => c.Number == value).ToList();
                var orderView = _mapper.Map<IEnumerable<OrderViewModel>>(filterOrder);
                return PartialView("TableOrdersView", orderView);
            }
            else if (filedId == 2)
            {
                var orders = await _serviceManager.OrderService.GetAllOrders(false);
                var filterOrder = orders.Where(c => c.Provider.Name.ToLower().Contains(value.ToLower())).ToList();
                var orderView = _mapper.Map<IEnumerable<OrderViewModel>>(filterOrder);
                return PartialView("TableOrdersView", orderView);
            }
            else if(filedId == 3)
            {
                var ordersItems = await _serviceManager.OrderItemService.GetAllOrderItems(false);
                var filterOrderItems = ordersItems.Where(c=>c.Name.ToLower().Contains(value.ToLower())).Select(c=>c.Order).DistinctBy(c=>c.Number).ToList();
                
                var orderView = _mapper.Map<IEnumerable<OrderViewModel>>(filterOrderItems);
                return PartialView("TableOrdersView", orderView);
            }
            else 
            {
                var ordersItems = await _serviceManager.OrderItemService.GetAllOrderItems(false);
                var filterOrderItems = ordersItems.Where(c=>c.Unit.ToLower().Contains(value.ToLower())).Select(c=>c.Order).DistinctBy(c => c.Number).ToList();
                
                var orderView = _mapper.Map<IEnumerable<OrderViewModel>>(filterOrderItems);
                return PartialView("TableOrdersView", orderView);
            }
           
        }

        
    }
}
