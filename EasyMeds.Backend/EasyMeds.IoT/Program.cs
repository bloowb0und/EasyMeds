using System.Text.Json;
using EasyMeds.IoT;

const string API_URL = "https://localhost:7295/api";

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
        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        return;
    }

    var responseBody = await userResponse.Content.ReadAsStringAsync();
    var medicationsResponse = JsonSerializer.Deserialize<List<PrescriptedMedicineDto>>(responseBody);
    
    Console.WriteLine("Successfully dispensed the following medications:");
    foreach (var medicineDto in medicationsResponse)
    {
        Console.WriteLine(medicineDto.ToString());
    }
    Console.WriteLine();
    Console.WriteLine(new string('-', 20));
    Console.WriteLine("Stay healthy!");
}
catch (Exception ex)
{
    // Display any exception that may occur
    Console.WriteLine($"An error occurred: {ex.Message}");
}