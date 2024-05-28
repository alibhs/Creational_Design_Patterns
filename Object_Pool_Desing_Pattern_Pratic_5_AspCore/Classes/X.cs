namespace Object_Pool_Desing_Pattern_Pratic_5_AspCore.Classes
{
    public class X
    {
        public int Count { get; set; }
        public void Write() => Console.WriteLine(Count);

        public X()
        => Console.WriteLine("X Üretim maaliyeti");

        ~X() => Console.WriteLine("X İmha maaliyeti");

    }
}
