namespace RAApplication.Interfaces
{
    public interface IUpdateCommand<TReq, Tint>
    {
        void Execute(TReq req, Tint tint);
    }
}
