local protocols = {}

local ProtocolManager = {}

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
    local Protocols = require("zfoolua.Protocols")
    local ProtocolBase = require("zfoolua.ProtocolBase")
    local ProtocolWriter = require("zfoolua.ProtocolWriter")
    local ProtocolReader = require("zfoolua.ProtocolReader")
    protocols[0] = Protocols.SignalAttachment
    protocols[100] = Protocols.Message
    protocols[101] = Protocols.Error
    protocols[102] = Protocols.Heartbeat
    protocols[103] = Protocols.Ping
    protocols[104] = Protocols.Pong
    protocols[110] = Protocols.PairIntLong
    protocols[111] = Protocols.PairLong
    protocols[112] = Protocols.PairString
    protocols[113] = Protocols.PairLS
    protocols[114] = Protocols.TripleLong
    protocols[115] = Protocols.TripleString
    protocols[116] = Protocols.TripleLSS
    protocols[1200] = Protocols.UdpHelloRequest
    protocols[1201] = Protocols.UdpHelloResponse
    protocols[1300] = Protocols.TcpHelloRequest
    protocols[1301] = Protocols.TcpHelloResponse
    protocols[1400] = Protocols.WebsocketHelloRequest
    protocols[1401] = Protocols.WebsocketHelloResponse
    protocols[1500] = Protocols.JProtobufHelloRequest
    protocols[1501] = Protocols.JProtobufHelloResponse
    protocols[1600] = Protocols.JsonHelloRequest
    protocols[1601] = Protocols.JsonHelloResponse
    protocols[1700] = Protocols.HttpHelloRequest
    protocols[1701] = Protocols.HttpHelloResponse
    protocols[2070] = Protocols.WebSocketPacketRequest
    protocols[2071] = Protocols.WebSocketObjectA
    protocols[2072] = Protocols.WebSocketObjectB
    protocols[5000] = Protocols.GatewayToProviderRequest
    protocols[5001] = Protocols.GatewayToProviderResponse
end

ProtocolManager.initProtocol = initProtocol
return ProtocolManager
