using FluentValidation.Results;
using System.Collections.Generic;

namespace JAC.MusicVideoList.Transversal.Common
{
    /// <summary>
	/// Encapsule the request result
	/// </summary>
	/// <typeparam name="T">Result Type</typeparam>
    public sealed class Response<T>
    {
        public T Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public Response()
        {
        }

		/// <summary>
		/// Initialize a new instance
		/// </summary>
		/// <param name="isSuccess">value that indicates if the request was success</param>
		/// <param name="message">message</param>
		/// <param name="errorMessages">List of errors</param>
		/// <param name="data">Result object of request</param>
		internal Response(bool isSuccess, string message, IEnumerable<ValidationFailure> errorMessages, T data)
		{
			IsSuccess = isSuccess;
			Message = message;
			Errors = errorMessages;
			Data = data;
		}

		/// <summary>
		/// Create a result with success request
		/// </summary>
		/// <param name="result">Result object</param>
		/// <returns>Request result</returns>
		public static Response<T> CreateSuccessful(T data)
		{
			return new Response<T>(isSuccess: true, "OK", null, data);
		}

        /// <summary>
        /// Create a result with error request
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="messages">Messages with information about errors</param>
        /// <returns>Request result</returns>
        public static Response<T> CreateUnsuccessful(string message, IEnumerable<ValidationFailure> messages)
		{
			return new Response<T>(isSuccess: false, message, messages, default(T));
		}
	}
}
