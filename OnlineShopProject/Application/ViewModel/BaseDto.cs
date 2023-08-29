namespace Application.ViewModel
{
    public class BaseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public BaseDto()
        {

        }

        public BaseDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }

    /// <summary>
    /// کلاس جنریک برای نگه داری نتایج عملیات و دیتای مربوطه
    /// </summary>
    public class BaseDto<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        /// <summary>
        /// مقدار دهی از طریق سازنده
        /// </summary>
        public BaseDto(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public BaseDto()
        {

        }
    }

    public class MultiBaseDto
    {
        public List<string> Messages { get; private set; }
        public bool IsSuccess { get; private set; }

        public MultiBaseDto(bool isSuccess, List<string> messageList)
        {
            IsSuccess = isSuccess;
            Messages = messageList;
        }
    }
}
