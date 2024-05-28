#region 1.Yöntem
Example ex = Example.GetInstance;
Example ex2 = Example.GetInstance;
Example ex3 = Example.GetInstance;


class Example
{
    private Example() //Const private yapılarak new ile çağırmayı kısıtladık.
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu");
    }

    static Example()
    {
        _example = new Example(); //2. Yöntem için static const oluşturarak burada nesne oluşturduk ve kullandık. | Her şeyden önce 1 kez üretilir.
    }

    static Example _example;
    public static Example GetInstance
    {
        get
        {
            #region 1.Yöntem
            //if (_example == null) //_example kontrolu yapılarak daha önce oluşturulmuşsa new ile tekrar oluşturulmama kontrolunu sağlıyoruz
            //    _example = new Example();
            //return _example;
            #endregion
            #region 2.Yöntem
            return _example;
            #endregion

        }
    }
}
#endregion

