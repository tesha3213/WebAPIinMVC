using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcNguoiDungModel
    {
        
        public int IdNguoiDung { get; set; }
        [Required(ErrorMessage = "This Field is Required, Sir !")]
        [DisplayName("Ten dang nhap")]
        public string TenDangNhap { get; set; }
        [Required(ErrorMessage = "This Field is Required, Sir !")]
        [DisplayName("Mat khau")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "This Field is Required, Sir !")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "This Field is Required, Sir !")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string sdt { get; set; }
       
    }
}