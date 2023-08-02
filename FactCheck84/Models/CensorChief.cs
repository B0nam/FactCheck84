using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactCheck84.Models
{
	public class CensorChief : User
	{
		public int CensorChiefRolesId { get; set; }
		public CensorChiefRoles CensorChiefRoles { get; set; } = null!;

		public CensorChief()
		{
		}
	}
}
