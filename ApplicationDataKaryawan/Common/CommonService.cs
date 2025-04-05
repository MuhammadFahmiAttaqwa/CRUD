using ApplicationDataKaryawan.Dto.Request;

namespace ApplicationDataKaryawan.Common
{
    public static class CommonService
    {
        public static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
        public static Result validate(AddKaryawanReq req)
        {
            Result result = new Result();
            List<string> errors = new List<string>();

            try
            {
                if (req.Nik == null || req.Nik == 0)
                    errors.Add("Nik tidak boleh kosong.");

                if (string.IsNullOrEmpty(req.NameLengkap))
                    errors.Add("Nama lengkap tidak boleh kosong.");

                if (req.Country == null)
                    errors.Add("Country tidak boleh kosong.");

                if (string.IsNullOrEmpty(req.Alamat))
                    errors.Add("Alamat tidak boleh kosong.");

                if (req.Gender == null)
                    errors.Add("Gender tidak boleh kosong.");

                if (errors.Count > 0)
                {
                    result.Code = 400;
                    result.Msg = string.Join("; ", errors);
                }
                else
                {
                    result.Code = 200;
                    result.Msg = "Validasi berhasil.";
                }
            }
            catch (Exception e)
            {
                result.Code = 500;
                result.Msg = "Terjadi kesalahan pada validasi: " + e.Message;
            }

            return result;
        }

    }
}
