namespace FibonacciFast
{
    public class Matrix
    {
        public long[,] Table { get; set; }

        const int MOD = 1000000007;

        public Matrix(long a, long b, long c, long d)
        {
            this.Table = new long[2, 2];

            this.Table[0, 0] = a;
            this.Table[0, 1] = b;
            this.Table[1, 0] = c;
            this.Table[1, 1] = d;
        }

        public Matrix(Matrix A, Matrix B)
        {
            this.Table = new long[2, 2];

            this.Table[0, 0] = A.Table[0, 0] * B.Table[0, 0]
                        + A.Table[0, 1] * B.Table[1, 0];
            this.Table[0, 1] = A.Table[0, 0] * B.Table[0, 1]
                        + A.Table[0, 1] * B.Table[1, 1];
            this.Table[1, 0] = A.Table[1, 0] * B.Table[0, 0]
                        + A.Table[1, 1] * B.Table[1, 0];
            this.Table[1, 1] = A.Table[1, 0] * B.Table[0, 1]
                        + A.Table[1, 1] * B.Table[1, 1];

            this.Table[0, 0] %= MOD;
            this.Table[0, 1] %= MOD;
            this.Table[1, 0] %= MOD;
            this.Table[1, 1] %= MOD;
        }
    }
}
