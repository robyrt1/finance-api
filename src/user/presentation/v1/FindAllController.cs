﻿using finance.src.user.domain.port.usecases.findAll.v1;
using Microsoft.AspNetCore.Mvc;

namespace finance.src.user.presentation.v1
{
    [Route("api/user/v1/[controller]")]
    [ApiController]
    public class FindAllController: ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCollection>>> FindAll([FromServices] IFindAll findAllUseCase)
        {
            var users = await findAllUseCase.execute();
            return Ok(users);
        }

    }
}