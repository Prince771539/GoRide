namespace GoRide.Models.Enums
{
    public enum UserRole
    {
        Passenger = 1,
        Driver = 2,
        Admin = 3
    }
    public enum RideStatus
    {
        Pending = 1,
        Accepted = 2,
        Started = 3,
        Completed = 4,
        Cancelled = 5
    }
    public enum PaymentStatus
    {
        Pending = 1,
        Success = 2,
        Failed = 3
    }
}
