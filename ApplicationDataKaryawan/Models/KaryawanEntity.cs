using ApplicationDataKaryawan.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDataKaryawan.Models
{
    [Table("Karyawan")]
    public class KaryawanEntity : BaseEntity
    {
        public KaryawanEntity() { }
        [Key]
        public long Nik { get; set; }

        public string Name { get; set; }

        public int GenderId { get; set; }

        public int CountryId { get; set; }

        public bool IsDeleted { get; set; } = true;
        public string Alamat { get; set; }

        public DateTime DateBirth { get; set; }

        [ForeignKey("GenderId")]
        public virtual GenderEntity GenderEntity { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryEntity CountryEntity { get; set; }
    }
}
