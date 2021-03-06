﻿using AutoMapper;
using MVC_ActionResults.DTOs;
using MVC_ActionResults.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ActionResults.App_Start
{
    public class Mapping_Profile: Profile
    {
        public Mapping_Profile()
        {
            Mapper.CreateMap<Customers, CustomerDTO>();
            Mapper.CreateMap<Movies, MovieDTO>();
            Mapper.CreateMap<MembershipTypes, MembershipTypeDTO>();
            Mapper.CreateMap<Genre,GenreDTO>();
            Mapper.CreateMap<CustomerDTO, Customers>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movies>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}