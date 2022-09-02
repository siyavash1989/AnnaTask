using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities.UserBasket;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class BasketController : ApiBaseController
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BasketController(ILogger<BasketController> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasket(int id)
        {
            var basket = await _unitOfWork.Repository<Basket>().GetByIdAsync(id);
            return Ok(basket ?? new Basket(id));
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(CustomerBasketDto basketDto)
        {
            var basket = _mapper.Map<CustomerBasketDto, Basket>(basketDto);
            _unitOfWork.Repository<Basket>().Update(basket);
            await _unitOfWork.Complete();
            return await _unitOfWork.Repository<Basket>().GetByIdAsync(basket.Id);
        }

        [HttpDelete]
        public async Task DeleteBasket(int id)
        {
            var entity = await _unitOfWork.Repository<Basket>().GetByIdAsync(id);
            _unitOfWork.Repository<Basket>().Delete(entity);
            await _unitOfWork.Complete();
        }
    }
}