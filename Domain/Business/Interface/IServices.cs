using IASHandyMan.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.Interface
{
    public interface IServices
    {
        public long Create(ServicesAM entity);
        public int Count();
        public int Count(Expression<Func<ServicesAM, bool>> predicate);
        public ServicesAM Get(long id);
        public List<ServicesAM> Get();
        public List<ServicesAM> Get(Expression<Func<ServicesAM, bool>> predicate);
        public ServicesAM GetFirst(Expression<Func<ServicesAM, bool>> predicate);
        public void Update(ServicesAM entity);

    }
}
