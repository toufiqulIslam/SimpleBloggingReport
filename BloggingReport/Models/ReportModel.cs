using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggingReport.Models
{
    public class ReportModel
    {
        public string Title;
        public string CreatedBy;
        public DateTime CreatedOn;
        public int CommentsCount;
        public List<comment> Comments;
        public int? LikeCount;
        public int? DislikeCount;
    }
}