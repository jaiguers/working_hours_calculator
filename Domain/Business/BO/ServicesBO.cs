using IASHandyMan.CrossCutting.ApplicationModel;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Business.Interface;
using Domain.Business.Profiles;
using Domain.Context;
using Domain.Models;
using Domain.Repository;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Business.BO
{
    public class ServicesBO : IServices
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public ServicesBO(DomainContext context)
        {
            this.context = context;

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping();
                cfg.AddProfile<AdminProfile>();
            });

            mapper = new Mapper(mapConfig);
        }

        /// <summary>
        /// Crear registro de services
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public long Create(ServicesAM entity)
        {
            try
            {
                var services = mapper.Map<Services>(entity);

                IRepository<Services> repo = new ServicesRepo(context);
                return repo.Create(services);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de services
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<Services> repo = new ServicesRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de services según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count(Expression<Func<ServicesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Services, bool>>>(predicate);

                IRepository<Services> repo = new ServicesRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener services por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public ServicesAM Get(long id)
        {
            try
            {
                IRepository<Services> repo = new ServicesRepo(context);
                var services = repo.Get(id);

                return mapper.Map<ServicesAM>(services);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de services
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<ServicesAM> Get()
        {
            try
            {
                IRepository<Services> repo = new ServicesRepo(context);
                var services = repo.Get();

                return mapper.Map<List<ServicesAM>>(services);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de services
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<ServicesAM> Get(Expression<Func<ServicesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Services, bool>>>(predicate);

                IRepository<Services> repo = new ServicesRepo(context);
                var services = repo.Get(where);

                return mapper.Map<List<ServicesAM>>(services);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera services según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public ServicesAM GetFirst(Expression<Func<ServicesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Services, bool>>>(predicate);

                IRepository<Services> repo = new ServicesRepo(context);
                var services = repo.GetFirst(where);

                return mapper.Map<ServicesAM>(services);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar services
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public void Update(ServicesAM entity)
        {
            try
            {
                var services = mapper.Map<Services>(entity);

                IRepository<Services> repo = new ServicesRepo(context);
                repo.Update(services);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
