using BlazorAptit.Models;
using BlazorAptit.Models.Dapper;
using BlazorAptit.Models.EfCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAptit.Controllers
{
    [ApiController]
    [Route("api/Aptits")]
    public class ApiController
    {

        private readonly IAptitRepository repository;

        // PUT api/Aptits/1
        [HttpPut("{id}")]
        public  void Edit(string id, [FromBody] Order model)
        {

            try
            {
                var status =  repository.Edit(id, model);
                if (!status)
                {
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
