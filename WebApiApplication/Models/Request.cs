using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApplication.Models
{
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Status status { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        [Description("Получена")]
        Received,
        [Description("В работе")]
        InWork,
        [Description("Выполнена")]
        Completed,
        [Description("Отклонена")]
        Rejected,
        [Description("Отменена")]
        Canceled
    }
}
