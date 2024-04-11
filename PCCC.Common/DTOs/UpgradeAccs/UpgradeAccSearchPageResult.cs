using PCCC.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Common.DTOs.UpgradeAccs
{
    public class UpgradeAccSearchPageResult
    {
        public int page { get; set; } = PCCCConsts.PAGE_DEFAULT;
        public int perPage { get; set; } = PCCCConsts.LIMIT_DEFAULT;
        public string? SearchKey { get; set; }
        public int? IsActive { get; set; }
        public string? fromDate { get; set; }
        public string? toDate { get; set; }
    }
}
