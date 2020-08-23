namespace Liyanjie.SignalApi.Core
{
    public interface IAuthorizeData
    {
        string Policy { get; set; }

        string Roles { get; set; }
    }
}
