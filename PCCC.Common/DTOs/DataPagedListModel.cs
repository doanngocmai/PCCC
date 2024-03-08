using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs
{
    public class DataPagedListModel
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public int TotalItemCount { get; set; }
        public object Data { get; set; }
    }
}
