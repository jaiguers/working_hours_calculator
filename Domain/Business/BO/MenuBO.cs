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
    public class MenuBO: IMenu
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public MenuBO(DomainContext context)
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
        /// Crear registro de menu
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public long Create(MenuAM entity)
        {
            try
            {
                var menu = mapper.Map<Menu>(entity);

                IRepository<Menu> repo = new MenuRepo(context);
                return repo.Create(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de menu
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<Menu> repo = new MenuRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de menu según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public int Count(Expression<Func<MenuAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Menu, bool>>>(predicate);

                IRepository<Menu> repo = new MenuRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener menu por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public MenuAM Get(long id)
        {
            try
            {
                IRepository<Menu> repo = new MenuRepo(context);
                var menu = repo.Get(id);

                return mapper.Map<MenuAM>(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de menu
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<MenuAM> Get()
        {
            try
            {
                IRepository<Menu> repo = new MenuRepo(context);
                var menu = repo.Get();

                return mapper.Map<List<MenuAM>>(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de menu
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public List<MenuAM> Get(Expression<Func<MenuAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Menu, bool>>>(predicate);

                IRepository<Menu> repo = new MenuRepo(context);
                var menu = repo.Get(where);

                return mapper.Map<List<MenuAM>>(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera menu según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public MenuAM GetFirst(Expression<Func<MenuAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Menu, bool>>>(predicate);

                IRepository<Menu> repo = new MenuRepo(context);
                var menu = repo.GetFirst(where);

                return mapper.Map<MenuAM>(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar menu
        /// Autor: Jair Guerrero
        /// Fecha: 2021-02-20
        /// </summary>
        public void Update(MenuAM entity)
        {
            try
            {
                var menu = mapper.Map<Menu>(entity);

                IRepository<Menu> repo = new MenuRepo(context);
                repo.Update(menu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
