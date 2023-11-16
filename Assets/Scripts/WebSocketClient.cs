using System.IO;
using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.Networking.PlayerConnection;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    private WebSocketSharp.WebSocket ws;

    private void Start()
    {
        // ����WebSocket����
        ws = new WebSocketSharp.WebSocket("ws://your-server-address");

        // ע���¼��������
        ws.OnOpen += OnWebSocketOpen;
        ws.OnMessage += OnWebSocketMessage;
        ws.OnError += OnWebSocketError;
        ws.OnClose += OnWebSocketClose;

        // ��������
        ws.Connect();
    }

    private void OnDestroy()
    {
        // �ر�WebSocket����
        if (ws != null && ws.IsAlive)
        {
            ws.Close();
        }
    }

    private void OnWebSocketOpen(object sender, System.EventArgs e)
    {
        Debug.Log("WebSocket connection opened.");

        // �����ӳɹ�����Է�����Ϣ��������
        ws.Send("Hello server!");
    }

    private void OnWebSocketMessage(object sender, WebSocketSharp.MessageEventArgs e)
    {
        Debug.Log("Received message from server: " + e.Data);

        // ����ӷ��������յ���Ϣ
        // ������Ϣ����ִ����Ӧ���߼�

        // �������յ���JSON����
        MyDataObject cardData = JsonUtility.FromJson<MyDataObject>(e.Data);

        // ʹ�ý�����Ŀ�������ִ����ز���
        string name = cardData.name;
        string type = cardData.type;
        float attack = float.Parse(cardData.attack);
        float defense = float.Parse(cardData.defense);
        int attackRange = int.Parse(cardData.attack_range);
        int moveSpeed = int.Parse(cardData.move_speed);
        int cost = int.Parse(cardData.cost);
        string description = cardData.description;

        // ִ�и��ݿ�������ִ�е��߼�
        // ...

    }

    private void OnWebSocketError(object sender, WebSocketSharp.ErrorEventArgs e)
    {
        Debug.LogError("WebSocket error: " + e.Message);
    }

    private void OnWebSocketClose(object sender, CloseEventArgs e)
    {
        Debug.Log("WebSocket connection closed with code: " + e.Code);
    }

    [System.Serializable]
    public class MyDataObject
    {
        public string name;
        public string type;
        public string attack;
        public string defense;
        public string attack_range;
        public string move_speed;
        public string cost;
        public string description;
    }
}