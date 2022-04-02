using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using UnityEngine;

public class UDPServer : MonoBehaviour
{
    public const int PORT = 5000;

    private Socket _socket;
    private EndPoint _ep;

    private byte[] _buffer_recv;
    private ArraySegment<byte> _buffer_recv_segment;

    // Start is called before the first frame update
    void Start()
    {
        _buffer_recv = new byte[4096];
        _buffer_recv_segment = new ArraySegment<byte>(_buffer_recv);

        _ep = new IPEndPoint(IPAddress.Any, PORT);

        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
        _socket.Bind(_ep);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _ = Task.Run(async () =>
        {
            SocketReceiveMessageFromResult res;
            while (true)
            {
                res = await _socket.ReceiveMessageFromAsync(_buffer_recv_segment, SocketFlags.None, _ep);
                await SendTo(res.RemoteEndPoint, Encoding.UTF8.GetBytes("Hello back!"));
            }
        });
    }

    public async Task SendTo(EndPoint recipient, byte[] data)
    {
        var s = new ArraySegment<byte>(data);
        await _socket.SendToAsync(s, SocketFlags.None, recipient);
    }
}
