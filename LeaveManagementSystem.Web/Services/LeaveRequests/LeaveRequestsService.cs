using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveRequests;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveRequests
{
    public class LeaveRequestsService(IMapper _mapper, 
        UserManager<ApplicationUser> _userManager,
        IHttpContextAccessor _httpContextAccessor,
        ApplicationDbContext _context) : ILeaveRequestsService
    {
        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Canceled;

            //restore allocation days based on request
            var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
            var allocation = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId && q.EmployeeId == leaveRequest.EmployeeId);

            allocation.Days += numberOfDays;

            await _context.SaveChangesAsync();
        }

        public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            // map data to leave request data model
            var leaveRequest = _mapper.Map<LeaveRequest>(model);

            // get logged in employe id
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            leaveRequest.EmployeeId = user.Id;

            // set LeaveRequestStatusId to pending
            leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;

            // save leave request
            _context.Add(leaveRequest);

            // deduct allocation days based on the request
            var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
            var allocationToDeduct = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId && q.EmployeeId == user.Id);

            allocationToDeduct.Days -= numberOfDays;

            await _context.SaveChangesAsync();
        }

        public Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var leaveRequests = await _context.LeaveRequests
                .Include(t => t.LeaveType)
                .Where(q => q.EmployeeId == user.Id)
                .ToListAsync();
            
            var model = leaveRequests.Select(q => new LeaveRequestReadOnlyVM
            {
                Id = q.Id,
                StartDate = q.StartDate,
                EndDate = q.EndDate,
                LeaveType = q.LeaveType.Name,
                LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestStatusId,
                NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
            }).ToList();

            return model;
        }

        public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
            var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
            var allocation = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId && q.EmployeeId == user.Id);

            return allocation.Days < numberOfDays;
        }

        public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
        {
            throw new NotImplementedException();
        }
    }
}
