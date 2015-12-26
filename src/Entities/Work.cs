using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Entities
{
	
	public class Work
	{
		//:: Уникальный идентификатор
		public Int32 Id {get; set;}
		public String Name {get; set;}
		public String StartDate {get;set;}
		public Double Duration;
		public Double Progress;
		public Int32 ParentId;
		
		
	}
}