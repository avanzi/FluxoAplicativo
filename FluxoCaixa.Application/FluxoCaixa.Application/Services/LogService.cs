using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Services
{
    public class LogService : ILogsService
    {

        public ILogRepository _repositoryLog;
        public LogService(ILogRepository repositoryLog)
        {
                _repositoryLog= repositoryLog;
        }

        public Log Add(Log log)
        {
            _repositoryLog.Add(log);
            return log;
        }

        public IEnumerable<Log> GetAll()
        {
            return _repositoryLog.GetAll();
        }

        public IEnumerable<Log> GetLogsByDate(DateTime date)
        {
            return _repositoryLog.GetAll().Where(e => e.Data == date);

        }

    }
}
