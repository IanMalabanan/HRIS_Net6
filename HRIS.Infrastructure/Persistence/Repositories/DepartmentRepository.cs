﻿using HRIS.Application.Common.Interfaces.Application;
using HRIS.Application.Common.Interfaces.Repositories;
using HRIS.Application.Common.Interfaces.Services;
using HRIS.Application.Common.Models;
using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        //private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext, IDateTime dateTimeService
            , ICurrentUserService currentUserService
            ) : base(dbContext, dateTimeService
                , currentUserService
                )
        {
            //_dbContext = dbContext;
            SetGetQuery(dbContext.Set<Department>());
        }

    }
}
