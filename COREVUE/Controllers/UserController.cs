﻿using AutoMapper;
using COREVUE.Helpers.Attributes;
using COREVUE.Models.Entities;
using COREVUE.Repositories;
using COREVUE.Services;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
{
    [Route(ControllerRoutes.UserController), ApiController, MyAuthorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;           
            this.mapper = mapper;
        }

        [HttpGet, Route(CRUDRoutes.GetAll)]
        public IEnumerable<User> GetAll() => userService.GetAll();

        [HttpGet, Route(CRUDRoutes.GetById)]
        public User GetById(int id) => userService.GetById(id);

        [HttpPost, Route(CRUDRoutes.Create)]
        public void Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map(userModel, new User());
                userService.Create(user);
            }
        }

        [HttpPut, Route(CRUDRoutes.Update)]
        public void Update(UserModel userModel)
        {
            var user = userService.GetById(userModel.Id);
            user = mapper.Map(userModel, user);
            userService.Update(user);
        }

        [HttpDelete, Route(CRUDRoutes.Delete)]
        public void Delete(int id) => userService.Delete(id);
    }
}