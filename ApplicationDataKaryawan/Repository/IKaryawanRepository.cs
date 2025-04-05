using ApplicationDataKaryawan.Common;
using ApplicationDataKaryawan.Dto.Request;
using ApplicationDataKaryawan.Dto.Response;
using ApplicationDataKaryawan.Models;
using System.Diagnostics.Metrics;

namespace ApplicationDataKaryawan.Repository
{
    public interface IKaryawanRepository
    {
        public Task<Result<List<SearchResp>>> GetAllKaryawan(SearchKaryawanReq req);
        Task<Result> DeleteData(long Nik);
        Task<Result<List<CountryEntity>>> GetCountry();
        Task<Result<List<GenderEntity>>> GetGender();
        Task<KaryawanEntity> GetKaryawan(long Nik);
        Task AddEditKaryawan(KaryawanEntity karyawan);

    }
}
