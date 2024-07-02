using System.Data.SqlClient;
using Dapper;
using Practice.Dtos;
using Practice.Models;
using Practice.Repositories.Base;

namespace Practice.Repositories;

public class UserDapperRepository : IUserRepository
{
    private readonly string connectionString;
        

    public UserDapperRepository(IConfiguration config)
    {
        this.connectionString = config.GetConnectionString("MsSql") ?? "";
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = new SqlConnection(connectionString);

        var users =  await connection.QueryAsync<User>(
                    sql: @"select * from Users"
                );
        
        return users;
    }


    public async Task<int> CreateAsync(User user)
    {
        using var connection = new SqlConnection(connectionString);

            var affectedRowsCount = await connection.ExecuteAsync(
                sql: @"insert into Users
                    (Login, Email, Password)
                    values (@Login, @Email, @Password)",
                param: new {
                    user.Login,
                    user.Email,
                    user.Password,
                }
            );

        return affectedRowsCount;
    }


    public async Task<int> PutAsync(LoginDto loginDto, int id)
    {
        using var connection = new SqlConnection(connectionString);

        var affectedRowsCount = await connection.ExecuteAsync(
                sql: @"update Users 
                    set 
                    Login = @Login,
                    Email = @Email
                    where Id = @id",
                param: new {
                    loginDto.Login,  
                    loginDto.Email,
                    Id = id,
                }
            );

            return affectedRowsCount;
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        using var connection = new SqlConnection(connectionString);

        var affectedRowsCount = await connection.ExecuteAsync(
                sql:
                    @"delete from Users
                    where Id = @Id",            
                param: new {
                    Id = id
                }
            );

        return affectedRowsCount;
    }
}