namespace ApplicationDataKaryawan.Dto.Request
{
    public class AddKaryawanReq
    {
        public long Nik { get; set; }
        public string NameLengkap { get; set; }
        public int Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public string Alamat { get; set;}
        public int Country { get; set; }
    }
}
