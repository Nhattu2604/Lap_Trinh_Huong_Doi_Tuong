using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace bai2_3
{
    class Point
    {
        // Thuộc tính tọa độ x, y
       public double X {get; set;}
       public double Y {get; set; }
        // Hàm khởi tạo để gán giá trị ban đầu cho tọa độ x và y
        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        // Hàm Move để di chuyển điểm với khoảng cách dx và dy
        public void DiChuyen(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        // Tính khoảng cách từ điểm hiện tại đến gốc tọa độ (0,0)
        public double KhoangCachGoc()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        // Tính khoảng cách giữa hai điểm
        public double KhoangCachDen(Point diemKhac)
        {
            return Math.Sqrt(Math.Pow(X - diemKhac.X, 2) + Math.Pow(Y - diemKhac.Y, 2));
        }

        // Ghi đè phương thức ToString để in thông tin tọa độ của điểm
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    class Program
    {
        static void Main()
        {
            // Khai báo danh sách các điểm
            List<Point> danhSachDiem = new List<Point>
            {
                new Point(1, 2),
                new Point(4, 6),
                new Point(-3, 5),
                new Point(7, -8),
                new Point(0, 0)
            };

            // In ra tọa độ của các điểm
            Console.WriteLine("Danh sách các điểm:");
            foreach (var diem in danhSachDiem)
            {
                Console.WriteLine(diem);
            }

            // Tìm điểm cách xa gốc tọa độ nhất
            Point diemXaNhat = danhSachDiem.OrderByDescending(d => d.KhoangCachGoc()).FirstOrDefault();
            Console.WriteLine($"\nĐiểm cách xa gốc tọa độ nhất: {diemXaNhat}");

            // Tìm cặp điểm gần nhau nhất
            double khoangCachNganNhat = double.MaxValue;
            Point diem1 = null, diem2 = null;
            for (int i = 0; i < danhSachDiem.Count; i++)
            {
                for (int j = i + 1; j < danhSachDiem.Count; j++)
                {
                    double khoangCach = danhSachDiem[i].KhoangCachDen(danhSachDiem[j]);
                    if (khoangCach < khoangCachNganNhat)
                    {
                        khoangCachNganNhat = khoangCach;
                        diem1 = danhSachDiem[i];
                        diem2 = danhSachDiem[j];
                    }
                }
            }
            Console.WriteLine($"\nCặp điểm gần nhau nhất là {diem1} và {diem2} với khoảng cách: {khoangCachNganNhat}");
        }
    }
}
