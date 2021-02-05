using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WebSocketSharp;

namespace ProgramChat
{
    public class WebsocketConnection : MonoBehaviour
    {
        private WebSocket websocket;
        
        //string ip = "127.0.0.1";
        //string port = "25500";
        //I don't know how to resive port form sever. 
        public Text ChatTextMy, ChatTextTheir;
        public GameObject ChatInterface, LoginInterface, InputPortText, InputIPText, InputTextText;
        string inputIP, inputPort, inputText, chatTextMy, chatTextTheir;

        void Start()
        {
            websocket = new WebSocket("ws://127.0.0.1:25500/");
            //websocket = new WebSocket("ws://"+ ip + ":" + port + "/");
            websocket.OnMessage += OnMessage;
            //websocket.Connect();
        }

        void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.Return))
            {
                websocket.Send("Number : " + Random.Range(0, 99999));
            }
            */


        }

        public void OnDestroy()
        {
            if (websocket != null)
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            //Debug.Log("Message from server : " + messageEventArgs.Data);
            chatTextTheir = messageEventArgs.Data;
            chatTextMy = messageEventArgs.Data;

        }

        
        public void IPPortInput()
        {
            inputIP = InputIPText.GetComponent<Text>().text;
            inputPort = InputPortText.GetComponent<Text>().text;
        }
        public void EnterIPPortBTCommand()
        {
            /*
            if (inputIP == ip && inputPort == port)
            {
                websocket.Connect();
                LoginInterface.SetActive(false);
                ChatInterface.SetActive(true);
            }
            */
            websocket.Connect();
            LoginInterface.SetActive(false);
            ChatInterface.SetActive(true);
        }
        public void SendBTCommand()
        {
            inputText = InputTextText.GetComponent<Text>().text;
            websocket.Send(inputText);
        }
        public void Chat()
        {
            ChatTextMy.text = chatTextMy;
            ChatTextTheir.text = chatTextTheir;
            transform.Translate(Vector2.up);
        }
    }
}

