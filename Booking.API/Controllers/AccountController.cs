using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using Booking.API.Dto;
using Booking.DAL.Dao;

namespace Booking.API.Controllers
{
    [RoutePrefix("api/Aacount")]
    public class AccountController : ApiController
    {
        private readonly IAccountDao _dao;

        public AccountController(IAccountDao dao)
        {
            _dao = dao;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Account> Get()
        {
            return _dao.Get()
                .ProjectTo<Account>()
                .ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Account GetById(int id)
        {
            return _dao.GetById(id)
                .To<DAL.Entities.Account, Account>();
        }

        [HttpPost]
        [Route("{id}")]
        public void Save(int id, Account request)
        {
            _dao.Save(request.To<Account, DAL.Entities.Account>());
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
