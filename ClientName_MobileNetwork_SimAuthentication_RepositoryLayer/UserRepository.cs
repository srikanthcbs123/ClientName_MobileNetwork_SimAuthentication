using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.DTOs;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Entities;
using ClientName_MobileNetwork_SimAuthentication_BusinessEntities.Interfaces;
using ClientName_MobileNetwork_SimAuthentication_DBConnectivity.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ClientName_MobileNetwork_SimAuthentication_DBConnectivity.Utils;
namespace ClientName_MobileNetwork_SimAuthentication_RepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly  IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<UserSignInResponse> UserSignIn(UserSignIn urdetail)
        {
            using (IDbConnection con = _connectionFactory.GetHotelManagementSqlConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Username", urdetail.UserName);
                p.Add("@Password", urdetail.Password);
                //var queryResult = await conn.QueryAsync<Hotel>(StoredProcedureStaticMessages.GetHotelDetails, CommandType.StoredProcedure);
                var result = await con.QueryAsync<UserSignInResponse>(StoredProcedureStatusMessages.SignIn, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;

            }
        }

        public async Task<UserSignUpResponse> UserSignUp(UserSignUp urdetail)
        {
            using (IDbConnection con = _connectionFactory.GetHotelManagementSqlConnection())
            {
                var p = new DynamicParameters();
                p.Add("@Username", urdetail.Username);
                p.Add("@Password", urdetail.Password);
                p.Add("@Email", urdetail.Email);
                p.Add("@FullName", urdetail.FullName);
                // var result = await con.ExecuteScalarAsync<UserSignUpResponse>(StoredProcedureStatusMessages.SignUp, p, commandType: CommandType.StoredProcedure);
                var result = await con.QueryAsync<UserSignUpResponse>(StoredProcedureStatusMessages.SignUp, p, commandType: CommandType.StoredProcedure);
                var status = result.FirstOrDefault();
                return status;

            }
        }
    }
}
