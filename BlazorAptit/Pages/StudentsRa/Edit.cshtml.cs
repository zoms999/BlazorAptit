﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorAptit.Data;
using BlazorAptit.Models;

namespace BlazorAptit.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly BlazorAptit.Data.SchoolContext _context;

        public EditModel(BlazorAptit.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Student = await _context.Students.FindAsync(id);


            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
        

        /*
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        */
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var studentToUpdate = await _context.Students.FindAsync(id);
            if(studentToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Student>(studentToUpdate, "student", s=> s.FirstMidName, s => s.LastName, s => s.EnrollmentDate ))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");

            }
            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
