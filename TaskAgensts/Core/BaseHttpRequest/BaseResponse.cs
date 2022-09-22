namespace TaskAgents.Core.BaseHttpRequest;

/// <summary>
/// Base responses http
/// </summary>
public class BaseResponse : BaseMessage
{
    /// <summary>
    /// Constructor related correlationId requests
    /// </summary>
    /// <param name="CorrelationId">Correlation http request</param>
    public BaseResponse(Guid CorrelationId) : base()
    {
        base._correlationId = CorrelationId;
    }

    /// <summary>
    /// status request
    /// </summary>
    public bool Status { get; set; } = true;
    /// <summary>
    /// Message request
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Constructor empty 
    /// </summary>
    public BaseResponse() { }
}
