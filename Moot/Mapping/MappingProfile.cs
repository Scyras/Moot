using AutoMapper;
using Moot.DB.Items;
using Moot.Dtos.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moot.Mapping
{
    public class MappingProfile : Profile
    {
        protected MappingProfile() : base()
        {
            MapItems();
        }

        private void MapItems()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
