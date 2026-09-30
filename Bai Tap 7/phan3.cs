using System;

class Program
{
    static void Main(string[] args)
    {
        // Thiết lập hiển thị tiếng Việt có dấu
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // 1. Nhập N và M và tạo ma trận ngẫu nhiên
        Console.Write("Nhập số hàng N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Nhập số cột M: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = CreateRandomMatrix(n, m, 1, 99);

        // 2. In ma trận
        Console.WriteLine("\n--- Ma trận ngẫu nhiên ---");
        PrintMatrix(matrix);

        // 3. In hàng/cột thứ i (với i được nhập từ bàn phím)
        Console.Write($"\nNhập chỉ số i (0 đến {Math.Max(n, m) - 1}) để in hàng/cột: ");
        int i = int.Parse(Console.ReadLine());

        Console.WriteLine("\n--- Kết quả in hàng và cột ---");
        if (i >= 0 && i < n)
        {
            Console.Write($"Hàng thứ {i}: ");
            PrintRow(matrix, i);
        }
        else
        {
            Console.WriteLine($"Chỉ số i = {i} vượt quá số hàng của ma trận.");
        }

        if (i >= 0 && i < m)
        {
            Console.Write($"Cột thứ {i}: ");
            PrintCol(matrix, i);
        }
        else
        {
            Console.WriteLine($"Chỉ số i = {i} vượt quá số cột của ma trận.");
        }

        // 4. Tìm giá trị lớn nhất của ma trận
        int maxVal = FindMax(matrix);
        Console.WriteLine($"\nGiá trị lớn nhất trong toàn bộ ma trận: {maxVal}");

        // 5. Tìm giá trị nhỏ nhất của hàng/cột thứ i
        Console.WriteLine("\n--- Giá trị nhỏ nhất ở hàng/cột thứ i ---");
        if (i >= 0 && i < n)
        {
            Console.WriteLine($"Giá trị nhỏ nhất ở hàng {i}: {FindMinInRow(matrix, i)}");
        }
        if (i >= 0 && i < m)
        {
            Console.WriteLine($"Giá trị nhỏ nhất ở cột {i}: {FindMinInCol(matrix, i)}");
        }

        // 6. Chuyển vị ma trận (Transpose)
        int[,] transposedMatrix = TransposeMatrix(matrix);
        Console.WriteLine("\n--- Ma trận sau khi chuyển vị (Transpose) ---");
        PrintMatrix(transposedMatrix);

        // 7. In đường chéo chính và đường chéo phụ (chỉ áp dụng cho ma trận vuông N == M)
        Console.WriteLine("\n--- Đường chéo ma trận ---");
        if (n == m)
        {
            PrintDiagonals(matrix);
        }
        else
        {
            Console.WriteLine("Đây không phải là ma trận vuông (N != M), không có đường chéo chính và phụ.");
        }
    }

    // --- CÁC HÀM XỬ LÝ MA TRẬN ---

    // 1. Tạo ma trận ngẫu nhiên kích thước N x M
    static int[,] CreateRandomMatrix(int n, int m, int minValue, int maxValue)
    {
        Random rand = new Random();
        int[,] mat = new int[n, m];
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                mat[r, c] = rand.Next(minValue, maxValue + 1);
            }
        }
        return mat;
    }

    // 2. In ma trận ra màn hình dạng bảng
    static void PrintMatrix(int[,] mat)
    {
        int n = mat.GetLength(0);
        int m = mat.GetLength(1);
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                Console.Write($"{mat[r, c],4} ");
            }
            Console.WriteLine();
        }
    }

    // 3a. In hàng thứ rowIdx
    static void PrintRow(int[,] mat, int rowIdx)
    {
        int m = mat.GetLength(1);
        for (int c = 0; c < m; c++)
        {
            Console.Write($"{mat[rowIdx, c]} ");
        }
        Console.WriteLine();
    }

    // 3b. In cột thứ colIdx
    static void PrintCol(int[,] mat, int colIdx)
    {
        int n = mat.GetLength(0);
        for (int r = 0; r < n; r++)
        {
            Console.Write($"{mat[r, colIdx]} ");
        }
        Console.WriteLine();
    }

    // 4. Tìm giá trị lớn nhất của ma trận
    static int FindMax(int[,] mat)
    {
        int max = mat[0, 0];
        int n = mat.GetLength(0);
        int m = mat.GetLength(1);
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if (mat[r, c] > max)
                {
                    max = mat[r, c];
                }
            }
        }
        return max;
    }

    // 5a. Tìm min của hàng thứ rowIdx
    static int FindMinInRow(int[,] mat, int rowIdx)
    {
        int m = mat.GetLength(1);
        int min = mat[rowIdx, 0];
        for (int c = 1; c < m; c++)
        {
            if (mat[rowIdx, c] < min)
            {
                min = mat[rowIdx, c];
            }
        }
        return min;
    }

    // 5b. Tìm min của cột thứ colIdx
    static int FindMinInCol(int[,] mat, int colIdx)
    {
        int n = mat.GetLength(0);
        int min = mat[0, colIdx];
        for (int r = 1; r < n; r++)
        {
            if (mat[r, colIdx] < min)
            {
                min = mat[r, colIdx];
            }
        }
        return min;
    }

    // 6. Chuyển vị ma trận (đổi chỗ hàng thành cột)
    static int[,] TransposeMatrix(int[,] mat)
    {
        int n = mat.GetLength(0);
        int m = mat.GetLength(1);
        int[,] trans = new int[m, n];
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                trans[c, r] = mat[r, c];
            }
        }
        return trans;
    }

    // 7. In đường chéo chính và đường chéo phụ (dành cho ma trận vuông)
    static void PrintDiagonals(int[,] mat)
    {
        int n = mat.GetLength(0);

        Console.Write("Đường chéo chính: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{mat[i, i]} ");
        }
        Console.WriteLine();

        Console.Write("Đường chéo phụ: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{mat[i, n - 1 - i]} ");
        }
        Console.WriteLine();
    }
}