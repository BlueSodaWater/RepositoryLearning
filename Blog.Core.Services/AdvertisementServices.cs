using Blog.Core.IRepository;
using Blog.Core.IService;
using Blog.Core.Repository;

namespace Blog.Core.Services
{
    public class AdvertisementService : IAdvertisementServices
    {
        IAdvertisementRepository dal = new AdvertisementRepository();

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);
        }
    }
}
