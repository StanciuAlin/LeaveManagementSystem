using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveTypesController(ILeaveTypesService _leaveTypesService) : Controller
    {

        private const string NameExistsValidationMessage = "This leave type already exists in the database";

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            // Use the Service methods

            //var data = await _context.LeaveTypes.ToListAsync();
            //// convert the DataModel into a ViewModel

            //// This is manual mapping
            ////var viewData = data.Select(q => new LeaveTypeReadOnlyVM
            ////{
            ////    Id = q.Id,
            ////    Name = q.Name,
            ////    NumberOfDays = q.NumberOfDays
            ////});

            //// Now use Automapper
            //var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

            var viewData = await _leaveTypesService.GetAll();
            
            // return the ViewModel to the View
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            // How to add custom validation and model state error
            //if (leaveTypeCreate.Name.Contains("vacation"))
            //{
            //    ModelState.AddModelError(nameof(leaveTypeCreate.Name), "Name should not contain vacation");
            //}

            // How to add custom validation and model state error
            if (await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                await _leaveTypesService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await _leaveTypesService.CheckIfLeaveTypeNameExistsOrEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leaveTypesService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leaveTypesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
