using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Domain.Interfaces;
using NewsApp.DTO.Models;

namespace NewsApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategoriService _categoriService;
        private readonly IMapper _mapper;
        public CategorieController(ICategoriService categoriService, IMapper mapper)
        {
            _categoriService = categoriService;
            _mapper = mapper;
        }
        [HttpGet]
        public List<CategoriDTO> getAllCategories()
        {
            var list = _categoriService.GetAllCategori();
            var mapList = _mapper.Map<IEnumerable<CategoriDTO>>(list).ToList();
            return mapList;
        }
    }
}