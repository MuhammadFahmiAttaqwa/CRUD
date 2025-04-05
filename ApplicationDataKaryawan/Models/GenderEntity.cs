using ApplicationDataKaryawan.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDataKaryawan.Models
{
    [Table("Gender")]
    public class GenderEntity
    {
        [Key]
        public int Id { get; set; }

        public string Gender { get; set; }
    }
}
