namespace TestApp.Services
{
    public class ProxyService
    {
        public event Action<string, object>? OnInvoke;
        public void Invoke(string subscribe, object obj)
        {
            OnInvoke?.Invoke(subscribe, obj);
        }
    }
}
