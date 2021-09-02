using System;
namespace JAC.MusicVideoList.Domain.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }
        public BusinessException(string message) : base(message)
        {

        }
    }
}
