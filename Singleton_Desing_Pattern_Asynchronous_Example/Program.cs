//Asenkron süreçlerde her ne kadar singleton tasarımı yapsak da birden fazla instance üretimi olabilir.
//Bu durumda GetInstance bir asenkron süreç için locklanır. GetInstance birden fazla aynı anda tetiklenemeyecek.
//Static ctor kullanırsak lock mekanizmasına gerek kalmaz


Example.GetInstance();

var task1 = Task.Run(() =>
{
    Example.GetInstance();
});

var task2 = Task.Run(() =>
{
    Example.GetInstance();
});

await Task.WhenAll(task1, task2);


var task3 = Task.Run(() =>
{
    Example.GetInstance();
});

var task4 = Task.Run(() =>
{
    Example.GetInstance();
});

await Task.WhenAll(task3, task4);


class Example
{
    Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");

    }

    static Example()
    {
        _example = new Example();
    }

    static Example _example;
    //static object _obj = new object();
    static public Example GetInstance()
    {
        //lock (_obj)
        //{
        //    if (_example == null)
        //        _example = new Example();
        //}
       
        return _example;
    }
    

}