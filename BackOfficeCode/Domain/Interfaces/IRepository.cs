using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        Task<T> Consult<T>(string call, string user, string tokenUser);
        Task<T> Consult<T>(string call, long id, string user, string token);
        Task<T> Consult<T>(string call, string action, string user, string token);
        Task<T> Consult<T>(string call, string action, long id, string user, string token);
        Task<T> Consult<T>(string call, string action, string query, string user, string token);
        Task<T> Consult<T>(string call, string action, long id, string query, string user, string token);
        Task<List<T>> ConsultList<T>(string call, string filter, string user, string token);
        Task<List<T>> ConsultList<T>(string call, long id, string filter, string user, string token);
        Task<List<T>> ConsultList<T>(string call, string action, string filter, string user, string token);
        Task<List<T>> ConsultList<T>(string call, string action, long id, string filter, string user, string token);
        Task<List<T>> ConsultList<T>(string call, string action, string query, string filter, string user, string token);
        Task<List<T>> ConsultList<T>(string call, string action, long id, string query, string filter, string user, string token);
        Task<T> Insert<T>(string call, T objectEntity);
        Task<T> Insert<T>(string call, string action, T objectEntity);
        Task<bool> Change<T>(string call, long id, T objectEntity);
        Task<bool> Change<T>(string call, string action, long id, T objectEntity);
        Task<bool> Inactivate<T>(string call, long id, T objectEntity);
        Task<bool> Inactivate<T>(string call, string action, long id, T objectEntity);
    }
}
