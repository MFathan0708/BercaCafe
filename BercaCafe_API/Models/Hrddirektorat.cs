using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class Hrddirektorat
    {
        public string DirektoratKey { get; set; }
        public string DirektoratName { get; set; }
        public DateTime? LastModify { get; set; }
        public string LastModifyName { get; set; }
        public int? LastModifyId { get; set; }
        public string DirektoratAlias { get; set; }
        public string CreatedName { get; set; }
        public int? CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIn { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedIn { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public int? Fsend { get; set; }
        public string SendBy { get; set; }
        public string SendIn { get; set; }
        public string SendFile { get; set; }
        public DateTime? SendTime { get; set; }
        public int? Freceive { get; set; }
        public string ReceiveBy { get; set; }
        public string ReceiveIn { get; set; }
        public string ReceiveFile { get; set; }
        public DateTime? ReceiveTime { get; set; }
    }
}
