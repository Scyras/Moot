using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moot.DB;
using Moot.DB.Items;
using Moot.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moot.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        private readonly MootContext _DbContext;
        private readonly IMapper _Mapper;

        public ItemsController(MootContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
            Seed();
        }

        [HttpPost]
        public ItemDto CreateNewItem([FromBody] ItemDto newItemDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("item is invalid");
            }

            Item item = _Mapper.Map<ItemDto, Item>(newItemDto);

            _DbContext.Items.Add(item);
            _DbContext.SaveChanges();

            newItemDto.Id = item.Id;

            return newItemDto;
        }

        [HttpDelete]
        public void DeleteItem(int id)
        {
            Item dbItem = _DbContext.Items.SingleOrDefault(i => i.Id == id);

            if (dbItem == null)
            {
                throw new KeyNotFoundException();
            }

            _DbContext.Items.Remove(dbItem);

            _DbContext.SaveChanges();
        }

        [HttpGet()]
        public IEnumerable<ItemDto> GetAll()
        {
            var allItems = _DbContext.Items.OrderBy(i => i.Id).Select(_Mapper.Map<Item, ItemDto>);
            return allItems;
        }

        [HttpGet("{id}", Name = "GetItem")]
        public ItemDto GetById(int id)
        {
            var item = _DbContext.Items.SingleOrDefault(i => i.Id == id);
            if (item == null)
            {
                return null;
            }

            return _Mapper.Map<Item, ItemDto>(item);
        }

        [HttpPut]
        public void UpdateItem(int id, ItemDto itemDto)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException("item is invalid");
            }
            Item dbItem = _DbContext.Items.SingleOrDefault(i => i.Id == id);

            if (dbItem == null)
            {
                throw new KeyNotFoundException();
            }

            _Mapper.Map(itemDto, dbItem);

            _DbContext.SaveChanges();
        }

        private void Seed()
        {
            if (!_DbContext.Items.Any())
            {
                _DbContext.Items.AddRange(new List<Item>()
                {
                    new Item()
                    {
                        Name = "Test Items",
                        Description = "this is a test item",
                        ImageSource = "~/images/TestTubes.png"
                    },
                    new Item()
                    {
                        Name = "Test Item",
                        Description = "this is a test item for svg",
                        ImageSource = "~/images/TestTube.svg"
                    }
                });
                _DbContext.SaveChanges();
            }
        }
    }
}