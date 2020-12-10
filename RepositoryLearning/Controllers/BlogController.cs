﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.IService;
using Blog.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IAdvertisementServices advertisementServices;

        public BlogController(IAdvertisementServices advertisementServices)
        {
            this.advertisementServices = advertisementServices;
        }

        // GET: api/Blog/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<Advertisement>> Get(int id)
        {
            return await advertisementServices.Query(d => d.Id == id);
        }

        // POST api/<BlogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
