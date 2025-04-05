using ApplicationDataKaryawan.Common;
using ApplicationDataKaryawan.Dto.Request;
using ApplicationDataKaryawan.Dto.Response;
using ApplicationDataKaryawan.Models;

namespace ApplicationDataKaryawan.Service
{
    public interface IKaryawanService
    {
        Task<Result<List<SearchResp>>> GetAllKaryawa(SearchKaryawanReq req);
        Task<Result> DeleteData(long Nik);
        Task<Result<List<CountryEntity>>> GetCountry();
        Task<Result<List<GenderEntity>>> GetGender();
        Task<Result> addEditData(AddKaryawanReq req);
        Task<Result<KaryawanEntity>> GetKaryawan(long Nik);
    }
}
