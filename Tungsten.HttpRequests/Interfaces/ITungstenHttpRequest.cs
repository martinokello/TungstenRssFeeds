namespace Tungsten.HttpRequests.Interfaces
{
    public enum Method { Get=0, Post=1}
    public interface ITungstenHttpRequest
    {
        string Request(string url, Method method);
    }
}