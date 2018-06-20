using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using System.IO.Ports;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

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

    public string ReadData()
    {
        string message = "0";
        while (this.isLoop)
        {
            message = this.serial.ReadLine();
            return message;
        }
        return message;
    }

    void OnDestroy()
    {
        this.isLoop = false;
        this.serial.Close();
    }
}