using ApplicationDataKaryawan.Common;
using ApplicationDataKaryawan.Dto.Request;
using ApplicationDataKaryawan.Dto.Response;
using ApplicationDataKaryawan.Models;
using ApplicationDataKaryawan.Repository;

namespace ApplicationDataKaryawan.Service.Impl
{
    public class KaryawanService : IKaryawanService
    {
        private readonly IKaryawanRepository _karyawanRepository;
        public KaryawanService(IKaryawanRepository karyawabRepository)
        {
            _karyawanRepository = karyawabRepository;
        }

        public async Task<Result> addEditData(AddKaryawanReq req)
        {

            var result = new Result();

            try
            {
                var karyawan = new KaryawanEntity
                {
                    Nik = req.Nik,
                    Name = req.NameLengkap,
                    GenderId = req.Gender,
                    DateBirth = req.DateBirth,
                    Alamat = req.Alamat,
                    CountryId = req.Country,
                    CreatedTime = DateTime.Now
                };

                await _karyawanRepository.AddEditKaryawan(karyawan);

                result.Code = 200;
                result.Msg = "Success";
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Msg = "Terjadi kesalahan: " + ex.Message;
            }

            return result;

        }

        public Task<Result> DeleteData(long Nik)
        {
            Result result = new Result();
            var data = _karyawanRepository.DeleteData(Nik);
            if(Nik == null || Nik == 0 )
            {
                result.Msg = "Nik Not Fount";
                result.Code = 500;
            }
            return data;
        }

        public async Task<Result<List<SearchResp>>> GetAllKaryawa(SearchKaryawanReq req)
        {
            try
            {
                var data = await _karyawanRepository.GetAllKaryawan(req);
                Result result = new Result();
                if (data == null)
                {
                    result.Msg = "Data Kosong";
                    result.Code = 400;
                }

                return data;
            }catch (Exception ex)
            {
                return new Result<List<SearchResp>> { Msg = ex.Message, Data = new List<SearchResp>() };
            }
        }

        public Task<Result<List<CountryEntity>>> GetCountry()
        {
            return _karyawanRepository.GetCountry();
        }

        public Task<Result<List<GenderEntity>>> GetGender()
        {
            var data = _karyawanRepository.GetGender();
            return data;
        }

        public async Task<Result<KaryawanEntity>> GetKaryawan(long nik)
        {
            var result = new Result<KaryawanEntity>();

            try
            {
                var karyawan = await _karyawanRepository.GetKaryawan(nik);

                if (karyawan == null)
                {
                    result.Code = 404;
                    result.Msg = "Karyawan Not Found";
                }
                else
                {
                    result.Code = 200;
                    result.Msg = "Success";
                    result.Data = karyawan;
                }

                return result;
            }
            catch (Exception ex)
            {
                return new Result<KaryawanEntity>
                {
                    Code = 500,
                    Msg = "Server Error: " + ex.Message
                };
            }
        }


    }
}
