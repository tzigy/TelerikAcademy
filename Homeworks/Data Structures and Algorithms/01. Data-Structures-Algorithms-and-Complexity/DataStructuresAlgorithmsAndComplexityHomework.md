Data Structures, Algorithms and Complexity Homework
===
***

**Task 1.** What is the expected running time of the following C# code? Explain why.
Assume the array's size is n.

```cs
  long Compute(int[] arr)
  {
      long count = 0;
      for (int i=0; i<arr.Length; i++)
      {
          int start = 0, end = arr.Length-1;
          while (start < end)
              if (arr[start] < arr[end])
                  { start++; count++; }
              else 
                  end--;
      }
      return count;
  }
  ```

The complexity is __O(n*n)__: The inside while loop has complexity __O(n)__ and it will be executed n times(the comlexity of outher for loop O(n)) => O(n) * O(n) = __O(n * n)__.

***

**Task 2.** What is the expected running time of the following C# code?
Explain why.
Assume the input matrix has size of n * m.

```cs
  long CalcCount(int[,] matrix)
  {
      long count = 0;
      for (int row=0; row<matrix.GetLength(0); row++)
          if (matrix[row, 0] % 2 == 0)
              for (int col=0; col<matrix.GetLength(1); col++)
                  if (matrix[row,col] > 0)
                      count++;
      return count;
  }
  ```

The complexity is __O(n*m)__:  The first loop has complexity __O(n)__(iterates n times, i.e. for each row) and the second loop in worst-case has compelxity __O(m)__(iterates m times, i.e. for each column) => O(n) * O(m) = __O(n * m)__ .

***

**Task 3.**  What is the expected running time of the following C# code?
Explain why.
Assume the input matrix has size of n * m.

```cs
  long CalcSum(int[,] matrix, int row)
  {
      long sum = 0;
      for (int col = 0; col < matrix.GetLength(0); col++) 
          sum += matrix[row, col];
      if (row + 1 < matrix.GetLength(1)) 
          sum += CalcSum(matrix, row + 1);
      return sum;
  }
  
  Console.WriteLine(CalcSum(matrix, 0));
```

The complexity is __O(n*m)__, because for the given row in the method it loops for each column and recursively calls the same method with next row. So again for each row - each column.

***