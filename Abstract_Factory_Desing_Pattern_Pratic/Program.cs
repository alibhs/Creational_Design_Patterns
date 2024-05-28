
//Computer computer = new Computer();

//CPU cPU = new CPU();
//computer.CPU = cPU;

//RAM ram = new RAM();
//computer.RAM = ram;

//VideoCard videoCard = new VideoCard();
//computer.VideoCard = videoCard;

ComputerCreator creator = new();
creator.CreateComputer(new AsusFactory());

class Computer
{
    public Computer(ICPU cPU, IRAM rAM, IVideoCard videoCard)
    {
        CPU=cPU;
        RAM=rAM;
        VideoCard=videoCard;
    }

    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }

}

#region AbstractProducts
interface ICPU { }
interface IRAM { }
interface IVideoCard { }
#endregion

#region ConcreteProducts
class CPU : ICPU {
    public CPU(string text) => Console.WriteLine(text);
}

class RAM : IRAM {
    public RAM(string text) => Console.WriteLine(text);
}

class VideoCard : IVideoCard {
    public VideoCard(string text) => Console.WriteLine(text);
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();

}
#endregion

#region Concrete Factories
class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU() => new CPU($"Asus CPU üretildi");
    

    public IRAM CreateRAM()
    => new RAM($"Asus Ram üretildi");

    public IVideoCard CreateVideoCard()
   => new VideoCard($"Asus Video Card üretildi");
}

class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU() => new CPU($"Toshiba CPU üretildi");


    public IRAM CreateRAM()
    => new RAM($"Toshiba Ram üretildi");

    public IVideoCard CreateVideoCard()
   => new VideoCard($"Toshiba Video Card üretildi");
}

#endregion

#region Creator
class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;

    public Computer CreateComputer(IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCPU();
        _ram = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new (_cpu, _ram, _videoCard);
    }
}
#endregion