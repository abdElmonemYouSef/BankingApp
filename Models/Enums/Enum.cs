namespace BankingApp.Models.Enums;

public enum CustomerStatus
{
    Active = 1,
    Inactive = 2,
    Blocked = 3
}

public enum AccountStatus
{
    Active = 1,
    Frozen = 2,
    Closed = 3
}

public enum TransactionStatus
{
    Pending = 1,
    Completed = 2,
    Failed = 3,
    Rejected = 4
}

public enum PendingApprovalStatus
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}

public enum TransactionChannel
{
    Branch = 1,
    InternetBanking = 2,
    MobileBanking = 3,
    ATM = 4
}