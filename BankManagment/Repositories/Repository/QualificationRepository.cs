﻿using DomainEntities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class QualificationRepository : Repository<Qualification>, IRepository.IQualificationRepository
    {
        public QualificationRepository()
        {

        }
    }
}