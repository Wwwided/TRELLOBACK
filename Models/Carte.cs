using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRELLOBACK.Models
{
	public partial class Carte
	{
		[Key]
		public int Id { get; set; }
		public string TitreCarte { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
		public string DescriptionCarte { get; set; } = null!;
		public Statut StatutCarte { get; set; }
		public int ListeId { get; set; }
		
		[ForeignKey("ListeId")]
		public virtual Liste Liste { get; set; }
        public Carte()
		{
			CreatedAt = DateTime.Now;
		}

		public enum Statut{
			AFaire,
			Fait
		};
	}
}