using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CourseApp.Tests;

public class StudentsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public StudentsApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Get_students_returns_Ok()
    {
        // Act
        var response = await _client.GetAsync("/students");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
