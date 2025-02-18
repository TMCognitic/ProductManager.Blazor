using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandQuerySeparation.Results
{
    public class Result //CommandResult
    {
        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentException(nameof(errorMessage));
            }

            return new Result(false, errorMessage, exception);
        }

        public bool IsFailure { get { return !IsSuccess; } }
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }

        private Result(bool isSuccess, string? errorMessage = null, Exception? exception = null)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public override string ToString()
        {
            return $"Resultat -> {IsSuccess} {(IsSuccess ? "" : $" : {ErrorMessage}")}";
        }
    }

    public class Result<TResult> //QueryResult<TResult>
    {
        public static Result<TResult> Success(TResult content)
        {
            return new Result<TResult>(true, content);
        }

        public static Result<TResult> Failure(string errorMessage, Exception? exception = null)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentException(nameof(errorMessage));
            }

            return new Result<TResult>(false, default!, errorMessage, exception);
        }

        private TResult _content;

        public bool IsFailure { get { return !IsSuccess; } }
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }
        public Exception? Exception { get; }
        public TResult Content
        {
            get
            {
                if (IsFailure)
                {
                    throw new InvalidOperationException("L'état du résultat est en 'échec' => pas de contenu disponible");
                }

                return _content;
            }
        }

        private Result(bool isSuccess, TResult content, string? errorMessage = null, Exception? exception = null)
        {
            _content = content;
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public override string ToString()
        {
            return $"Resultat -> {IsSuccess} {(IsSuccess ? $" : Type du contenu {typeof(TResult)}" : $" : {ErrorMessage}")}";
        }
    }
}
