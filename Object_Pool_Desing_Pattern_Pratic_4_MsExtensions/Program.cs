using Microsoft.Extensions.ObjectPool;

DefaultObjectPoolProvider provider = new();
ObjectPool<X> pool = provider.Create(new DefaultPooledObjectPolicy<X>());

var x1 = pool.Get();
x1.Count++;
x1.Write();
pool.Return(x1);

var x2 = pool.Get();
x2.Count++;
x2.Write();
pool.Return(x2);


var x3 = pool.Get();
x3.Count++;
x2.Write();
pool.Return(x3);


class X
{
    public int Count { get; set; }
    public void Write() => Console.WriteLine(Count);

    public X()
    => Console.WriteLine("X Üretim maaliyeti");

    ~X() => Console.WriteLine("X İmha maaliyeti");

}