using System.Net.Http.Headers;
using System.Text.Json;
using EasyMeds.IoT;

const string API_URL = "http://localhost:5050/api";
const string JWT_AUTH = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjMiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyUm9sZSIsImV4cCI6MTcwMzMyNDM3NX0.XHBGhxuE8iEW2QQKk9B7SmJdvkus1aVVUzj-WUzNTPD-60F2Tshdqv2isrQTKsQC5DponiJJE8Z9JhKPyHyBGg";

Console.WriteLine("Easy Meds");
Console.WriteLine("Swipe your user card ->>");

var userId = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Processing your data");
Console.WriteLine("...");
await Task.Delay(1000);
Console.WriteLine("...");
await Task.Delay(1000);
Console.WriteLine("...");
await Task.Delay(1000);

using var client = new HttpClient();

try
{
    // Fetch a user
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWT_AUTH);
    var userResponse = await client.GetAsync($"{API_URL}/User/{userId}");

    // Check if the user wasn't found
    if (!userResponse.IsSuccessStatusCode)
    {
        Console.WriteLine($"Error: {userResponse.StatusCode} - User was not found");
        return;
    }
    
    var userResponseBody = await userResponse.Content.ReadAsStringAsync();
    var user = JsonSerializer.Deserialize<User>(userResponseBody);

    Console.WriteLine($"Welcome, {user.Fullname}!");

    Console.WriteLine("Processing your request and retrieving prescribed medications...");
    Console.WriteLine("...");
    await Task.Delay(1000);
    Console.WriteLine("...");
    await Task.Delay(1000);
    
    var response = await client.PostAsync($"{API_URL}/Medicine/takeMedicines/{userId}", null);
    
    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
        return;
    }

    var responseBody = await response.Content.ReadAsStringAsync();
    var medicationsResponse = JsonSerializer.Deserialize<PrescriptedMedicineDtoList>(responseBody)!.PrescriptedMedicineDtos;
    
    Console.WriteLine("Successfully dispensed the prescribed medications");
    Console.WriteLine();
    Console.WriteLine(new string('-', 20));
    Console.WriteLine("Stay healthy!");
}
catch (Exception ex)
{
    // Display any exception that may occur
    Console.WriteLine($"An error occurred: {ex.Message}");
}