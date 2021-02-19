﻿using Abbott.CrossCutting.ApplicationModel;
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
    public class PersonBO : IPerson
    {
        private readonly DomainContext context;
        private readonly IMapper mapper;

        public PersonBO(DomainContext context)
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
        /// Crear registro de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public long Create(PersonAM entity)
        {
            try
            {
                var sancion = mapper.Map<Person>(entity);

                IRepository<Person> repo = new PersonRepo(context);
                return repo.Create(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public int Count()
        {
            try
            {
                IRepository<Person> repo = new PersonRepo(context);
                return repo.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener cantidad de registros de Sancion según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public int Count(Expression<Func<PersonAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Person, bool>>>(predicate);

                IRepository<Person> repo = new PersonRepo(context);
                return repo.Count(where);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener Sancion por Id
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public PersonAM Get(long id)
        {
            try
            {
                IRepository<Person> repo = new PersonRepo(context);
                var sancion = repo.Get(id);

                return mapper.Map<PersonAM>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public List<PersonAM> Get()
        {
            try
            {
                IRepository<Person> repo = new PersonRepo(context);
                var sancion = repo.Get();

                return mapper.Map<List<PersonAM>>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener lista de Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public List<PersonAM> Get(Expression<Func<PersonAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Person, bool>>>(predicate);

                IRepository<Person> repo = new PersonRepo(context);
                var sancion = repo.Get(where);

                return mapper.Map<List<PersonAM>>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Obtener primera Sancion según filtro
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public PersonAM GetFirst(Expression<Func<PersonAM, bool>> predicate)
        {
            try
            {
                var where = mapper.MapExpression<Expression<Func<Person, bool>>>(predicate);

                IRepository<Person> repo = new PersonRepo(context);
                var sancion = repo.GetFirst(where);

                return mapper.Map<PersonAM>(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Actualizar Sancion
        /// Autor: Jair Guerrero
        /// Fecha: 2020-12-05
        /// </summary>
        public void Update(PersonAM entity)
        {
            try
            {
                var sancion = mapper.Map<Person>(entity);

                IRepository<Person> repo = new PersonRepo(context);
                repo.Update(sancion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
