// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Viết chương trình C# thực hiện các công việc sau (mỗi chức năng xây dựng thành một hàm):
// a) Nhập một mảng n số nguyên từ bàn phím.
// b) In các phần tử của mảng lên màn hình.
// c) Trả về phần tử lớn nhất của mảng.
// d) Trả về kiểu boolean kiểm tra mảng đã được sắp xếp tăng dần chưa.
// e) Sắp xếp mảng theo thứ tự tăng dần.
// f) Tách mảng thành 2 mảng con: một mảng chứa các phần tử chẵn, mảng còn lại chứa các phần tử lẻ.

using System;
using System.Linq;

class Program{
    static int[] Nhapmang(){
        Console.Write("Nhap so luong phan tu cua mang: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n;i++){
            Console.Write($"Nhap so luong phan tu thu {i +1}: ");
           arr[i] = int.Parse(Console.ReadLine()) ;
        
        }
        return arr;
    }
    static void Inmang(int[] arr) {
        Console.WriteLine("Cac phan tu trong mang: "+ string.Join(", ",arr));
    }
    static int Timmax(int[] arr) {
        return arr.Max();
    }
    static bool KiemtraTangdan(int[] arr){
        for (int i = 0; i < arr.Length -1 ; i++) {
            if (arr[i] > arr[i+1]) {
                return false;
            }
            
        }
        return true;
    }
    static void SapxepTangdan (ref int[] arr){
         Array.Sort(arr);
    }
    static void Tachmang (int[] arr, out int[] Mangchan, out int[] Mangle){
        Mangchan = arr.Where(x => x%2 == 0).ToArray();
        Mangle = arr.Where(x => x%2 != 0).ToArray();

    }
    static void Main() {
        int[] arr = Nhapmang();
        Inmang(arr);
        Console.WriteLine("Phan tu lon nhat trong mang: "+Timmax(arr));
        Console.WriteLine("Mang co sap xep tang dan hay khong? " + (KiemtraTangdan(arr) ? "Co":"Khong"));
        SapxepTangdan(ref arr);
        Console.WriteLine("Mang sau khi sap xep tang dan: ");
        Inmang(arr);
        Tachmang (arr,out int[] Mangchan,out int[] Mangle);
        Console.WriteLine("Mang chan: "+ string.Join(", ",Mangchan));
        Console.WriteLine("Mang le: "+ string.Join(", ",Mangle));
    }
}