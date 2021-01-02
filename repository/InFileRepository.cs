using NbaLeagueRomania.entities;
using NbaLeagueRomania.entities.validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.repository
{

    public delegate E CreateEntity<E>(string line);
    class InFileRepository<ID,E> : InMemoryRepository<ID,E> where E:Entity<ID> 
    {
        protected string filename;
        protected CreateEntity<E> createEntity;

        public InFileRepository(IValidator<E> validator,string filename, CreateEntity<E> createEntity):base(validator)
        {
            this.filename = filename;
            this.createEntity = createEntity;
            if (createEntity != null)
                loadFromFile();
        }

        protected virtual void loadFromFile()
        {
            List<E> list = DataReader.ReadData(filename, createEntity);
            list.ForEach(x =>
            {
                validator.validate(x);
                entities[x.ID] = x;
            });

        }
        protected virtual void writeToFile(E entity)
        {

        }
    }
}
