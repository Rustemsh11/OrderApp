using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderApp.Entity.Models;
using OrderApp.Service.Contract;

namespace OrderApp.Controllers
{
    public class QueryDetailsController: Controller
    {
        private readonly IServiceManager _serviceManager;
        
        public QueryDetailsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails(int id)
        {
            var order = await _serviceManager.OrderItemService.GetOrderItemsByOrderId(id, trackChanges: true);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> EditQueryDetail()
        {
            string requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<List<OrderItem>>(requestBody);
            await _serviceManager.OrderItemService.UpdateOrderItems(data);
            return RedirectToAction("GetOrderDetails");
        }

        public async Task<IActionResult> DeleteQueryDetail(int queryDetailId, int orderId)
        {
            bool isExistItemsInOrder = await _serviceManager.OrderItemService.DeleteOrderItem(queryDetailId, orderId, true);
            if (isExistItemsInOrder)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("GetOrderDetails", new { id=orderId });
        }
    }
}
