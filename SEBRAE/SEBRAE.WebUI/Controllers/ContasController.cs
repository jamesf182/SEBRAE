using Microsoft.AspNetCore.Mvc;
using SEBRAE.Application.DTOs;
using SEBRAE.Application.Interfaces;

namespace SEBRAE.WebUI.Controllers
{
    public class ContasController : Controller
    {
        private readonly IContaService _contaService;
        private readonly IWebHostEnvironment _environment;
        public ContasController(IContaService service, IWebHostEnvironment environment)
        {
            _contaService = service;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contas = await _contaService.GetContas();
            return View(contas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContaDTO contaDto)
        {
            if (ModelState.IsValid)
            {
                await _contaService.Add(contaDto);
                return RedirectToAction(nameof(Index));
            }
            return View(contaDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var contaDto = await _contaService.GetById(id);

            if (contaDto == null) return NotFound();

            return View(contaDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContaDTO contaDTO)
        {
            if (ModelState.IsValid)
            {
                await _contaService.Update(contaDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(contaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contaDto = await _contaService.GetById(id);

            if (contaDto == null) return NotFound();

            return View(contaDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _contaService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
