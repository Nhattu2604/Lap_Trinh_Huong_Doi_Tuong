using System;
namespace bai2_1{
public class PhanSo{
    private int _tuSo;
    private int _mauSo;

public PhanSo(int ts,int ms){
    if(ms ==0) {
        Console.WriteLine("Mẫu số không được = 0");
    }
    _tuSo = ts;
    _mauSo = ms;
}
// thiet lap ham sao chep 
public PhanSo(PhanSo p){
    _tuSo =p._tuSo;
    _mauSo =p._mauSo;
}
public void Nhap(){
    Console.WriteLine("Mời bạn nhập tử số: ");
    _tuSo =int.Parse(Console.ReadLine());
    do{
    Console.WriteLine("Mời bạn nhập tử số #0: ");  
    _mauSo =int.Parse(Console.ReadLine());
    }while(_mauSo == 0);
}

public void Xuat() {
    Console.WriteLine($"{_tuSo}/{_mauSo}");
}
public void Toigian(){
    int gcd = UCLN(Math.Abs(_tuSo),Math.Abs(_mauSo));
     _tuSo /= gcd;
     _mauSo /= gcd;
}
private int UCLN(int a,int b){
    while (b!=0){
        int temp = b;
        b = a % b; 
        a = temp;
    }
    return a;
}
public PhanSo Cong(PhanSo p){
   int ts = _tuSo * p._mauSo + _mauSo * p._tuSo;
   int ms = _mauSo * p._mauSo;
    PhanSo kq = new PhanSo(ts, ms);
    kq.Toigian();
    return kq;
}
public PhanSo Tru(PhanSo p){
    int ts = _tuSo *p._mauSo - _mauSo *p._tuSo;
    int ms = _mauSo * p._mauSo;
    PhanSo kq = new PhanSo(ts,ms);
    kq.Toigian();
    return kq;
}
class Program{
    static void Main(){
    //khai bao 2 phan so 
    PhanSo p1 = new PhanSo(0,1);
    PhanSo p2 = new PhanSo(0,1);
    // nhap du lieu
    Console.WriteLine("Nhap phan so thu nhat: ");
    p1.Nhap();
    Console.WriteLine("Nhap phan so thu hai: ");
    p2.Nhap();
    //xuat du lieu
    Console.WriteLine("Phan so thu nhat: ");
    p1.Xuat();
    Console.WriteLine("Phan so thu hai: ");
    p2.Xuat();
    // toi gian phan so 
    p1.Toigian();
    p2.Toigian();
    Console.WriteLine("Phan so toi gian thu nhat: ");
    p1.Xuat();
     Console.WriteLine("Phan so toi gian thu hai: ");
    p2.Xuat();
    // tinh tong va hieu
    PhanSo tong = p1.Cong(p2);
    PhanSo hieu = p1.Tru(p2);
    Console.Write("Tong hai phan so: ");
    tong.Xuat();
     Console.Write("Hieu hai phan so: ");
    hieu.Xuat();
    }
}
}
}