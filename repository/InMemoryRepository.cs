using NbaLeagueRomania.entities;
using NbaLeagueRomania.entities.validators;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NbaLeagueRomania.repository
{
    class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IValidator<E> validator;

        protected IDictionary<ID, E> entities = new Dictionary<ID, E>();

        public InMemoryRepository(IValidator<E> validator)
        {
            this.validator = validator;
        }

        public E Delete(ID id)
        {
            if (id == null)
                throw new ArgumentNullException("The ID cannot be null!");
            if (this.entities.ContainsKey(id))
            {
                E elem = this.entities[id];
                this.entities.Remove(id);
                return elem;
            }

             return null;

        }

            public IEnumerable<E> GetAll()
        {
            return entities.Values.ToList<E>();
        }

        public E GetOne(ID id)
        {
            if(entities.ContainsKey(id))
                return entities[id];
            return null;
        }

        public E Save(E entity)
        {
            if (entity == null)
                throw new ArgumentNullException("The enitity cannot be null!");
            this.validator.validate(entity);
            if (this.entities.ContainsKey(entity.ID))
                return entity;
            else
            {
                this.entities[entity.ID] = entity;
                return null;
            }
        }

        public E Update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}
