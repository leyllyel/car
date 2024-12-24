using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите номер автомобиля, который вам необходим: 1 - Автомобиль легковой, 2 - Автомобиль спорткар. ");
        int userChoice = Convert.ToInt32(Console.ReadLine());
        double maxSpeed = 250;
        double speed = 240;

        switch (userChoice)
        {
            case 1:
                Console.WriteLine("Легковой автомобиль!");
                Auto auto = new Auto();
                auto.UserDo();
                //auto.Ostatok(rashod100km, distance, dozapravil, tankVolume, ostatok, dozapravka, tankVolumeMax);
                break;
            case 2:
                Console.WriteLine("Спорткар!");
               
                SportCar sportCar = new SportCar(
                numberAuto: numberAuto,
                tankVolumeMax: tankVolumeMax,
                tankVolume: tankVolume,
                rashod100km: tankVolume,
                distance: distance,
                maxSpeed: 250,
                speed: 240);
                sportCar.UserDo();
                //sportCar.Ostatok(rashod100km, distance, dozapravil, tankVolume, ostatok, dozapravka, tankVolumeMax);
                
                break;
               
        }

        
    }
}
public class Auto
{
    protected int numberAuto;
    protected int tankVolumeMax;
    protected int tankVolume;
    protected double rashod100km;
    protected double distance;
    

    public Auto()
    {

    }
    
    protected double Doedet(double rashod100km, double distance)
    {
        double doedet = (distance / 100) * rashod100km;
        return doedet;
    }
    public virtual void UserDo()
    {
        Console.Write("Введите номер автомобиля: ");
       numberAuto = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите максимальный объем бака: ");
       tankVolumeMax = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите текущий объем бака: ");
       tankVolume = Convert.ToInt32(Console.ReadLine());
        if (tankVolume > tankVolumeMax)
        {
            Console.WriteLine("Текущий объем бака не может превышать максимальный.");
        }
        Console.Write("Расход топлива на 100 км: ");
         rashod100km = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите расстояние, которое необходимо проехать: ");
        distance = Convert.ToDouble(Console.ReadLine());
        Ostatok(rashod100km, distance);
    }
    public double Ostatok(double rashod100km, double distance, double dozapravil, double tankVolume, double ostatok, double dozapravka, double tankVolumeMax)
    {

        double result = Doedet(rashod100km, distance);
        if (result <= tankVolume)
        {
            Console.WriteLine("Автомобиль доедет!");
            ostatok = tankVolume - result;
            Console.WriteLine("В баке осталось: " + ostatok + " литров.");
            return ostatok;
        }
        else
        {
            bool notFalse = true;
            while (notFalse == true)
            {
                Console.WriteLine("Автомобиль не доедет, нужно дозаправиться!");
                dozapravka = result - tankVolume;
                Console.WriteLine("Необходимо дозаправить " + dozapravka + " литров топлива.");
                bool isTrue = true;
                while (isTrue == true)
                {
                    Console.WriteLine("Введите, сколько литров вы хотите дозаправить: ");
                    dozapravil = Convert.ToDouble(Console.ReadLine());


                    if (dozapravil + tankVolume > tankVolumeMax)
                    {
                        Console.WriteLine("Нельзя превысить максимальный объём бака");
                    }
                    else
                    {
                        Console.WriteLine("Вы успешно пополнили бак на " + dozapravil + " литров.");

                        double dozapravka2 = result - dozapravil;
                        if (dozapravka > 0)
                            Console.WriteLine("Необходимо пополнить еще на: " + dozapravka2);
                        result = dozapravka2;
                        dozapravka2 = 0;

                    }
                }
            }
        }
        return dozapravka;
    }
}
       

public class SportCar : Auto
{
    public double maxSpeed;
    public double speed;

    public SportCar(int numberAuto, int tankVolumeMax, int tankVolume, double rashod100km, double distance, double maxSpeed, double speed) : base(numberAuto,tankVolumeMax, tankVolume, rashod100km, distance) 
    {
        this.tankVolume = 25;
        this.rashod100km = 115;
        this.maxSpeed = maxSpeed;
        this.speed = speed;

    }
    public override void UserDo()
    {
        Console.Write("Введите номер автомобиля: ");
        int numberAuto = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите максимальный объем бака: ");
        int tankVolumeMax = Convert.ToInt32(Console.ReadLine());
        if (tankVolume > tankVolumeMax)
        {
            Console.WriteLine("Текущий объем бака не может превышать максимальный.");
        }
        Console.Write("Введите расстояние, которое необходимо проехать: ");
        double distance = Convert.ToDouble(Console.ReadLine());
        Ostatok(rashod100km,  distance,  dozapravil,  tankVolume,  ostatok,  dozapravka,  tankVolumeMax);
 
    
}

    public void speedControl(double speed)
    {
        if (speed > maxSpeed)
        {
            Console.WriteLine("Скорость превышена! Необходимо ехать медленнее!");
        }
        else
        {
            Console.WriteLine("Отличного пути!");
        }
    }

}

            
        
    


    

  
