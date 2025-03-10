﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancaTCC.Data;
using BancaTCC.Models;

namespace BancaTCC.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly BancaTCCContext _context;

        public ProfessorController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Professores.ToListAsync());
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Professor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Email")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                // Verifica se já existe um professor com o mesmo email
                var emailExistente2 = await _context.Professores
                    .FirstOrDefaultAsync(a => a.Email == professor.Email);
                if (emailExistente2 != null)
                {
                    ModelState.AddModelError("Email", "Já existe um professor com esse email.");
                }

                // Verifica se já existe um professor com a mesma matrícula
                var matriculaExistente2 = await _context.Professores
                    .FirstOrDefaultAsync(a => a.Matricula == professor.Matricula);
                if (matriculaExistente2 != null)
                {
                    ModelState.AddModelError("Matricula", "Já existe um professor com essa matrícula.");
                }

                // Se não houver erros, salva o novo professor
                if (ModelState.IsValid)
                {
                    _context.Add(professor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(professor);
        }


        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Professor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Email")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Verifica se já existe um professor com o mesmo email, mas ignorando o próprio professor
                    var emailExistente = await _context.Professores
                        .FirstOrDefaultAsync(a => a.Email == professor.Email && a.Id != professor.Id);
                    if (emailExistente != null)
                    {
                        ModelState.AddModelError("Email", "Já existe um professor com esse email.");
                    }

                    // Verifica se já existe um professor com a mesma matrícula, mas ignorando o próprio professor
                    var matriculaExistente = await _context.Professores
                        .FirstOrDefaultAsync(a => a.Matricula == professor.Matricula && a.Id != professor.Id);
                    if (matriculaExistente != null)
                    {
                        ModelState.AddModelError("Matricula", "Já existe um professor com essa matrícula.");
                    }

                    // Se não houver erros, atualiza o professor
                    if (ModelState.IsValid)
                    {
                        _context.Update(professor);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(professor);
        }


        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor != null)
            {
                _context.Professores.Remove(professor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }
    }
}
