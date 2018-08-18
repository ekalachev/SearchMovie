namespace SearchMovie.IService.Provider
{
    public interface IGatewaySettingsProvider
    {
        string ApiKey { get; }

        string Domain { get; }
    }
}
