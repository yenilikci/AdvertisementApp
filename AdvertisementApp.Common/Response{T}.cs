namespace AdvertisementApp.Common
{
    // Data taşıyan
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
        public Response(ResponseType responseType, string message) : base(responseType, message)
        {

        }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(T data, List<CustomValidationError> validationErrors) : base(ResponseType.ValidationError)
        {
            ValidationErrors = validationErrors;
            Data = data;
        }
    }
}