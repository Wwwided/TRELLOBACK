using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRELLOBACK.Models
{
	public partial class Liste
	{
		[Key]
		public int Id { get; set; }
		public string TitreListe { get; set; } = null!;
		// public virtual ICollection<Carte> Cartes { get; set;} = new List<Carte>();
        // public DateTime CreatedAt { get; set; }

		[Required]
		public int ProjetId { get; set; }
		public Projet Projet { get; set; }
			
	}
}