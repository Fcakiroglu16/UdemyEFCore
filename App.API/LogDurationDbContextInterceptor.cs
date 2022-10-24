using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Security.Cryptography;

namespace App.API
{
    public class LogDurationDbContextInterceptor : DbCommandInterceptor
    {
        private readonly ILogger<LogDurationDbContextInterceptor> _logger;

        public LogDurationDbContextInterceptor(ILogger<LogDurationDbContextInterceptor> logger)
        {
            _logger = logger;
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            if (eventData.Duration.TotalMicroseconds > 500)
            {
                _logger.LogInformation(command.CommandText);
            }

            _logger.LogInformation($"Completed TotalMilliSeconds :{eventData.Duration.TotalMilliseconds}");

            return base.ReaderExecuted(command, eventData, result);
        }
    }
}