using System;
using System.ComponentModel.DataAnnotations;

namespace TRELLOBACK.Models
{
	public partial class Projet
	{
		[Key]
		public int Id { get; set; }
		public string TitreProjet { get; set; }
		public virtual ICollection<Liste> Listes { get; set;} = new List<Liste>(); 
        public DateTime CreatedAt { get; set; }

        public Projet()
		{
			CreatedAt = DateTime.Now;
		}
	}
}