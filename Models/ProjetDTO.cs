using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TRELLOBACK.Models
{
	public class ProjetDTO
	{
		[Key]
		public int Id { get; set; }
		public string TitreProjet { get; set; }
	}

		public class ProjetDTOListesDTO
	{
		[Key]
		public int Id { get; set; }
		public string TitreProjet { get; set; }
		public virtual ICollection<ListeDTO> Listes { get; set;} = new List<ListeDTO>();
	}


}
