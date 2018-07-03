using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;

public class a : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM7", 2400);

    public Text T_rcv;

    private string lastrcvd = "";

    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        byte rcv;
        char tmp;
        try
        {
            rcv = (byte)sp.ReadByte();
            Debug.Log(rcv);
            if (rcv != 255)
            {
                tmp = (char)rcv;
                lastrcvd = lastrcvd + tmp.ToString();
                T_rcv.text = lastrcvd;
            }
        }
        catch (System.Exception)
        {
        }
    }
}