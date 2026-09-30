using System;

class Program
{
    static void Main(string[] args)
    {
        // --- BÀI 1: NHẬP 10 SỐ VÀ SẮP XẾP NỔI BỌT (BUBBLE SORT) ---
        Console.WriteLine("=== 1. SAP XEP NOI BOT 10 SO NGUYEN ===");
        int[] numbers = InputArray(10);

        Console.Write("Mang ban dau: ");
        PrintArray(numbers);

        // Gọi hàm sắp xếp nổi bọt
        BubbleSort(numbers);

        Console.Write("Mang sau khi sap xep tang dan: ");
        PrintArray(numbers);

        Console.WriteLine("\n--------------------------------------------------");

        // --- BÀI 2: NHẬP CÂU, TỪ VÀ TÌM KIẾM TUYẾN TÍNH (LINEAR SEARCH) ---
        Console.WriteLine("=== 2. TIM KIEM TU TRONG CAU (LINEAR SEARCH) ===");
        Console.Write("Nhap vao mot cau: ");
        string sentence = Console.ReadLine();

        Console.Write("Nhap tu can tim kiem: ");
        string targetWord = Console.ReadLine();

        // Tách câu thành danh sách các từ
        string[] words = sentence.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Gọi hàm tìm kiếm tuyến tính
        int index = LinearSearch(words, targetWord);

        if (index != -1)
        {
            Console.WriteLine($"Ket qua: Da tim thay tu '{targetWord}' trong cau tai vi tri (index) thu {index}.");
        }
        else
        {
            Console.WriteLine($"Ket qua: Khong tim thay tu '{targetWord}' trong cau.");
        }
    } // Kết thúc hàm Main

    // --- CÁC HÀM BỔ TRỢ NẰM BÊN TRONG CLASS PROGRAM ---

    static int[] InputArray(int n)
    {
        int[] arr = new int[n];
        Console.WriteLine($"Vui long nhap vao {n} so nguyen:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Phan tu thu {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.Write("Gia tri khong hop le! Vui long nhap lai so nguyen: ");
            }
        }
        return arr;
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    static int LinearSearch(string[] arr, string target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Equals(target, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }
} // Kết thúc class Program