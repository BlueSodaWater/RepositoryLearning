using Blog.Core.IRepository;
using Blog.Core.IService;
using Blog.Core.Model.Models;
using Blog.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Blog.Core.Services
{
    public class AdvertisementService : BaseServices<Advertisement>, IAdvertisementServices
    {
        public IAdvertisementRepository dal = new AdvertisementRepository();
        
    }
}
