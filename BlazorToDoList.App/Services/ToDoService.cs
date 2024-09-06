using BlazorToDoList.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BlazorToDoList.App.Services
{
    public class TodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get todos from the API
        public async Task<List<Todo>> GetTodosAsync()
        {
            var url = $"api/v1/todo?pageNumber={1}&pageSize={1000}";
            var response = await _httpClient.GetFromJsonAsync<List<Todo>>(url);
            return response;
        }

        // Method to get a specific todo by ID
        public async Task<Todo> GetTodoByIdAsync(string todoId)
        {
            var response = await _httpClient.GetFromJsonAsync<Todo>($"api/v1/todo/{todoId}");
            return response;
        }

        // Method to add a new todo
        public async Task<HttpResponseMessage> AddTodoAsync(Todo newTodo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/todo", newTodo);
            return response;
        }

        // Method to update an existing todo
        public async Task<HttpResponseMessage> UpdateTodoAsync(Todo updatedTodo)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/todo", updatedTodo);
            return response;
        }

        // Method to delete a todo
        public async Task<HttpResponseMessage> DeleteTodoAsync(string todoId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/todo/?todoId={todoId}");
            return response;
        }
    }
}

