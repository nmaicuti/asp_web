using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        public int Id { get; set; }

        [Required]
        public string TenLopHoc { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int NamNhapHoc { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int NamRaTruong { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SoLuongSinhVien { get; set; }
    }
}
