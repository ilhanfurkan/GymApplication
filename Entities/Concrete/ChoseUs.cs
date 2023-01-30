using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ChoseUs : BaseEntity,IEntity
	{
		[Key]
		public int ChoseUsId { get; set; }
		public string ReasonTitle { get; set; }
		public string ReasonDetail { get; set; }
		public string ChoseUsIcon { get; set; }
	}
}
