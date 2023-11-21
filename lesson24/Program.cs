using Dapper;
using Npgsql;
using System.ComponentModel.DataAnnotations;

// DbFunctions.GetUsers();

DbFunctions.GetUser(12345);

class User
{
    public int UserId { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }
}

static class DbFunctions
{
    private static readonly string connectionString = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=q1w2e3r4Z; Database=test;";

    static public void Add()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var newUser = new User()
            {
                UserId = 3,
                Name = "Jamoliddin",
                Password = "",
            };

            var sqlQuery = "INSERT INTO public.user VALUES(@UserId, @Name, @Password)";
            connection.Execute(sqlQuery, newUser);
        }
    }

    static public void Delete()
    {
        throw new NotImplementedException();
    }

    static public void DeleteAll()
    {
        throw new NotImplementedException();
    }

    static public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    static public void DeleteByName(string name)
    {
        throw new NotImplementedException();
    }

    static public void GetById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sqlQuery = $"select * from public.user where userId = {id}";
            var user = connection.QueryFirstOrDefault<User>(sqlQuery);
            //var user = connection.QueryFirst<User>(sqlQuery);
            if (user != null)
            {
                Console.WriteLine($"{user.UserId} - {user.Name} - {user.Password}");
            }
            else
            {
                Console.WriteLine("Bunaqa Id dagi User toplimadi");
            }
        }
    }

    static public void GetUser(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sqlQuery = $"select * from public.user where password = {id}";
            var user = connection.QuerySingle<User>(sqlQuery);
            //var user = connection.QueryFirst<User>(sqlQuery);
            if (user != null)
            {
                Console.WriteLine($"{user.UserId} - {user.Name} - {user.Password}");
            }
            else
            {
                Console.WriteLine("Bunaqa Id dagi User toplimadi");
            }
        }
    }

    static public void GetUsers()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            string sql = "select * from public.user";
            var users = connection.Query<User>(sql);

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId} - {user.Name} - {user.Password}");
            }
        }
    }

    static public void GetByName(string name)
    {
        throw new NotImplementedException();
    }

    static public void Update()
    {
        throw new NotImplementedException();
    }
}

interface IDbFunctions
{
    void Add();
    void Update();
    void Delete();
    void DeleteAll();
    void DeleteById(int id);
    void DeleteByName(string name);
    void GetById(int id);
    void GetByName(string name);
}