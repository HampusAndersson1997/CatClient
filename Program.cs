﻿global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using CatClient;

namespace CatClient
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ClientService service = new ClientService();
			List<CatFact> catFacts = new List<CatFact>();
            for (int i = 0; i < 5; i++)
            {
				RestResponse response = service.GetCatText("https://catfact.ninja/fact");
				CatFact catFact = JsonConvert.DeserializeObject<CatFact>(response.Content);
				catFacts.Add(catFact);
			}
			foreach (CatFact catFact in catFacts)
			{
                Console.WriteLine("This is a catfact:" + catFact.Fact);
                Console.WriteLine($"This cat fact was {catFact.Length} charachters long");
            }
		}
	}
}