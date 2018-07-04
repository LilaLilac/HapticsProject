using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using System.IO.Ports;
using UnityEngine;
using UniRx;

public class SerialController : MonoBehaviour
{

    public string portName;
    public int baurate;

    SerialPort serial;
    bool isLoop = true;

    void Start()
    {
        this.serial = new SerialPort(portName, baurate, Parity.None, 8, StopBits.One);

        try
        {
            this.serial.Open();
            Scheduler.ThreadPool.Schedule(() => ReadData()).AddTo(this);
        }
        catch (Exception e)
        {
            Debug.Log("can not open serial port");
        }
    }

    public void Write(string message)
    {
        try
        {
            serial.Write(message);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }




    public string ReadData()

    {
        while (this.isLoop)
        {
            string message = this.serial.ReadLine();
            return message;
        }
        return "0";
    }


    /*public void ReadData()
    {
        while (this.isLoop)
        {
            string message = this.serial.ReadLine();
            Debug.Log(message);
        }
    }*/


    void OnDestroy()
    {
        this.isLoop = false;
        this.serial.Close();
    }
}