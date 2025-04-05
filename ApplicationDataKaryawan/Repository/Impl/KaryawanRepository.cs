using ApplicationDataKaryawan.Common;
using ApplicationDataKaryawan.Dto.Request;
using ApplicationDataKaryawan.Dto.Response;
using ApplicationDataKaryawan.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ApplicationDataKaryawan.Repository.Impl
{
    public class KaryawanRepository : IKaryawanRepository
    {
        private readonly AppDbContext _context;
        public KaryawanRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Result> AddKaryawan(KaryawanEntity karyawan)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> DeleteData(long Nik)
        {
            var karyawan = await _context.Karyawan.FindAsync(Nik);
            if (karyawan == null)
            {
                return new Result { Msg = "Karyawan tidak ditemukan", Code = 404 };
            }

            karyawan.IsDeleted = false; 
            await _context.SaveChangesAsync();
            return new Result { Msg = "Karyawan berhasil dihapus" };
        }

        public async Task<Result<List<SearchResp>>> GetAllKaryawan(SearchKaryawanReq req)
        {
            try
            {
                string sql = @"select k.nik, k.datebirth,k.name,k.alamat, c.Country,g.Gender,  k.CountryId AS CountryId, 
                                k.GenderId AS GenderId,k.IsDeleted, k.CreatedTime,k.UpdatedTime from karyawan k inner join Country c on c.Id = k.CountryId inner join Gender g on g.id = k.GenderId
                                where (@name IS NULL OR @name = '' OR UPPER(k.name) LIKE UPPER('%' + @name + '%'))
	                                  and (@nik IS NULL OR @nik = '' OR Cast(k.Nik as varchar) LIKE('%' + cast(@nik as varchar) + '%'))
                                and k.IsDeleted = 1 ";
                var parameters = new[]
                {
                    new SqlParameter("@name", req.Nama ?? (object)DBNull.Value),
                    new SqlParameter("@nik", req.Nik ?? (object)DBNull.Value)
                };

                var karyawanList = await _context.Karyawan
               .FromSqlRaw(sql, parameters)
               .Include(k => k.GenderEntity)
               .Include(k => k.CountryEntity)
               .ToListAsync();

                var responseList = karyawanList.Select(k => new SearchResp
                {
                    Nik = k.Nik,
                    NamaLengkap = k.Name,
                    Alamat = k.Alamat,
                    DateBirth = k.DateBirth,
                    Country = k.CountryEntity?.Country,
                    Gender = k.GenderEntity?.Gender,
                    Umur = CommonService.CalculateAge(k.DateBirth)
                }).ToList();
                
                return new Result<List<SearchResp>> { Data = responseList };
            }
            catch (Exception ex) 
            {
                return new Result<List<SearchResp>> { Msg = ex.Message };

            }

        }

        public async Task<Result<List<CountryEntity>>> GetCountry()
        {
            var data = await _context.Country.ToListAsync();

            var result = new Result<List<CountryEntity>>
            {
                Data = data,
                Msg = data.Any() ? "Data ditemukan" : "Data tidak ditemukan"
            };

            return result;
        }

        public async Task<Result<List<GenderEntity>>> GetGender()
        {
            var data = await _context.Gender.ToListAsync();

            var result = new Result<List<GenderEntity>>
            {
                Data = data,
                Msg = data.Any() ? "Data ditemukan" : "Data tidak ditemukan"
            };

            return result;
        }

        public async Task<KaryawanEntity> GetKaryawan(long Nik)
        {
            return await _context.Karyawan
                        .AsNoTracking()
                        .FirstOrDefaultAsync(k => k.Nik == Nik);

        }

        public async Task AddEditKaryawan(KaryawanEntity karyawan)
        {
            var existingKaryawan = await GetKaryawan(karyawan.Nik);

            if (existingKaryawan != null)
            {
                existingKaryawan.Name = karyawan.Name;
                existingKaryawan.GenderId = karyawan.GenderId;
                existingKaryawan.DateBirth = karyawan.DateBirth;
                existingKaryawan.Alamat = karyawan.Alamat;
                existingKaryawan.CountryId = karyawan.CountryId;
                existingKaryawan.UpdatedTime = DateTime.Now;

                _context.Karyawan.Update(existingKaryawan);
            }
            else
            {
                await _context.Karyawan.AddAsync(karyawan);
            }

            await _context.SaveChangesAsync();
        }
    }
}
