using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WedAPI.Data;
using WedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class ShoesshopController:Controller
    {
        private DatabaseContext _context;

        public ShoesshopController(DatabaseContext context)
        {
            _context=context;
        }

        [HttpGet]
        public async Tasks<ActionResult<List<ShoeShop>>> GetShoesShop()
        {
            var ShoeShops = await _context.shoeshops.ToListAsync();
            return  ShoeShops;
        }

        [HttpGet("{id}")]
        public async Tasks<ActionResult<List<ShoeShop>>> GetShoesShopID(int id)
        {
            var ShoeShops = await _context.shoeshops.FindAsync(id);
            if (shoeshops==null)
            {
                return NotFound();
            }
            return  ShoeShops;
        }

        [HttpPost]
        public async Tasks<ActionResult<ShoeShop>> postShoesShop(ShoeShop shoeshop)
        {
            _context.ShoeShops.Add(shoeshops);
            await _context.saveChangesAsync();
            return CreatedAtAction("GetShoesShopID",new{id=shoeshop.shoeshopID}, shoeshop);
        }

        [HttpPost("{id}")]

        public async Tasks<ActionResult<ShoeShop>> PutShoeShops(int id, ShoeShop shoeshop)
        {
            if(id != shoeshop.shoeshopID)
            {
                return BadRequest();
            }

            _context.Entry(shoeshop).State= EntityState.Modified;
            try
            {
                await _context.saveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!ShoeShopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }
             return CreatedAtAction("GetShoesShopID",new{id=shoeshop.shoeshopID}, shoeshop);

        }

    }

    private bool ShoeShopExists(int id)
    {
        return _context.ShoeShops.Any(d=>d.shoeshopID==id);
    }
}