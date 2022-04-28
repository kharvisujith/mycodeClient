using Microsoft.AspNetCore.Mvc;
using Restore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restore.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            this._context = context;
        }

        [HttpGet("not-found")]
        public ActionResult getNotFound()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult getBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is bad request"});
        }

        [HttpGet("unauthorised")]
        public ActionResult getUnauthorised()
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult getValidationError()
        {
            ModelState.AddModelError("Problem1", "This is first error");
            ModelState.AddModelError("Problem2", "This is second problem");
            return ValidationProblem();
            
        }

        [HttpGet("server-error")]
        public ActionResult GetServerError()
        {
            throw new Exception("This is server error");
        }




    }
}
