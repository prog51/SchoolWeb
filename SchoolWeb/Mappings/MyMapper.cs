﻿using AutoMapper;
using SchoolWeb.Data;
using SchoolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Mappings
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Placement, PlacementVM>().ReverseMap();
            CreateMap<Placement,CreatePlacementVM>().ReverseMap();
            CreateMap<Student, StudentVM>().ReverseMap();
            CreateMap<School, SchoolVM>().ReverseMap();
            CreateMap<School, CreateSchoolVM>().ReverseMap();
            CreateMap<Organization, OrganizationVM>().ReverseMap();
            CreateMap<Rank, RankVM>().ReverseMap();
            CreateMap<Rank, CreateRankVM>().ReverseMap();
            CreateMap<School, DisplaySchoolVM>().ReverseMap();
            CreateMap<Placement, DisplayPlacementVM>().ReverseMap();
            CreateMap<School, EditSchoolVM>().ReverseMap();
        }
    }
}
