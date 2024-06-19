using System;
using System.ComponentModel.DataAnnotations;

namespace TRELLOBACK.Models
{
	public partial class ListeDTO
	{
		[Key]
		public int Id { get; set; }
		public string TitreListe { get; set; } = null!;
		// public virtual ICollection<Carte> Cartes { get; set;} = new List<Carte>();
        // public DateTime CreatedAt { get; set; }

		[Required]
		public int ProjetId { get; set; }
	}
}