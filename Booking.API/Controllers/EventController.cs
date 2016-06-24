using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Booking.API.Dto;
using Booking.DAL.Dao;

namespace Booking.API.Controllers
{
    [RoutePrefix("api/event")]
    public class EventController : ApiController
    {
        private readonly IEventDao _dao;

        public EventController(IEventDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Event> Get()
        {
            return _dao.Get()
                .ProjectTo<Event>()
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Event GetById(int id)
        {
            return _dao.GetById(id)
                .To<DAL.Entities.Event, Event>();
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(int id, Event request)
        {
            _dao.Save(request.To<Event, DAL.Entities.Event>());
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
