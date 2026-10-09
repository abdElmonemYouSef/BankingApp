using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Models.Entities;

[PrimaryKey(nameof(BranchID), nameof(AccountTypeID))]
public class AccountSequence
{
    public int BranchID { get; set; }

    public int AccountTypeID { get; set; }

    public int LastNumber { get; set; }
}