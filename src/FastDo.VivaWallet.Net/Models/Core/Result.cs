namespace FastDo.VivaWallet.Net.Models.Core
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Value { get; set; }
        public string? ErrorMessage { get; set; }

        public static Result<T> Ok(T? value = default) => new() { Success = true, Value = value, ErrorMessage = null };
        public static Result<T> Error(string? error = null) => new() { Success = false, Value = default, ErrorMessage = error, };
    }
}
