using System;
using System.Collections.Generic;

namespace BlazorToDoList.App.Models
{
    public class Todo
    {
        public string TodoId { get; set; }
        public string Day { get; set; }
        public string TodayDate { get; set; }
        public string Note { get; set; }
        public int DetailCount { get; set; }
        public List<TodoDetail> TodoDetails { get; set; }
    }

    public class TodoDetail
    {
        public string TodoDetailId { get; set; }
        public string TodoId { get; set; }
        public string Activity { get; set; }
        public string Category { get; set; }
        public string DetailNote { get; set; }
    }
}
