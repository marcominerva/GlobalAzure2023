using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace GlobalAzure.Pages;

public class SqlServerModel : PageModel
{
    private readonly IConfiguration configuration;

    public string? SqlVersion { get; set; }

    public IEnumerable<Person> People { get; set; } = default!;

    public SqlServerModel(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task OnGetAsync()
    {
        using var sqlConnection = new SqlConnection(configuration.GetConnectionString("SqlConnection"));
        await sqlConnection.OpenAsync();

        SqlVersion = await sqlConnection.ExecuteScalarAsync<string>("SELECT @@VERSION");
        People = await sqlConnection.QueryAsync<Person>("SELECT * FROM People ORDER BY FirstName, LastName");
    }
}

public record class Person(Guid Id, string FirstName, string LastName, string City, bool IsDeleted);