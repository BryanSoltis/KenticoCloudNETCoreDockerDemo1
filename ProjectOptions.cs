using KenticoCloud.Delivery;

namespace KenticoCloudNETCoreDockerDemo1
{
    public class ProjectOptions
    {
        public DeliveryOptions DeliveryOptions { get; set; }
        public int CacheTimeoutSeconds { get; set; }
    }
}
