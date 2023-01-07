using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;

namespace MVCProject.Controllers
{
    public class VendasController : Controller
    {
        private readonly HttpClient httpClient;

        public VendasController(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendas");
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendas = JsonConvert.DeserializeObject<IEnumerable<VendasViewModel>>(readTask);
            ViewBag.Vendas = vendas;

            var responseTaskV = httpClient.GetAsync($"{apiUrl}/Vendedores");
            var resultV = responseTaskV.Result;
            var readTaskV = await resultV.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<IEnumerable<VendedoresViewModel>>(readTaskV);
            ViewBag.Vendedores = vendedores;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendedores");
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<IEnumerable<VendedoresViewModel>>(readTask);

            ViewBag.Vendedores = vendedores;

            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Create(VendasViewModel vendas)
        {
            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP POST
            var postTask = httpClient.PostAsJsonAsync<VendasViewModel>($"{apiUrl}/Vendas", vendas);
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(vendas);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP GET
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendas/" + id.ToString());
            var result = responseTask.Result;
            var readTask = await result.Content.ReadAsStringAsync();
            var venda = JsonConvert.DeserializeObject<VendasViewModel>(readTask);
            //ViewBag.Venda = venda;

            //var responseTaskV = httpClient.GetAsync($"{apiUrl}/Vendedores" + venda.Id.ToString());
            //var resultV = responseTaskV.Result;
            //var readTaskV = await resultV.Content.ReadAsStringAsync();
            //var vendedor = JsonConvert.DeserializeObject<VendedoresViewModel>(readTaskV);
            //ViewBag.Vendedor = vendedor;

            return View(venda);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, VendasViewModel vendas)
        {
            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP PUT
            var putTask = httpClient.PutAsJsonAsync<VendasViewModel>($"{apiUrl}/Vendas/" + Id.ToString(), vendas);
            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(vendas);
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP DELETE
            var deleteTask = httpClient.DeleteAsync($"{apiUrl}/Vendas/" + id.ToString());
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
            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendas/" + id.ToString());
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var venda = JsonConvert.DeserializeObject<VendasViewModel>(readTask);

            return View(venda);
            
        }

        [HttpGet]
        public async Task<IActionResult> SelectByInterval(DateTime minDate, DateTime maxDate)
        {
            var min = minDate.ToString("yyyy-MM-dd");
            var max = maxDate.ToString("yyyy-MM-dd");

            //var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Vendas/Data/" + min + "&" + max);
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var vendas = JsonConvert.DeserializeObject<IEnumerable<VendasViewModel>>(readTask);
            ViewBag.Vendas = vendas;

            var responseTaskV = httpClient.GetAsync($"{apiUrl}/Vendedores");
            var resultV = responseTaskV.Result;
            var readTaskV = await resultV.Content.ReadAsStringAsync();
            var vendedores = JsonConvert.DeserializeObject<IEnumerable<VendedoresViewModel>>(readTaskV);
            ViewBag.Vendedores = vendedores;

            return View();
            
        }
    }
}
