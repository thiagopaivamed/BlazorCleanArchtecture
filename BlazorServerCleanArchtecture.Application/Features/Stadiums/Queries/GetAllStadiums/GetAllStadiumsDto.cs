﻿using BlazorServerCleanArchtecture.Application.Common.Mappings;
using BlazorServerCleanArchtecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerCleanArchtecture.Application.Features.Stadiums.Queries.GetAllStadiums
{
    public class GetAllStadiumsDto : IMapFrom<Stadium>
    {
        public int Id { get; init; }
        public string Name { get; set; }
        public string City { get; set; }
        public int? Capacity { get; set; }
        public int? BuiltYear { get; set; }
        public int? PitchLength { get; set; }
        public int? PitchWidth { get; set; }
    }
}
