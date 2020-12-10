using Blog.Core.Model;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Core.IService
{
    public interface IAdvertisementServices : IBaseServices<Advertisement>
    {
        int Test();
        List<AdvertisementEntity> TestAOP();
    }
}
