﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorAptit.Data;
using BlazorAptit.Models;

namespace BlazorAptit.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly BlazorAptit.Data.SchoolContext _context;

        public DetailsModel(BlazorAptit.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);

            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);



            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
