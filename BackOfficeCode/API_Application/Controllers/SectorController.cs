using API.Data;
using Domain.Models.Administrative;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : Controller
    {
        #region Private Fields

        private DataContext _dataContext;

        #endregion

        #region Builders

        public SectorController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion

        [HttpGet("All")]
        public IActionResult Get(string user, string filter, string tokenUser)
        {
            if (filter == null)
            {
                filter = string.Empty;
            }

            if (tokenUser == null || user == null)
            {
                return BadRequest("Missing mandatory parameters (token or user).");
            }

            if (!_dataContext.TokenValidation(tokenUser, user))
            {
                return Unauthorized();
            }

            try
            {
                var returnValue = _dataContext.GetListSector(user, filter);

                return Json(returnValue);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id, string user, string tokenUser)
        {
            if (tokenUser == null || user == null)
            {
                return BadRequest("Missing mandatory parameters (token or user).");
            }

            if (!_dataContext.TokenValidation(tokenUser, user))
            {
                return Unauthorized();
            }

            try
            {
                var returnValue = _dataContext.GetSector(id, user);

                return Json(returnValue);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sector sector)
        {
            if (sector == null)
            {
                return BadRequest("Missing parameter.");
            }

            if (!_dataContext.TokenValidation(sector.Token, sector.User))
            {
                return Unauthorized();
            }

            try
            {
                var returnValue = _dataContext.InsertSector(sector);

                return Json(returnValue);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Sector sector)
        {
            if (sector == null)
            {
                return BadRequest("Missing parameter.");
            }

            if (id != sector.IdSector)
            {
                return BadRequest("Ids divergent...");
            }

            if (!_dataContext.TokenValidation(sector.Token, sector.User))
            {
                return Unauthorized();
            }

            try
            {
                var returnValue = _dataContext.ChangeSector(sector);

                if (returnValue != "Ok")
                {
                    return StatusCode(500, returnValue);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Inactivate(long id, string user, string token)
        {

            if (id <= 0)
                return BadRequest("Value invalid.");

            if (token == null || user == null)
            {
                return BadRequest("Missing mandatory parameters (token or user).");
            }

            if (!_dataContext.TokenValidation(token, user))
            {
                return Unauthorized();
            }

            try
            {
                var returnValue = _dataContext.InactivateSector(id, user);

                if (returnValue != "Ok")
                {
                    return StatusCode(500, returnValue);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
