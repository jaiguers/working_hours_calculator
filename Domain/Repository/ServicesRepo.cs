using Domain.Context;
using Domain.Models;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repository
{
    public class ServicesRepo : BaseRepository<Services>
    {
        public ServicesRepo(DomainContext context) : base(context)
        {
        }

        public override int Count()
        {
            try
            {
                return context.Services.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override int Count(Expression<Func<Services, bool>> predicate)
        {
            try
            {
                return context.Services.Count(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override long Create(Services entity)
        {
            try
            {
                context.Services.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override Services Get(long id)
        {
            try
            {
                return context.Services.Where(j => j.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Services> Get()
        {
            try
            {
                return context.Services.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Services> Get(Expression<Func<Services, bool>> predicate)
        {
            try
            {
                return context.Services.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override ICollection<Services> Get(Expression<Func<Services, bool>> predicate, int page, int size, Func<Services, object> filterAttribute, bool descending)
        {
            return descending ? context.Services.Where(predicate).Skip(page).Take(size).OrderByDescending(filterAttribute).ToList()
               : context.Services.Where(predicate).Skip(page).Take(size).OrderBy(filterAttribute).ToList();
        }

        public override Services GetFirst(Expression<Func<Services, bool>> predicate)
        {
            try
            {
                return context.Services.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override void Update(Services entity)
        {
            try
            {
                context.Services.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
