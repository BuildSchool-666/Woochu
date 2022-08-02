namespace MVCModels.APIModels
{
    public class BaseResult {
        public BaseResult(bool isSuccess, APIStatus status, object body)
        {
            IsSuccess = isSuccess;
            Status = status;
            Body = body;
        }

        public bool IsSuccess { get; set; }

        public APIStatus Status { get; set; }

        public object Body { get; set; }

    }

    public enum APIStatus {
        Success = 200,
        Fail = 400,
        Unauthorized = 401,
        NotFound = 404
    }
}