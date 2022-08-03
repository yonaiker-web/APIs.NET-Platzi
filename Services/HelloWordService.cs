namespace APIs.NET
{
    public class HelloWordService : IHelloWordService
    {
        public string GetHelloWord()
        {
            return "Hello Word";
        }
    }

    public interface IHelloWordService
    {
        string GetHelloWord();
    }
}