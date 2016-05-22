using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteService.View;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace QuoteService.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public QuoteView Get()
        {
            return new QuoteView { Quote = "“Courage doesn’t always roar. Sometimes courage is the quiet voice at the end of the day saying, I will try again tomorrow.” — Mary Anne Radmacher" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public QuoteView Get(int id)
        {
            throw new NotImplementedException();
        }


    }
}
