﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Models.Product;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7000/api/Products/ProductsListWithCategory");
            var productsWithCategory = new List<ResultProductWithCategoryDto>();
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                productsWithCategory = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7000/api/Categories");
            var categoryDtos = new List<ResultCategoryDto>();
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                categoryDtos = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            }
            productsWithCategory = productsWithCategory
                                                        .Where(p => p.Category != null)
                                                        .OrderBy(p => p.Category.CategoryId)
                                                        .ToList();


            var viewModel = new ProductandCategoryViewModel
            {
                ProductsWithCategory = productsWithCategory,
                Categories = categoryDtos
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7000/api/Baskets", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok("Eklendi");
            }
            return NotFound("Hata");
        }
    }
}

