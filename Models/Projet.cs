using System;
using System.ComponentModel.DataAnnotations;

namespace TRELLOBACK.Models
{
	public class Projet
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

		public ProjetDTOListesDTO ToProjetDTO()
		{
			return new ProjetDTOListesDTO
			{
				Id =Id,
				TitreProjet = TitreProjet,
				Listes = this.Listes.Select(L => L.ToListeDTO()).ToList()

			};
		}
	}
}