using ballmer_peak_blazor_server.Model;

namespace ballmer_peak_blazor_server.Data;

public class UserService
{
    private readonly HttpClient httpClient;

    public UserService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        IEnumerable<User>? users = await httpClient.GetFromJsonAsync<IEnumerable<User>>("https://jsonplaceholder.typicode.com/users");

        return users ?? Array.Empty<User>();
    }

    public Task<User?> GetByIdAsync(string id)
    {
        return httpClient.GetFromJsonAsync<User>($"https://jsonplaceholder.typicode.com/users/{id}");
    }
}
