using Blog.Core.Common;
using Blog.Core.IRepository;
using Blog.Core.IService;
using Blog.Core.Model;
using Blog.Core.Model.Models;
using Blog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Core.Services
{
    public class AdvertisementService : BaseServices<Advertisement>, IAdvertisementServices
    {
        public int Test()
        {
            return 1;
        }

        [Caching(AbsoluteExpiration = 10)]
        public List<AdvertisementEntity> TestAOP() => new List<AdvertisementEntity>() { new AdvertisementEntity() { id = 1, name = "laozhang" } };
    }
}
