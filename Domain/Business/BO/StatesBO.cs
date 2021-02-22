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
using System.Text;

namespace Domain.Business.BO
{
    public class StatesBO : IStates
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public StatesBO(DomainContext context)
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
        /// Crear registro de states
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public long Create(StatesAM entity)
        {
            try
            {
                var states = mapper.Map<States>(entity);

                IRepository<States> repo = new StatesRepo(context);
                return repo.Create(states);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de states
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<States> repo = new StatesRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de states según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count(Expression<Func<StatesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<States, bool>>>(predicate);

                IRepository<States> repo = new StatesRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener states por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public StatesAM Get(long id)
        {
            try
            {
                IRepository<States> repo = new StatesRepo(context);
                var states = repo.Get(id);

                return mapper.Map<StatesAM>(states);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de states
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<StatesAM> Get()
        {
            try
            {
                IRepository<States> repo = new StatesRepo(context);
                var states = repo.Get();

                return mapper.Map<List<StatesAM>>(states);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de states
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<StatesAM> Get(Expression<Func<StatesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<States, bool>>>(predicate);

                IRepository<States> repo = new StatesRepo(context);
                var states = repo.Get(where);

                return mapper.Map<List<StatesAM>>(states);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera states según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public StatesAM GetFirst(Expression<Func<StatesAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<States, bool>>>(predicate);

                IRepository<States> repo = new StatesRepo(context);
                var states = repo.GetFirst(where);

                return mapper.Map<StatesAM>(states);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar states
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public void Update(StatesAM entity)
        {
            try
            {
                var states = mapper.Map<States>(entity);

                IRepository<States> repo = new StatesRepo(context);
                repo.Update(states);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
