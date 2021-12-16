using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class CarPrice
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập stt danh mục")]
        public string loaiXe { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập loại xe")]
        public string soGhe { get; set; }
        
        public string giaTheoGio { get; set;  }
       
        public string giaTheoNgay { get; set; }
        
        public string giaTheoLoTrinh { get; set; }
        
        public string ngayDang { get; set; }
        public string ngaySua { get; set; }
    }
}