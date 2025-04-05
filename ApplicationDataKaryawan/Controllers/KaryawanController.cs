using ApplicationDataKaryawan.Common;
using ApplicationDataKaryawan.Dto.Request;
using ApplicationDataKaryawan.Dto.Response;
using ApplicationDataKaryawan.Models;
using ApplicationDataKaryawan.Service;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationDataKaryawan.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KaryawanController : ControllerBase
    {
        private readonly IKaryawanService _karyawanService;

        public KaryawanController(IKaryawanService karyawanService)
        {
            _karyawanService = karyawanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKaryawan([FromQuery] SearchKaryawanReq req)
        {
            var result = await _karyawanService.GetAllKaryawa(req);
            return Ok(result);
        }

        [HttpPost]
        public async Task<Result> DeleteData([FromBody]long Nik)
        {
            var data = await _karyawanService.DeleteData(Nik);
            return data;
        }
        [HttpGet]
        public async Task<Result<List<CountryEntity>>> GetCountry()
        {
            return await _karyawanService.GetCountry();
        }

        [HttpGet]
        public async Task<Result<List<GenderEntity>>> GetGender()
        {
            return await _karyawanService.GetGender();
        }
        [HttpPost]
        public async Task<Result> AddEditData([FromBody]AddKaryawanReq req)
        {
            var result = await _karyawanService.addEditData(req);
            return result;
        }
        [HttpGet]
        public async Task<Result<KaryawanEntity>> GetKaryawan([FromQuery]long Nik)
        {
            var data = await _karyawanService.GetKaryawan(Nik);
            return data;
        }
        
    }
}
