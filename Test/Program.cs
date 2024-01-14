using RestSharp;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            for (int i = 1; i <= 10; i++)
            {
                DateTime a = DateTime.Now;

                using (var client = new RestClient())
                {
                    var request = new RestRequest("https://deployrise-prd-ljchuello.turso.io", Method.Post);
                    request.AddHeader("Authorization", "Bearer eyJhbGciOiJFZERTQSIsInR5cCI6IkpXVCJ9.eyJpYXQiOiIyMDI0LTAxLTEyVDE2OjM2OjMwLjEzMTUyNTc5WiIsImlkIjoiMTRjYWE4MzctYjE2NC0xMWVlLThmZGQtY2E4ODRiNGEwMDg4In0.MM-JHS0t5bkQPKlZcEc14m2r9K0N6b7MaL4NYPY-sO-_QGUIGiAwCoOtsCq7iHici-txc7bVrMZ3Hdpq0zBAAA");
                    request.AddHeader("Content-Type", "application/json");
                    var body = @"{ ""statements"": [ ""SELECT * FROM AdmUsuario WHERE Id = '17-test'"" ] }";
                    request.AddStringBody(body, DataFormat.Json);
                    RestResponse response = await client.ExecuteAsync(request);
                    string json = response.Content;
                } 
                
                DateTime b = DateTime.Now;
                Console.WriteLine($"Ping ms: {(b - a).TotalMilliseconds:n0}");
                await Task.Delay(1000);
            }
        }
    }
}
