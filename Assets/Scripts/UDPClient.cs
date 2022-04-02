using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Text;
using UnityEngine;

public class UDPClient : MonoBehaviour
{
    public const int PORT = 5000;

    private Socket _socket;
    private EndPoint _ep;

    private byte[] _buffer_recv;
    private ArraySegment<byte> _buffer_recv_segment;

    [SerializeField] IPAddress address;
    [SerializeField] int port;

    // Start is called before the first frame update
    void Start()
    {
        _buffer_recv = new byte[4096];
        _buffer_recv_segment = new ArraySegment<byte>(_buffer_recv);

        _ep = new IPEndPoint(address, port);

        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
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
            }
        });
    }

    public async Task Send(byte[] data)
    {
        var s = new ArraySegment<byte>(data);
        await _socket.SendToAsync(s, SocketFlags.None, _ep);
    }
}
