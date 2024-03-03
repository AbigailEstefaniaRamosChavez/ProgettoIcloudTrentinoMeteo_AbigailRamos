using TrentinoClassLibrary.Abstraction;
using TrentinoClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace TrentinoClassLibrary.Service {
	public class TrentinoService : ITrentinoService {

        private readonly string CitiesURL = "https://www.meteotrentino.it/protcivtn-meteo/api/front/localitaOpenData";
        private readonly string MeteoUrl = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=";

        public async Task<List<string>> GetCitiesNames() {
			var client = new HttpClient();
			var response = await client.GetAsync(CitiesURL);
			string responseBody = await response.Content.ReadAsStringAsync();
			var cities = JsonSerializer.Deserialize<CityResponse>(responseBody) ?? new();
			return cities.localita.Select(s => s.localita).ToList();
		}

        public async Task<Previsione?> GetCityMeteo(string cityName) {
            var client = new HttpClient();
            var response = await client.GetAsync(MeteoUrl + cityName);
            string responseBody = await response.Content.ReadAsStringAsync();
            var meteo = JsonSerializer.Deserialize<MeteoResponse>(responseBody) ?? new();
            return meteo.previsione.FirstOrDefault();
        }

        public async Task<Giorni?> GetMeteo(string comune, DateTime giorno) {
            if (giorno < DateTime.Now)
                return null;
            var meteo = await GetCityMeteo(comune);
            if(meteo == null)
                return null;
            int distanza = (giorno - DateTime.Now).Days +1;
            if (distanza >= meteo.giorni.Length)
                return null;
            return meteo.giorni[distanza];
        }
    }

}
