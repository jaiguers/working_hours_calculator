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
    public class PersonServicesBO : IPersonServices
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public PersonServicesBO(DomainContext context)
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
        /// Crear registro de PersonServices
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public long Create(PersonServicesAM entity)
        {
            try
            {
                var PersonServices = mapper.Map<PersonServices>(entity);

                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                return repo.Create(PersonServices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de PersonServices
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de PersonServices según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count(Expression<Func<PersonServicesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PersonServices, bool>>>(predicate);

                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener PersonServices por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public PersonServicesAM Get(long id)
        {
            try
            {
                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                var PersonServices = repo.Get(id);

                return mapper.Map<PersonServicesAM>(PersonServices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de PersonServices
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<PersonServicesAM> Get()
        {
            try
            {
                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                var PersonServices = repo.Get();

                return mapper.Map<List<PersonServicesAM>>(PersonServices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de PersonServices
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<PersonServicesAM> Get(Expression<Func<PersonServicesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PersonServices, bool>>>(predicate);

                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                var PersonServices = repo.Get(where);

                return mapper.Map<List<PersonServicesAM>>(PersonServices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera PersonServicess según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public PersonServicesAM GetFirst(Expression<Func<PersonServicesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<PersonServices, bool>>>(predicate);

                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                var PersonServices = repo.GetFirst(where);

                return mapper.Map<PersonServicesAM>(PersonServices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar PersonServices
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public void Update(PersonServicesAM entity)
        {
            try
            {
                var PersonServices = mapper.Map<PersonServices>(entity);

                IRepository<PersonServices> repo = new PersonServicesRepo(context);
                repo.Update(PersonServices);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
