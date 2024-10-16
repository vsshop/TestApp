namespace TestApp.Implements
{
    public static class UriSchemeHandler
    {
        private static Action<string>? onUri;
        public static event Action<string>? OnUri 
        { 
            add { onUri += value; }
            remove { onUri -= value; }
        }

        public static void Uri(string url)
        {
            onUri?.Invoke(url);
        }
    }
}
