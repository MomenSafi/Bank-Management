﻿using DomainEntities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class NationalityRepository : Repository<Nationality>, IRepository.INationalityRepository
    {
        public NationalityRepository()
        {

        }
    }
}
