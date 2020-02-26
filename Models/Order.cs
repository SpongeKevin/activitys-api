using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long ActivityId { get; set; }
        public long UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public bool IsComplete { get; set; }
    }
}
