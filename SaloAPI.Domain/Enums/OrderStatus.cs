namespace SaloAPI.Domain.Enums;

public enum OrderStatus
{
    /// <summary>
    /// Order is unconfirmed
    /// </summary>
    Unconfirmed = 1,
    
    /// <summary>
    /// Order is confirmed and preparing
    /// </summary>
    Confirmed = 2,

    /// <summary>
    /// Order is ready to be delivered
    /// </summary>
    Ready = 3,
}