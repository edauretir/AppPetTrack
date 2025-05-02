using AppPetTrack.SERVICE.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppPetTrack.SERVICE.Concretes
{
    public class GeolocationService : IGeolocationService
    {
        public async Task<(double lat, double lon)?> GetCoordinatesFromAddress(string address)
        {
            using var client = new HttpClient();
            string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(address)}&format=json&limit=1&countrycodes=tr";
            client.DefaultRequestHeaders.Add("User-Agent", "PetTrackApp");

            try
            {
                var response = await client.GetStringAsync(url);
                var jsonDoc = JsonDocument.Parse(response);
                var results = jsonDoc.RootElement;

                if (results.GetArrayLength() == 0) return null;

                double lat = double.Parse(results[0].GetProperty("lat").GetString());
                double lon = double.Parse(results[0].GetProperty("lon").GetString());

                return (lat, lon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
        }
    }
}
