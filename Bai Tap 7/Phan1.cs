using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    static void Main(string[] args)
    {

        // 1. Tạo mảng số nguyên ngẫu nhiên gồm 10 phần tử
        Random rand = new Random();
        int[] array = new int[10];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, 31);
        }

        Console.WriteLine("=== THUC THI CAC HAM XU LY MANG NGAU NHIEN ===");
        Console.Write("Mang ban dau: ");
        PrintArray(array);
        Console.WriteLine(new string('-', 45));

        // 1. Tính giá trị trung bình
        double average = CalculateAverage(array);
        Console.WriteLine($"1. Gia tri trung binh cua mang: {average:F2}");

        // 2. Kiểm tra mảng có chứa một giá trị cụ thể không
        int testValue = array[0];
        Console.WriteLine($"2. Mang co chua {testValue} khong? {ContainsValue(array, testValue)}");

        // 3. Tìm chỉ số (index) của một phần tử
        int index = FindIndex(array, testValue);
        Console.WriteLine($"3. Vi tri (index) dau tien cua gia tri {testValue}: {index}");

        // 4. Xóa một phần tử cụ thể khỏi mảng
        int[] arrayAfterRemove = RemoveElement(array, testValue);
        Console.Write($"4. Mang sau khi xoa gia tri {testValue}: ");
        PrintArray(arrayAfterRemove);

        // ==========================================
        // ĐÃ ĐƯA CÁC PHẦN DƯỚI NÀY VÀO TRONG HÀM MAIN:
        // ==========================================

        // 5. Tìm giá trị lớn nhất và nhỏ nhất
        int min = 0;
        int max = 0;
        FindMinMax(array, out min, out max);
        Console.WriteLine($"5. Gia tri nho nhat (Min): {min} | Gia tri lon nhat (Max): {max}");

        // 6. Đảo ngược mảng số nguyên
        int[] reversedArray = ReverseArray(array);
        Console.Write("6. Mang sau khi dao nguoc: ");
        PrintArray(reversedArray);

        // 7. Tìm các giá trị bị trùng lặp trong mảng
        List<int> duplicates = FindDuplicates(array);
        Console.Write("7. Cac gia tri trung lap: ");
        if (duplicates.Count > 0)
            Console.WriteLine(string.Join(", ", duplicates));
        else
            Console.WriteLine("Khong co phan tu trung lap.");

        // 8. Xóa các phần tử trùng lặp (giữ lại 1 bản sao duy nhất)
        int[] uniqueArray = RemoveDuplicates(array);
        Console.Write("8. Mang sau khi loai bo cac phan tu trung lap: ");
        PrintArray(uniqueArray);
    } // <--- KẾT THÚC HÀM MAIN Ở ĐÂY

    // --- ĐỊNH NGHĨA CÁC HÀM NẰM BÊN DƯỚI HÀM MAIN (NẰM TRONG CLASS PROGRAM) ---

    static double CalculateAverage(int[] arr)
    {
        if (arr.Length == 0) return 0;
        long sum = 0;
        foreach (int num in arr)
        {
            sum += num;
        }
        return (double)sum / arr.Length;
    }

    static bool ContainsValue(int[] arr, int val)
    {
        foreach (int num in arr)
        {
            if (num == val) return true;
        }
        return false;
    }

    static int FindIndex(int[] arr, int val)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == val) return i;
        }
        return -1;
    }

    static int[] RemoveElement(int[] arr, int val)
    {
        List<int> list = new List<int>(arr);
        list.Remove(val);
        return list.ToArray();
    }

    static void FindMinMax(int[] arr, out int min, out int max)
    {
        min = arr[0];
        max = arr[0];
        foreach (int num in arr)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }
    }

    static int[] ReverseArray(int[] arr)
    {
        int[] rev = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            rev[i] = arr[arr.Length - 1 - i];
        }
        return rev;
    }

    static List<int> FindDuplicates(int[] arr)
    {
        List<int> dups = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j] && !dups.Contains(arr[i]))
                {
                    dups.Add(arr[i]);
                }
            }
        }
        return dups;
    }

    static int[] RemoveDuplicates(int[] arr)
    {
        List<int> unique = new List<int>();
        foreach (int num in arr)
        {
            if (!unique.Contains(num))
            {
                unique.Add(num);
            }
        }
        return unique.ToArray();
    }

    static void PrintArray(int[] arr)
    {
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }
}