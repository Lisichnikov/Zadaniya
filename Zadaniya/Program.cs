﻿using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Timers;


// Первое задание
internal class Program
{
    public static int counter = 0;
    private static void Main(string[] args)
    {
        Console.WriteLine("Задание 1");
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        timer.Elapsed += Start;
        timer.Start();
        bool flag = true;
        while (flag)
        {
            if (counter == 10)
            {
                flag = false;
                timer.Stop();
            }
        }
        AllInfoProcess();
        Console.ReadKey();

    }
    private static void Start(Object source, ElapsedEventArgs e)
    {
        Process myProc = null;

        try
        {
            myProc = Process.Start("Notepad.exe");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        counter++;
    }
    static void AllInfoProcess()
    {
        var myProcess = from proc in Process.GetProcesses(".")
                        orderby proc.Id
                        select proc;
        Console.WriteLine("\n*** Текущие процессы ***\n");
        foreach (var p in myProcess)
            // Нет доступа
            Console.WriteLine("-> PID: {0}\tStartTime: {1}\tName: {2}", p.Id, p.StartTime, p.ProcessName);
    }
}

// Второе задание
internal class Program1
{
    private static void Main(string[] args)
    {
        var myProcess = from proc in Process.GetProcesses(".")
                        orderby proc.Id
                        select proc;
        Console.WriteLine("\n*** Текущие процессы ***\n");
        foreach (var p in myProcess)
        {
            Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
        }
        int id = 0;
        foreach (var p in myProcess)
        {
            if (id < 3)
            {
                Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
                id++;
            }
        }
    }
}


// Третье задание
internal class Program2
{
    private static void Main(string[] args)
    {
        var myProcess = from proc in Process.GetProcesses(".")
                        orderby proc.BasePriority
                        select proc;
        Console.WriteLine("\n*** Текущие процессы ***\n");
        foreach (var p in myProcess)
        {
            Console.WriteLine("-> PID: {0}\tName: {1}", p.Id, p.ProcessName);
        }
    }
}