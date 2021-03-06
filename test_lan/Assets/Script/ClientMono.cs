﻿using UnityEngine;
using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using MyNet;

public class ClientMono : MonoBehaviour {

    public int ServerPort = 13131;
    public string ServerIp = "localhost";

    MyClientSocket MyClient = null;

	// Use this for initialization
	void Start () {
        MyClient = new MyClientSocket();
	}
	// Update is called once per frame
	void Update () {

        MyClient.Tick();
	}
    void OnDestory()
    {
        MyClient.Destroy();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 150, 30, 50, 20), "连接"))
        {
            MyClient.Start(ServerIp, ServerPort, OnReceiveMsg);
        }
        if (GUI.Button(new Rect(Screen.width - 150, 130, 50, 20), "发送消息"))
        {
            MyClient.SendMessage("你好！");
        }
        if (GUI.Button(new Rect(Screen.width - 150, 170, 50, 20), "断开连接"))
        {
            MyClient.SimulateDisconnect();
        }
        if (GUI.Button(new Rect(Screen.width - 150, 230, 50, 20), "重连"))
        {
            MyClient.Reconn();
        }
    }
    void OnReceiveMsg(int id, INetMessage msg)
    { 
    
    }
}
