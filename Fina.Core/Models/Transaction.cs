using Fina.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? PaidOrReceivedAt { get; set; }
        public decimal Amount { get; set; }
        public EnTransactionType Type { get; set; } = EnTransactionType.WithDraw;
        public string UserId { get; set; } = string.Empty ;
        public long CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }
}
