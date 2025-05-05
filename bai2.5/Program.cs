using System;

class Stack
{
    private int top;           // Chỉ số phần tử trên cùng
    private const int Max = 100; // Kích thước tối đa của stack
    private int[] stack;       // Mảng lưu trữ các phần tử trong stack

    // Khởi tạo stack rỗng
    public Stack()
    {
        top = -1;
        stack = new int[Max];
    }

    // Thêm phần tử vào stack
    public void Push(int data)
    {
        if (top >= Max - 1)
        {
            Console.WriteLine("Stack đầy, không thể thêm phần tử.");
        }
        else
        {
            stack[++top] = data;
        }
    }

    // Lấy ra phần tử trên cùng và xóa khỏi stack
    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack rỗng, không thể Pop.");
            return -1;
        }
        else
        {
            return stack[top--];
        }
    }

    // Lấy giá trị phần tử trên cùng nhưng không xóa
    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack rỗng.");
            return -1;
        }
        return stack[top];
    }

    // Kiểm tra xem stack có rỗng không
    public bool IsEmpty()
    {
        return top == -1;
    }

    // In ra các phần tử trong stack
    public void Print()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack rỗng.");
            return;
        }
        Console.Write("Các phần tử trong Stack: ");
        for (int i = 0; i <= top; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }
}

// Chương trình chính
class Program
{
    // Phân tích thừa số nguyên tố
    static void PhanTichThuaSoNguyenTo(int n)
    {
        Stack s = new Stack();
        Console.Write($"Phân tích {n} thành thừa số nguyên tố: ");
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            while (n % i == 0)
            {
                s.Push(i);
                n /= i;
            }
        }
        if (n > 1)
        {
            s.Push(n); // Nếu n là số nguyên tố
        }

        // In ra các thừa số theo thứ tự ngược
        Console.Write("= ");
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
            if (!s.IsEmpty()) Console.Write(" * ");
        }
        Console.WriteLine();
    }

    // Đổi số nguyên sang hệ nhị phân
    static void ChuyenSangNhiPhan(int n)
    {
        Stack s = new Stack();
        while (n > 0)
        {
            s.Push(n % 2);
            n /= 2;
        }
        Console.Write("Hệ nhị phân: ");
        while (!s.IsEmpty())
        {
            Console.Write(s.Pop());
        }
        Console.WriteLine();
    }

    // Đổi số nguyên sang hệ thập lục phân
    static void ChuyenSangThapLucPhan(int n)
    {
        Stack s = new Stack();
        string hexDigits = "0123456789ABCDEF";
        while (n > 0)
        {
            s.Push(n % 16);
            n /= 16;
        }
        Console.Write("Hệ thập lục phân: ");
        while (!s.IsEmpty())
        {
            Console.Write(hexDigits[s.Pop()]);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.Write("Nhập số nguyên cần phân tích và đổi hệ: ");
        int n = int.Parse(Console.ReadLine());

        // Phân tích thừa số nguyên tố
        PhanTichThuaSoNguyenTo(n);

        // Đổi sang hệ nhị phân
        ChuyenSangNhiPhan(n);

        // Đổi sang hệ thập lục phân
        ChuyenSangThapLucPhan(n);
    }
}
