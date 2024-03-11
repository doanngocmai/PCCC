using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.Users
{
    public class UserSearch : DataPagedListModel
    {
        public string SearchKey { get; set; }
        public int? Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
