using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THE_MBURUS_FARM.DBL;
using THE_MBURUS_FARM.DBL.Models;

namespace THE_MBURU_S_FARMAPI.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private Bl bl;
        public AnimalController()
        {
             bl = new Bl(THE_MBURUS_FARM_Api.Util.GetDbConnString());
        }
        #region  pigs
        [HttpPost("getpigBreeds")]
        public async Task<IActionResult> pigBreeds()
        {
            var pb = await bl.GetPigBreed();
            return View(pb.ToList());
        }
        [HttpPost("getpigBreed")]
        public async Task<IActionResult> pigBreeds(string breed)
        {
            var pb = await bl.GetPigBreed(breed);
            return View(pb.ToList());
        }
        #endregion
        #region make pigs order
        [HttpPost("placeOrder")]
        public async Task<IActionResult> makepigsOrder(makepigOrder order)
        {
            var pb = await bl.makepigsOrder(order);
            return View(pb.ToList());
        }
        #endregion

    }
}