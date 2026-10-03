using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Models.Entities
{
    [PrimaryKey(nameof(EmployeeID), nameof(RoleID))] 
    public class EmployeeRole
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; } = null!;

        public int RoleID { get; set; }
        public Role Role { get; set; } = null!;
    }
}