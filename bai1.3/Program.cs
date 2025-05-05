using System;
class Program{
    static void Main() {
        Console.Write("Nhap so luong vi trung ban dau: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Nhap so gio: ");
        int h = int.Parse(Console.ReadLine());
        long S = n * (long)Math.Pow(2,h);
        Console.WriteLine($"So luong vi trung nhan len {h} la: {S} ");
    }



}