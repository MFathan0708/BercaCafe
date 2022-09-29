using System;
using System.Collections.Generic;

#nullable disable

namespace BercaCafe_API.Models
{
    public partial class Hrddivision
    {
        public int DivisionKey { get; set; }
        public string DivisionName { get; set; }
        public string DivisionAlias { get; set; }
        public int? DirektoratKey { get; set; }
        public DateTime? LastModify { get; set; }
        public string LastModifyName { get; set; }
        public int? LastModifyId { get; set; }
        public string CreatedName { get; set; }
        public int? CreatedId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedIn { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedIn { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte? Fsend { get; set; }
        public string SendBy { get; set; }
        public string SendIn { get; set; }
        public string SendFile { get; set; }
        public DateTime? SendTime { get; set; }
        public byte? Freceive { get; set; }
        public string ReceiveBy { get; set; }
        public string ReceiveIn { get; set; }
        public string ReceiveFile { get; set; }
        public DateTime? ReceiveTime { get; set; }
    }
}
