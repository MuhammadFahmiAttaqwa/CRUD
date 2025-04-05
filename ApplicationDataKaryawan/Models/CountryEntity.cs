using ApplicationDataKaryawan.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDataKaryawan.Models
{
    [Table("Country")]
    public class CountryEntity
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; }
    }
}
