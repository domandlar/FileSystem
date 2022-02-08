﻿using FileSystem.API.Models;
using Microsoft.Extensions.Options;

namespace FileSystem.API.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly string _dbConnectionString;
        public BaseRepository(IOptions<AppSettings> appSettings)
        {
            _dbConnectionString = appSettings.Value.ConnectionString;
        }
    }
}
