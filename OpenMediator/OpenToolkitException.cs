
namespace OpenToolkit
{
    public class OpenToolkitException : Exception
    {
        public OpenToolkitException(string message, Exception? innerException = null) : base(message, innerException) { }
    }
}
