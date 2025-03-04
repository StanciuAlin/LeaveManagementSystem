using LeaveManagementSystem.Web.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    // Lookup table for the list of leave request statuses

    // Another way to bind the configuration for this class to the configuration here
    // [EntityTypeConfiguration(typeof(LeaveRequestStatusConfiguration))]
    public class LeaveRequestStatus : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }
    }
}