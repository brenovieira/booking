using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Booking.API.Dto;
using Booking.DAL.Dao;

namespace Booking.API.Controllers
{
    [RoutePrefix("api/availability")]
    public class AvailabilityController : ApiController
    {
        private readonly IAvailabilityDao _dao;

        public AvailabilityController(IAvailabilityDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Availability> Get()
        {
            return _dao.Get()
                .ProjectTo<Availability>()
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Availability GetById(int id)
        {
            return _dao.GetById(id)
                .To<DAL.Entities.Availability, Availability>();
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(int id, Availability request)
        {
            _dao.Save(request.To<Availability, DAL.Entities.Availability>());
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
