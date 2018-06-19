using KenticoCloud.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace KenticoCloudNETCoreDockerDemo1.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IDeliveryClient deliveryClient)
        {
            DeliveryClient = deliveryClient;
        }

        protected IDeliveryClient DeliveryClient { get; }
    }
}
