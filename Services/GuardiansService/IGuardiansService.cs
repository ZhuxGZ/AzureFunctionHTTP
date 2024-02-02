using System;
using Http_trigger.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Http_trigger.Services.GuardiansService
{
	public interface IGuardiansService
	{
		Task<GuardiansData> AddGuardiansData(string dateFrom);
	}
}

