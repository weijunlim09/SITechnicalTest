using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SITechnicalTest.Interfaces;
using SITechnicalTest_API.Models;
using System.Text;

namespace SITechnicalTest.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly HttpClient _httpClient;
        public QuotationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [HttpGet]
        public async Task<List<Quotation>> Get()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync("/Quotation/GetAll");
            List<Quotation> quotations = new();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                quotations = JsonConvert.DeserializeObject<List<Quotation>>(content);
            }
            return quotations;
        }

        [HttpGet]
        public async Task<Quotation> GetByID(int id)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync($"/Quotation/GetByID?id={id}");
            Quotation quotation = new();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                quotation = JsonConvert.DeserializeObject<Quotation>(content);
            }
            return quotation;
        }

        [HttpPost]
        public async Task<bool> Create(Quotation quotation)
        {
            string json = JsonConvert.SerializeObject(quotation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage? response = await _httpClient.PostAsync("/Quotation", content);
            return response.IsSuccessStatusCode;
        }

        [HttpPut]
        public async Task<bool> Update(Quotation quotation)
        {
            string json = JsonConvert.SerializeObject(quotation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage? response = await _httpClient.PutAsync("/Quotation", content);
            return response.IsSuccessStatusCode;
        }

        [HttpDelete]
        public async Task<bool> Delete(Quotation quotation)
        {
            HttpResponseMessage? response = await _httpClient.DeleteAsync($"/Quotation?id={quotation.QuotationId}");
            return response.IsSuccessStatusCode;
        }
    }
}
