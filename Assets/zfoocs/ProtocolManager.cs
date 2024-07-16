using System;
using System.Collections.Generic;

namespace zfoocs
{
    public class ProtocolManager
    {
        public static readonly short MAX_PROTOCOL_NUM = short.MaxValue;


        private static readonly IProtocolRegistration[] protocols = new IProtocolRegistration[MAX_PROTOCOL_NUM];
        private static readonly Dictionary<Type, short> protocolIdMap = new Dictionary<Type, short>();
        private static bool initialized = false;


        public static void InitProtocol()
        {
            if (initialized)
            {
                return;
            }
            initialized = true;
            protocols[0] = new SignalAttachmentRegistration();
            protocolIdMap[typeof(SignalAttachment)] = 0;
            protocols[100] = new MessageRegistration();
            protocolIdMap[typeof(Message)] = 100;
            protocols[101] = new ErrorRegistration();
            protocolIdMap[typeof(Error)] = 101;
            protocols[102] = new HeartbeatRegistration();
            protocolIdMap[typeof(Heartbeat)] = 102;
            protocols[103] = new PingRegistration();
            protocolIdMap[typeof(Ping)] = 103;
            protocols[104] = new PongRegistration();
            protocolIdMap[typeof(Pong)] = 104;
            protocols[110] = new PairIntLongRegistration();
            protocolIdMap[typeof(PairIntLong)] = 110;
            protocols[111] = new PairLongRegistration();
            protocolIdMap[typeof(PairLong)] = 111;
            protocols[112] = new PairStringRegistration();
            protocolIdMap[typeof(PairString)] = 112;
            protocols[113] = new PairLSRegistration();
            protocolIdMap[typeof(PairLS)] = 113;
            protocols[114] = new TripleLongRegistration();
            protocolIdMap[typeof(TripleLong)] = 114;
            protocols[115] = new TripleStringRegistration();
            protocolIdMap[typeof(TripleString)] = 115;
            protocols[116] = new TripleLSSRegistration();
            protocolIdMap[typeof(TripleLSS)] = 116;
            protocols[1200] = new UdpHelloRequestRegistration();
            protocolIdMap[typeof(UdpHelloRequest)] = 1200;
            protocols[1201] = new UdpHelloResponseRegistration();
            protocolIdMap[typeof(UdpHelloResponse)] = 1201;
            protocols[1300] = new TcpHelloRequestRegistration();
            protocolIdMap[typeof(TcpHelloRequest)] = 1300;
            protocols[1301] = new TcpHelloResponseRegistration();
            protocolIdMap[typeof(TcpHelloResponse)] = 1301;
            protocols[1400] = new WebsocketHelloRequestRegistration();
            protocolIdMap[typeof(WebsocketHelloRequest)] = 1400;
            protocols[1401] = new WebsocketHelloResponseRegistration();
            protocolIdMap[typeof(WebsocketHelloResponse)] = 1401;
            protocols[1600] = new JsonHelloRequestRegistration();
            protocolIdMap[typeof(JsonHelloRequest)] = 1600;
            protocols[1601] = new JsonHelloResponseRegistration();
            protocolIdMap[typeof(JsonHelloResponse)] = 1601;
            protocols[1700] = new HttpHelloRequestRegistration();
            protocolIdMap[typeof(HttpHelloRequest)] = 1700;
            protocols[1701] = new HttpHelloResponseRegistration();
            protocolIdMap[typeof(HttpHelloResponse)] = 1701;
            protocols[2070] = new WebSocketPacketRequestRegistration();
            protocolIdMap[typeof(WebSocketPacketRequest)] = 2070;
            protocols[2071] = new WebSocketObjectARegistration();
            protocolIdMap[typeof(WebSocketObjectA)] = 2071;
            protocols[2072] = new WebSocketObjectBRegistration();
            protocolIdMap[typeof(WebSocketObjectB)] = 2072;
            protocols[5000] = new GatewayToProviderRequestRegistration();
            protocolIdMap[typeof(GatewayToProviderRequest)] = 5000;
            protocols[5001] = new GatewayToProviderResponseRegistration();
            protocolIdMap[typeof(GatewayToProviderResponse)] = 5001;
        }

        public static short GetProtocolId(Type type)
        {
            return protocolIdMap[type];
        }

        public static IProtocolRegistration GetProtocol(short protocolId)
        {
            var protocol = protocols[protocolId];
            if (protocol == null)
            {
                throw new Exception("[protocolId:" + protocolId + "] not exist");
            }
            return protocol;
        }

        public static void Write(ByteBuffer buffer, object packet)
        {
            var protocolId = protocolIdMap[packet.GetType()];
            // write protocol id to buffer
            buffer.WriteShort(protocolId);
            // write packet
            GetProtocol(protocolId).Write(buffer, packet);
        }

        public static object Read(ByteBuffer buffer)
        {
            var protocolId = buffer.ReadShort();
            return GetProtocol(protocolId).Read(buffer);
        }
    }
}