namespace ApplicationDataKaryawan.Dto.Response
{
    public class SearchResp
    {
        public long Nik { get; set; }
        public string NamaLengkap {  get; set; }
        public int Umur {  get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string Alamat { get; set; }
        public string Country { get; set; }

    }
}
