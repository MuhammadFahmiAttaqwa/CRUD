namespace ApplicationDataKaryawan.Common
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set;}
    }
}
