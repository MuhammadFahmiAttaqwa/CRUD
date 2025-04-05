
namespace ApplicationDataKaryawan.Common
{
    public class Result
    {
        public Result()
        {
            Msg = "Success";
            Code = 200;
        }

        public string? Msg { get; set; }
        public int? Code { get; set; }

        public Result(int code, string message)
        {
            Msg = message;
            Code = code;
        }

       

       
    }
    public class Result<T> : Result
    {
        public T Data { get; set; }

        public Result() : base() { }

        public Result(int code, string message, T data) : base(code, message)
        {
            Data = data;
        }

        public Result(T data)
        {
            Data = data;
            Msg = "Success";
            Code = 200;
        }
    }
}
