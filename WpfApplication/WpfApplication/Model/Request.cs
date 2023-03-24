using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApplication.Model
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Status status { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }

}
