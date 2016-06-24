using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Booking.API.Dto;
using Booking.DAL.Dao;

namespace Booking.API.Controllers
{
    [RoutePrefix("api/healthIssue")]
    public class HealthIssueController : ApiController
    {
        private readonly IHealthIssueDao _dao;

        public HealthIssueController(IHealthIssueDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<HealthIssue> Get()
        {
            return _dao.Get()
                .ProjectTo<HealthIssue>()
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public HealthIssue GetById(int id)
        {
            return _dao.GetById(id)
                .To<DAL.Entities.HealthIssue, HealthIssue>();
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(int id, HealthIssue request)
        {
            _dao.Save(request.To<HealthIssue, DAL.Entities.HealthIssue>());
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
