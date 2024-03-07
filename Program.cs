using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using CatClient;

namespace CatClient
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ClientService service = new ClientService();
			List<CatFact> catFacts = new List<CatFact>();

			// Gör 5 anrop för att hämta kattfakta och lägg till dem i en lista.
			for (int i = 0; i < 5; i++)
			{
				RestResponse response = service.GetCatText("https://catfact.ninja/fact");
				if (!string.IsNullOrEmpty(response.Content))
				{
					var catFact = JsonConvert.DeserializeObject<CatFact>(response.Content);
					if (catFact != null)
					{
						catFacts.Add(catFact);
					}
					else
					{
						Console.Error.WriteLine("Kunde inte deserialisera kattfaktan.");
					}
				}
				else
				{
					Console.Error.WriteLine("Tomt svar mottaget.");
				}
			}

			// Skriver ut varje kattfakta och dess längd.
			foreach (CatFact catFact in catFacts)
			{
				Console.WriteLine("Detta är en kattfakta: " + catFact.Fact);
				Console.WriteLine($"Denna kattfakta var {catFact.Length} tecken lång.");
			}
		}
	}
}
