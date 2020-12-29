using NbaLeagueRomania.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaLeagueRomania.repository
{
    interface IRepository<ID,E>where E:Entity<ID>
    {
        E GetOne(ID id);
        IEnumerable<E> GetAll();
        E Save(E entity);
        E Delete(ID id);
        E Update(E entity);
    }
}
