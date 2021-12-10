using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WedAPI;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ShoesShopController: Controller
    {
        private DatabaseContext _context;

        public ShoesShopController(DatabaseContext context)
        {
            _context=context;
        }

        [HttpGet]

        public async Task<ActionResult<List<ShoesShop>>> GetShoesShop()
        {
            var ShoesShops = await _context.ShoesShops.ToListAsync();
            return ShoesShops;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ShoesShop>> GetShoesShopByID(int id)
        {
            var ShoesShops = await _context.ShoesShops.FindAsync(id);
            if (ShoesShops==null)
            {
                return NotFound();
            }
            return ShoesShops;
        }
        
        [HttpPost]
        public async Task<ActionResult<ShoesShop>> PostShoesShop(ShoesShop shoesshop)
        {
            _context.ShoesShops.Add(shoesshop);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShoesShopByID",new{IDbContextFactory=shoesshop.ShoesID},shoesshop);

        }

 
    }
}