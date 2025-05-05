using System;

namespace Bai2_2
{
    // Khai báo lớp Phân số (từ bài 2.1)
    public class PhanSo
    {
        private int _tuSo;
        private int _mauSo;

        public PhanSo(int ts, int ms)
        {
            if (ms == 0)
            {
                Console.WriteLine("mau so phai khac 0!");
            }
            _tuSo = ts;
            _mauSo = ms;
        }

        // Phương thức nhập phân số
        public void Nhap()
        {
            Console.Write("Nhập tử số: ");
            _tuSo = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Nhập mẫu số (khác 0): ");
                _mauSo = int.Parse(Console.ReadLine());
            } while (_mauSo == 0);
        }

        // Phương thức xuất phân số
        public void Xuat()
        {
            Console.WriteLine($"{_tuSo}/{_mauSo}");
        }

        // Rút gọn phân số
        public void ToiGian()
        {
            int gcd = UCLN(Math.Abs(_tuSo), Math.Abs(_mauSo));
            _tuSo /= gcd;
            _mauSo /= gcd;
        }

        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Chuyển phân số thành số thực để so sánh
        public double GiaTri()
        {
            return (double)_tuSo / _mauSo;
        }
    }

    // Lớp danh sách phân số
    public class DSPhanSo
    {
        private PhanSo[] _dsPS;
        private int _size;

        public DSPhanSo(int size)
        {
            _size = size;
            _dsPS = new PhanSo[size];
        }

        // Nhập danh sách phân số
        public void NhapDS()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"Nhập phân số thứ {i + 1}:");
                _dsPS[i] = new PhanSo(1, 1);
                _dsPS[i].Nhap();
            }
        }

        // Xuất danh sách phân số
        public void XuatDS()
        {
            Console.WriteLine("Danh sách phân số:");
            for (int i = 0; i < _size; i++)
            {
                _dsPS[i].Xuat();
            }
        }

        // Tìm phân số lớn nhất
        public PhanSo TimPhanSoMax()
        {
            PhanSo max = _dsPS[0];
            for (int i = 1; i < _size; i++)
            {
                if (_dsPS[i].GiaTri() > max.GiaTri())
                {
                    max = _dsPS[i];
                }
            }
            return max;
        }

        // Sắp xếp danh sách phân số theo thứ tự tăng dần
        public void SapXepTangDan()
        {
            for (int i = 0; i < _size - 1; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    if (_dsPS[i].GiaTri() > _dsPS[j].GiaTri())
                    {
                        PhanSo temp = _dsPS[i];
                        _dsPS[i] = _dsPS[j];
                        _dsPS[j] = temp;
                    }
                }
            }
        }
    }

    // Chương trình chính
    class Program
    {
        static void Main()
        {
            Console.Write("Nhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine());

            DSPhanSo danhSach = new DSPhanSo(n);

            // Nhập danh sách phân số
            danhSach.NhapDS();

            // Xuất danh sách phân số
            danhSach.XuatDS();

            // Tìm phân số lớn nhất
            PhanSo max = danhSach.TimPhanSoMax();
            Console.Write("Phân số lớn nhất: ");
            max.Xuat();

            // Sắp xếp và in danh sách phân số theo thứ tự tăng dần
            danhSach.SapXepTangDan();
            Console.WriteLine("Danh sách phân số sau khi sắp xếp:");
            danhSach.XuatDS();
        }
    }
}
