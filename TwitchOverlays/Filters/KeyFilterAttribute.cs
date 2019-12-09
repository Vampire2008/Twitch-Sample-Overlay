using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitchOverlays.Filters
{
	public class KeyFilterAttribute : TypeFilterAttribute
	{
		public KeyFilterAttribute() : base(typeof(KeyFilter))
		{
		}
	}
}
