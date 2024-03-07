using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using SITechnicalTest.Interfaces;
using SITechnicalTest_API.Models;
using System.Text;

namespace SITechnicalTest.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly HttpClient _httpClient;
        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Create(Supplier supplier)
        {
            string json = JsonConvert.SerializeObject(supplier);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage? response = await _httpClient.PostAsync("/Supplier", content);
            return response.IsSuccessStatusCode;
        }

        [HttpDelete]
        public async Task<bool> Delete(Supplier supplier)
        {
            HttpResponseMessage? response = await _httpClient.DeleteAsync($"/Supplier?id={supplier.Id}");
            return response.IsSuccessStatusCode;
        }
        [HttpGet]
        public async Task<List<Supplier>> Get()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync("/Supplier/GetAll");
            List<Supplier> suppliers = new();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                suppliers = JsonConvert.DeserializeObject<List<Supplier>>(content);
            }
            return suppliers;
        }
       
        [HttpGet]
        public async Task<Supplier> GetByID(int id)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync($"/Supplier/GetByID?id={id}");
            Supplier supplier = new();
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                supplier = JsonConvert.DeserializeObject<Supplier>(content);
            }
            return supplier;
        }

        [HttpPut]
        public async Task<bool> Update(Supplier supplier)
        {
            string json = JsonConvert.SerializeObject(supplier);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage? response = await _httpClient.PutAsync("/Supplier", content);
            return response.IsSuccessStatusCode;
        }
    }
}
