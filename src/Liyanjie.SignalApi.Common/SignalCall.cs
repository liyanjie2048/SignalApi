namespace Liyanjie.SignalApi.Common
{
    public class SignalCall
    {
        public string AccessToken { get; set; }
        public string Method { get; set; }
        public object Parameters { get; set; }
        public string Callback { get; set; }
    }
}
