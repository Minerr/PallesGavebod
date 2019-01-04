using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PallesGavebodWebApp.Models
{
	public class Gift
	{
		public int GiftNumber { get; set; }

		[Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }

		[Display(Name = "Added on")]
		public DateTime CreationDate { get; set; }

		[Display(Name = "Boys")]
		public bool BoyGift { get; set; }

		[Display(Name = "Girls")]
		public bool GirlGift { get; set; }
	}
}
