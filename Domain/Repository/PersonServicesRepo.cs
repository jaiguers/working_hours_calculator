using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class PersonServicesRepo : BaseRepository<PersonServices>
    {
        public PersonServicesRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.PersonServices.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<PersonServices, bool>> predicate)
        {
            try
            {
                return context.PersonServices.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(PersonServices entity)
        {
            try
            {
                context.PersonServices.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override PersonServices Get(long id)
        {
            try
            {
                return context.PersonServices.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PersonServices> Get()
        {
            try
            {
                return context.PersonServices.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PersonServices> Get(Expression<Func<PersonServices, bool>> predicate)
        {
            try
            {
                return context.PersonServices.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<PersonServices> Get(Expression<Func<PersonServices, bool>> predicate, int page, int size, Func<PersonServices, object> filterAttribute, bool descending)
        {
            return descending ? context.PersonServices.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.PersonServices.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override PersonServices GetFirst(Expression<Func<PersonServices, bool>> predicate)
        {
            try
            {
                return context.PersonServices.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(PersonServices entity)
        {
            try
            {
                context.PersonServices.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
