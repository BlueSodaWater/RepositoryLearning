using Blog.Core.IRepository;
using Blog.Core.Model.Models;
using Blog.Core.Repository.BASE;
using Blog.Core.Repository.sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.Repository
{
    public class AdvertisementRepository : BaseRepository<Advertisement>, IAdvertisementRepository
    {
        
    }
}
