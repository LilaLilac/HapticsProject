﻿
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using System.IO.Ports;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using System.IO;

public class SerialController : MonoBehaviour
{

    public string portName;
    public int baudrate;

    SerialPort serial;
    bool isLoop = true;
    void Start()
    {
        this.serial = new SerialPort(portName, baudrate, Parity.None, 8, StopBits.One);

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
    public void ReadData()
    {
        string message = "0";
        while (this.isLoop)
        {
            message = this.serial.ReadLine();
            Debug.Log(message);
        }
        Debug.Log(message);
    }
    
    

    void OnDestroy()
    {
        this.isLoop = false;
        this.serial.Close();
    }
}