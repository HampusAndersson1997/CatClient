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
		public RestResponse GetCatText(string uri)
		{
			RestClient client = CreateClient(uri);
			return MakeRestCall(client, uri);
		}

		private RestResponse MakeRestCall(RestClient restClient, string inputText)
		{
			using (RestClient client = restClient)
			{
				var request = new RestRequest();
				var response = client.Get(request);
				return response;
			}
		}

		private RestClient CreateClient(string uri)
		{
			var options = new RestClientOptions(uri);
			var client = new RestClient(options);
			return client;
		}
	}
}
