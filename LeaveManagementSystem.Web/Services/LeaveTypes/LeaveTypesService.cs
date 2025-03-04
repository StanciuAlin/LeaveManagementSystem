using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LeaveManagementSystem.Web.Services.LeaveTypes;

public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
{

    #region " Public methods "

    public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
    {
        var data = await _context.LeaveTypes.ToListAsync();
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);

        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowerCaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(name));
        //, StringComparison.InvariantCultureIgnoreCase));
        // This approach may cause problems when C# code is converted to SQL
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsOrEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowerCaseName = leaveTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(leaveTypeEdit.Name) && q.Id != leaveTypeEdit.Id);
    }

    public async Task<bool> DaysExceedMaximum(int leaveTypeId, int days)
    {
        var leaveType = await _context.LeaveTypes.FindAsync(leaveTypeId);
        if (leaveType == null)
        {
            return false;
        }
        return leaveType.NumberOfDays < days;
    }

    #endregion
}
