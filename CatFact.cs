using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatClient
{
	// Representerar en enskild kattfakta, inklusive själva faktatexten och dess längd.
	internal class CatFact
	{
		// Texten för kattfaktan. Kan vara null om ingen faktatext är tillgänglig.
		public string? Fact { get; set; }

		// Antalet tecken i faktatexten. Användbart för att snabbt bedöma faktans längd.
		public int Length { get; set; }
	}
}
