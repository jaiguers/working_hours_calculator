using IASHandyMan.CrossCutting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.Interface
{
    public interface IPersonServices
    {
        public long Create(PersonServicesAM entity);
        public int Count();
        public int Count(Expression<Func<PersonServicesAM, bool>> predicate);
        public PersonServicesAM Get(long id);
        public List<PersonServicesAM> Get();
        public List<PersonServicesAM> Get(Expression<Func<PersonServicesAM, bool>> predicate);
        public PersonServicesAM GetFirst(Expression<Func<PersonServicesAM, bool>> predicate);
        public void Update(PersonServicesAM entity);

    }
}
