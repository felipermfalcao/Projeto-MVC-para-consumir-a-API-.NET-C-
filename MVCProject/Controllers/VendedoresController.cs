using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace MVCProject.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VendedoresController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendedores");
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<IEnumerable<VendedoresViewModel>>(readTask);

            ViewBag.Vendedores = vendedores;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VendedoresViewModel vendedor)
        {
            var httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:7081/api";

            //HTTP POST
            var postTask = httpClient.PostAsJsonAsync<VendedoresViewModel>($"{apiUrl}/Vendedores", vendedor);
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(vendedor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:7081/api";

            //HTTP GET
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendedores/" + id.ToString());
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<VendedoresViewModel>(readTask);

            return View(vendedores);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, VendedoresViewModel vendedor)
        {
            var httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:7081/api";

            //HTTP PUT
            var putTask = httpClient.PutAsJsonAsync<VendedoresViewModel>($"{apiUrl}/Vendedores/" + Id.ToString(), vendedor);
            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(vendedor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP DELETE
            var deleteTask = httpClient.DeleteAsync($"{apiUrl}/Vendedores/" + id.ToString());
            var result = deleteTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendedores/" + id.ToString());
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<VendedoresViewModel>(readTask);

            return View(vendedores);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string? Nome)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendedores/nome/" + Nome);
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<IEnumerable<VendedoresViewModel>>(readTask);

            ViewBag.Vendedores = vendedores;

            return View();
        }
    }
}
