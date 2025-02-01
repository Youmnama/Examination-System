﻿using Examination_System.Controllers;
using Examination_System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Examination_System.Repos
{
   

    public class UserRepo : IUserRepo
    {
        readonly ExaminationSystemContext db; // database context

        public UserRepo(ExaminationSystemContext _db) //constructor
        {
            db = _db;
        }

        public async Task<bool> IsUserCredentialsValid(string username, string password)
        {
            try
            {
                var parameters = new SqlParameter[] //parameters for the stored procedure
                {
                    new SqlParameter("@userName", username),
                    new SqlParameter("@password", password),
                    new SqlParameter
                    {
                        ParameterName= "@IsValid",
                        SqlDbType = System.Data.SqlDbType.Bit,
                        Direction = ParameterDirection.Output
                    }
                };

                await db.Database.ExecuteSqlRawAsync("EXECUTE IsUserCredentialsValid @userName, @password, @IsValid OUTPUT", parameters); //execute the stored procedure

                return Convert.ToBoolean(parameters[2].Value); //return the output parameter
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
