﻿namespace TaskManager.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ResourceId { get; set; }
    }
}
    