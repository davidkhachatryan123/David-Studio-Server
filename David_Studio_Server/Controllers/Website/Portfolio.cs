﻿using David_Studio_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace David_Studio_Server.Controllers.Website
{
    [Route("api/[controller]")]
    [ApiController]
    public class Portfolio : ControllerBase
    {
        private readonly IDavidStudioDataProvider _data;

        public Portfolio(IDavidStudioDataProvider data)
        {
            _data = data;
        }

        /*[Route("projects")]
        [HttpGet]
        public async Task<string> GetProjects(int Count)
        {
            return await _data.GetProjectsList(Count);
        }

        [Route("tags")]
        [HttpGet]
        public async Task<string> GetTags(int count, string? value)
        {
            return await _data.GetTagsList(count, value);
        }*/
    }
}
