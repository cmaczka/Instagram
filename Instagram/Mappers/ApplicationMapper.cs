﻿using AutoMapper;
using Instagram.DTO;
using Instagram.Models;

namespace Instagram.Mappers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UserDTO, User>();
            CreateMap<RegistroRequestDto, User>();

        }
    }
}