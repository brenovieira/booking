using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Booking.API.Dto;
using Booking.DAL.Dao;

namespace Booking.API.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private readonly IOrderDao _dao;

        public OrderController(IOrderDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Order> Get()
        {
            return _dao.Get()
                .ProjectTo<Order>()
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Order GetById(int id)
        {
            return _dao.GetById(id)
                .To<DAL.Entities.Order, Order>();
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(int id, Order request)
        {
            _dao.Save(request.To<Order, DAL.Entities.Order>());
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            var entity = _dao.GetById(id);
            if (entity == null) throw new Exception("Not found");

            _dao.Delete(entity);
        }
    }
}
