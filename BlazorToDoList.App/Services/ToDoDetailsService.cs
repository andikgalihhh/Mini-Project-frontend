using BlazorToDoList.App.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorToDoList.App.Services
{
    public class TodoDetailService
    {
        private readonly HttpClient _httpClient;

        public TodoDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get todo details by todo ID
        public async Task<List<TodoDetail>> GetTodoDetailsByTodoIdAsync(string todoId)
        {
            var url = $"api/v1/todo/detail?todoId={todoId}";
            var response = await _httpClient.GetFromJsonAsync<List<TodoDetail>>(url);
            return response;
        }

        // Method to get all todo details (if needed)
        public async Task<List<TodoDetail>> GetAllTodoDetailsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<TodoDetail>>("api/v1/todo/detail");
            return response;
        }

        // Method to add a new todo detail
        public async Task<HttpResponseMessage> AddTodoDetailAsync(TodoDetail newTodoDetail)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/todo/detail", newTodoDetail);
            return response;
        }

        // Method to add multiple todo details
        public async Task<HttpResponseMessage> AddMultipleTodoDetailsAsync(List<TodoDetail> newTodoDetails)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/todo/detail/all", newTodoDetails);
            return response;
        }

        // Method to update an existing todo detail
        public async Task<HttpResponseMessage> UpdateTodoDetailAsync(TodoDetail updatedTodoDetail)
        {
            var response = await _httpClient.PutAsJsonAsync("api/v1/todo/detail", updatedTodoDetail);
            return response;
        }

        // Method to delete a todo detail by its ID
        public async Task<HttpResponseMessage> DeleteTodoDetailAsync(string todoDetailId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/todo/detail?todoDetailId={todoDetailId}");
            return response;
        }
    }
}
