using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using Newtonsoft.Json;

namespace MVCProject.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProdutosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Produtos");
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var produtos = JsonConvert.DeserializeObject<IEnumerable<ProdutosViewModel>>(readTask);

            ViewBag.Produtos = produtos;

            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProdutosViewModel produtos)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP POST
            var postTask = httpClient.PostAsJsonAsync<ProdutosViewModel>($"{apiUrl}/Produtos", produtos);
            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(produtos);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP GET
            var responseTask = httpClient.GetAsync($"{apiUrl}/Produtos/" + id.ToString());
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var produtos = JsonConvert.DeserializeObject<ProdutosViewModel>(readTask);

            return View(produtos);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, ProdutosViewModel produtos)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP PUT
            var putTask = httpClient.PutAsJsonAsync<ProdutosViewModel>($"{apiUrl}/Produtos/" + Id.ToString(), produtos);
            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(produtos);
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";

            //HTTP DELETE
            var deleteTask = httpClient.DeleteAsync($"{apiUrl}/Produtos/" + id.ToString());
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
            var responseTask = httpClient.GetAsync($"{apiUrl}/Produtos/" + id.ToString());
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var produtos = JsonConvert.DeserializeObject<ProdutosViewModel>(readTask);

            return View(produtos);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string? Nome)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string apiUrl = "https://localhost:7081/api";
            var responseTask = httpClient.GetAsync($"{apiUrl}/Produtos/nome/" + Nome);
            var result = responseTask.Result;

            var readTask = await result.Content.ReadAsStringAsync();
            var produtos = JsonConvert.DeserializeObject<IEnumerable<ProdutosViewModel>>(readTask);

            ViewBag.Produtos = produtos;

            return View();
            
        }
    }
}
