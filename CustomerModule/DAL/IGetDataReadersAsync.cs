using CustomerModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerModule.DAL
{
    public interface IGetDataReadersAsync
    {
        UserregistrationResponse Saveaccount<T, U>(string sqlGetData, U Parameters, string myConnectionString);
        Task<IEnumerable<T>> GetChildDataAsync<T, U>(string sql, U Parameters, string connectionstring);
    }

}
