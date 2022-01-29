﻿using NHibernate;
using Webmotors.Data.Dal.Contracts;
using Webmotors.Domain.Models;

namespace Webmotors.Data.Dal
{
    public class AnuncioWebmotorsRepository : Repository<AnuncioWebmotors, int>, IAnuncioWebmotorsRepository
    {
        public AnuncioWebmotorsRepository(ISession pSession)
        {
            this.vSession = pSession;
        }
    }
}
