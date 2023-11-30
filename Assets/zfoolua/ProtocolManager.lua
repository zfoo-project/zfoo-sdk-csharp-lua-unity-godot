local protocols = {}

ProtocolManager = {}

-- table扩展方法，map的大小
function table.mapSize(map)
    local size = 0
    for _,_ in pairs(map) do
        size = size + 1
    end
    return size
end

function ProtocolManager.getProtocol(protocolId)
    local protocol = protocols[protocolId]
    if protocol == nil then
        error("[protocolId:" + protocolId + "]协议不存在")
    end
    return protocol
end

function ProtocolManager.write(buffer, packet)
    local protocolId = packet:protocolId()
    -- 写入协议号
    buffer:writeShort(protocolId)
    -- 写入包体
    ProtocolManager.getProtocol(protocolId):write(buffer, packet)
end

function ProtocolManager.read(buffer)
    local protocolId = buffer:readShort()
    return ProtocolManager.getProtocol(protocolId):read(buffer)
end

function initProtocol()
    local SignalAttachment = require("zfoolua.attachment.SignalAttachment")
    local Message = require("zfoolua.common.Message")
    local Error = require("zfoolua.common.Error")
    local Heartbeat = require("zfoolua.common.Heartbeat")
    local Ping = require("zfoolua.common.Ping")
    local Pong = require("zfoolua.common.Pong")
    local PairIntLong = require("zfoolua.common.PairIntLong")
    local PairLong = require("zfoolua.common.PairLong")
    local PairString = require("zfoolua.common.PairString")
    local PairLS = require("zfoolua.common.PairLS")
    local TripleLong = require("zfoolua.common.TripleLong")
    local TripleString = require("zfoolua.common.TripleString")
    local TripleLSS = require("zfoolua.common.TripleLSS")
    local UdpHelloRequest = require("zfoolua.udp.UdpHelloRequest")
    local UdpHelloResponse = require("zfoolua.udp.UdpHelloResponse")
    local TcpHelloRequest = require("zfoolua.tcp.TcpHelloRequest")
    local TcpHelloResponse = require("zfoolua.tcp.TcpHelloResponse")
    local WebsocketHelloRequest = require("zfoolua.websocket.WebsocketHelloRequest")
    local WebsocketHelloResponse = require("zfoolua.websocket.WebsocketHelloResponse")
    local JProtobufHelloRequest = require("zfoolua.jprotobuf.JProtobufHelloRequest")
    local JProtobufHelloResponse = require("zfoolua.jprotobuf.JProtobufHelloResponse")
    local JsonHelloRequest = require("zfoolua.json.JsonHelloRequest")
    local JsonHelloResponse = require("zfoolua.json.JsonHelloResponse")
    local HttpHelloRequest = require("zfoolua.http.HttpHelloRequest")
    local HttpHelloResponse = require("zfoolua.http.HttpHelloResponse")
    local WebSocketPacketRequest = require("zfoolua.websocket.WebSocketPacketRequest")
    local WebSocketObjectA = require("zfoolua.websocket.WebSocketObjectA")
    local WebSocketObjectB = require("zfoolua.websocket.WebSocketObjectB")
    local GatewayToProviderRequest = require("zfoolua.gateway.GatewayToProviderRequest")
    local GatewayToProviderResponse = require("zfoolua.gateway.GatewayToProviderResponse")
    protocols[0] = SignalAttachment
    protocols[100] = Message
    protocols[101] = Error
    protocols[102] = Heartbeat
    protocols[103] = Ping
    protocols[104] = Pong
    protocols[110] = PairIntLong
    protocols[111] = PairLong
    protocols[112] = PairString
    protocols[113] = PairLS
    protocols[114] = TripleLong
    protocols[115] = TripleString
    protocols[116] = TripleLSS
    protocols[1200] = UdpHelloRequest
    protocols[1201] = UdpHelloResponse
    protocols[1300] = TcpHelloRequest
    protocols[1301] = TcpHelloResponse
    protocols[1400] = WebsocketHelloRequest
    protocols[1401] = WebsocketHelloResponse
    protocols[1500] = JProtobufHelloRequest
    protocols[1501] = JProtobufHelloResponse
    protocols[1600] = JsonHelloRequest
    protocols[1601] = JsonHelloResponse
    protocols[1700] = HttpHelloRequest
    protocols[1701] = HttpHelloResponse
    protocols[2070] = WebSocketPacketRequest
    protocols[2071] = WebSocketObjectA
    protocols[2072] = WebSocketObjectB
    protocols[5000] = GatewayToProviderRequest
    protocols[5001] = GatewayToProviderResponse
end

ProtocolManager.initProtocol = initProtocol
return ProtocolManager
