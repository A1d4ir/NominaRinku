﻿using NominaRinku.Domain;
using NominaRinku.Infrastructure.Persistence;
using NominaRinku.Application.Contracts.Persistense;

namespace NominaRinku.Infrastructure.Repositories
{
    public class SueldoReporitory: RepositoryBase<Sueldo>, ISueldoRepository
    {
        public SueldoReporitory(NominaRinkuDbContext context): base(context)
        {
            
        }
    }
}
