using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace CatClient
{
	public class ClientService
	{
		// Metoden GetCatText använder RestSharp för att göra ett HTTP-anrop till en angiven URI och hämta data därifrån.
		public RestResponse GetCatText(string uri)
		{
			RestClient client = CreateClient(uri);
			return MakeRestCall(client, uri);
		}

		// Utför det faktiska HTTP-anropet med en RestClient-instans.
		private RestResponse MakeRestCall(RestClient restClient, string inputText)
		{
			using (RestClient client = restClient)
			{
				var request = new RestRequest();
				var response = client.Get(request);
				return response;
			}
		}

		// Skapar och konfigurerar en RestClient-instans med den angivna URI:n.
		private RestClient CreateClient(string uri)
		{
			var options = new RestClientOptions(uri);
			var client = new RestClient(options);
			return client;
		}
	}
}