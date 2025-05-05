using System;
using System.Collections.Generic;

namespace Bai2_4
{
    // Lớp Point đã được cài đặt ở Bài 2.3
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public void DiChuyen(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // Lớp Circle mô tả hình tròn
    class Circle
    {
        // Thuộc tính
        public double BanKinh { get; set; }
        public Point Tam { get; set; }

        // Hàm khởi tạo
        public Circle(double r, Point tam)
        {
            BanKinh = r;
            Tam = tam;
        }

        // Tính diện tích hình tròn
        public double DienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }

        // Di chuyển hình tròn (di chuyển tâm)
        public void DiChuyen(double dx, double dy)
        {
            Tam.DiChuyen(dx, dy);
        }

        public override string ToString()
        {
            return $"Hình tròn có bán kính {BanKinh} và tâm tại {Tam}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Khởi tạo một vài đối tượng hình tròn
            List<Circle> danhSachHinhTron = new List<Circle>
            {
                new Circle(3, new Point(1, 2)),
                new Circle(5, new Point(4, 6)),
                new Circle(2.5, new Point(-3, 5))
            };

            // In thông tin của các hình tròn
            Console.WriteLine("Danh sách hình tròn ban đầu:");
            foreach (var hinhTron in danhSachHinhTron)
            {
                Console.WriteLine(hinhTron);
                Console.WriteLine($"Diện tích: {hinhTron.DienTich():F2}\n");
            }

            // Di chuyển các hình tròn
            Console.WriteLine("Di chuyển các hình tròn với khoảng dx = 2, dy = 3...");
            foreach (var hinhTron in danhSachHinhTron)
            {
                hinhTron.DiChuyen(2, 3);
                Console.WriteLine(hinhTron);
            }
        }
    }
}
