using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetHotelManagementSqlConnection();
    }
}
