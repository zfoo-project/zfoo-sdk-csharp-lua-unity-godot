local Protocols = require("zfoolua.Protocols")

function Protocols.SignalAttachment:protocolId()
    return 0
end

function Protocols.SignalAttachment:protocolName()
    return Protocols.SignalAttachment
end

function Protocols.SignalAttachment:__tostring()
    local jsonTemplate = "{signalId:%s, taskExecutorHash:%s, client:%s, timestamp:%s}"
    local result = string.format(jsonTemplate, self.signalId, self.taskExecutorHash, self.client, self.timestamp)
    return result
end

function Protocols.Message:protocolId()
    return 100
end

function Protocols.Message:protocolName()
    return Protocols.Message
end

function Protocols.Message:__tostring()
    local jsonTemplate = "{module:%s, code:%s, message:%s}"
    local result = string.format(jsonTemplate, self.module, self.code, self.message)
    return result
end

function Protocols.Error:protocolId()
    return 101
end

function Protocols.Error:protocolName()
    return Protocols.Error
end

function Protocols.Error:__tostring()
    local jsonTemplate = "{module:%s, errorCode:%s, errorMessage:%s}"
    local result = string.format(jsonTemplate, self.module, self.errorCode, self.errorMessage)
    return result
end

function Protocols.Heartbeat:protocolId()
    return 102
end

function Protocols.Heartbeat:protocolName()
    return Protocols.Heartbeat
end

function Protocols.Heartbeat:__tostring()
    local jsonTemplate = "{}"
    local result = string.format(jsonTemplate, {})
    return result
end

function Protocols.Ping:protocolId()
    return 103
end

function Protocols.Ping:protocolName()
    return Protocols.Ping
end

function Protocols.Ping:__tostring()
    local jsonTemplate = "{}"
    local result = string.format(jsonTemplate, {})
    return result
end

function Protocols.Pong:protocolId()
    return 104
end

function Protocols.Pong:protocolName()
    return Protocols.Pong
end

function Protocols.Pong:__tostring()
    local jsonTemplate = "{time:%s}"
    local result = string.format(jsonTemplate, self.time)
    return result
end

function Protocols.PairIntLong:protocolId()
    return 110
end

function Protocols.PairIntLong:protocolName()
    return Protocols.PairIntLong
end

function Protocols.PairIntLong:__tostring()
    local jsonTemplate = "{key:%s, value:%s}"
    local result = string.format(jsonTemplate, self.key, self.value)
    return result
end

function Protocols.PairLong:protocolId()
    return 111
end

function Protocols.PairLong:protocolName()
    return Protocols.PairLong
end

function Protocols.PairLong:__tostring()
    local jsonTemplate = "{key:%s, value:%s}"
    local result = string.format(jsonTemplate, self.key, self.value)
    return result
end

function Protocols.PairString:protocolId()
    return 112
end

function Protocols.PairString:protocolName()
    return Protocols.PairString
end

function Protocols.PairString:__tostring()
    local jsonTemplate = "{key:%s, value:%s}"
    local result = string.format(jsonTemplate, self.key, self.value)
    return result
end

function Protocols.PairLS:protocolId()
    return 113
end

function Protocols.PairLS:protocolName()
    return Protocols.PairLS
end

function Protocols.PairLS:__tostring()
    local jsonTemplate = "{key:%s, value:%s}"
    local result = string.format(jsonTemplate, self.key, self.value)
    return result
end

function Protocols.TripleLong:protocolId()
    return 114
end

function Protocols.TripleLong:protocolName()
    return Protocols.TripleLong
end

function Protocols.TripleLong:__tostring()
    local jsonTemplate = "{left:%s, middle:%s, right:%s}"
    local result = string.format(jsonTemplate, self.left, self.middle, self.right)
    return result
end

function Protocols.TripleString:protocolId()
    return 115
end

function Protocols.TripleString:protocolName()
    return Protocols.TripleString
end

function Protocols.TripleString:__tostring()
    local jsonTemplate = "{left:%s, middle:%s, right:%s}"
    local result = string.format(jsonTemplate, self.left, self.middle, self.right)
    return result
end

function Protocols.TripleLSS:protocolId()
    return 116
end

function Protocols.TripleLSS:protocolName()
    return Protocols.TripleLSS
end

function Protocols.TripleLSS:__tostring()
    local jsonTemplate = "{left:%s, middle:%s, right:%s}"
    local result = string.format(jsonTemplate, self.left, self.middle, self.right)
    return result
end

function Protocols.UdpHelloRequest:protocolId()
    return 1200
end

function Protocols.UdpHelloRequest:protocolName()
    return Protocols.UdpHelloRequest
end

function Protocols.UdpHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.UdpHelloResponse:protocolId()
    return 1201
end

function Protocols.UdpHelloResponse:protocolName()
    return Protocols.UdpHelloResponse
end

function Protocols.UdpHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.TcpHelloRequest:protocolId()
    return 1300
end

function Protocols.TcpHelloRequest:protocolName()
    return Protocols.TcpHelloRequest
end

function Protocols.TcpHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.TcpHelloResponse:protocolId()
    return 1301
end

function Protocols.TcpHelloResponse:protocolName()
    return Protocols.TcpHelloResponse
end

function Protocols.TcpHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.WebsocketHelloRequest:protocolId()
    return 1400
end

function Protocols.WebsocketHelloRequest:protocolName()
    return Protocols.WebsocketHelloRequest
end

function Protocols.WebsocketHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.WebsocketHelloResponse:protocolId()
    return 1401
end

function Protocols.WebsocketHelloResponse:protocolName()
    return Protocols.WebsocketHelloResponse
end

function Protocols.WebsocketHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.JProtobufHelloRequest:protocolId()
    return 1500
end

function Protocols.JProtobufHelloRequest:protocolName()
    return Protocols.JProtobufHelloRequest
end

function Protocols.JProtobufHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.JProtobufHelloResponse:protocolId()
    return 1501
end

function Protocols.JProtobufHelloResponse:protocolName()
    return Protocols.JProtobufHelloResponse
end

function Protocols.JProtobufHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.JsonHelloRequest:protocolId()
    return 1600
end

function Protocols.JsonHelloRequest:protocolName()
    return Protocols.JsonHelloRequest
end

function Protocols.JsonHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.JsonHelloResponse:protocolId()
    return 1601
end

function Protocols.JsonHelloResponse:protocolName()
    return Protocols.JsonHelloResponse
end

function Protocols.JsonHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.HttpHelloRequest:protocolId()
    return 1700
end

function Protocols.HttpHelloRequest:protocolName()
    return Protocols.HttpHelloRequest
end

function Protocols.HttpHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.HttpHelloResponse:protocolId()
    return 1701
end

function Protocols.HttpHelloResponse:protocolName()
    return Protocols.HttpHelloResponse
end

function Protocols.HttpHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.WebSocketPacketRequest:protocolId()
    return 2070
end

function Protocols.WebSocketPacketRequest:protocolName()
    return Protocols.WebSocketPacketRequest
end

function Protocols.WebSocketPacketRequest:__tostring()
    local jsonTemplate = "{a:%s, aa:%s, aaa:%s, aaaa:%s, b:%s, bb:%s, bbb:%s, bbbb:%s, c:%s, cc:%s, ccc:%s, cccc:%s, d:%s, dd:%s, e:%s, ee:%s, eee:%s, eeee:%s, f:%s, ff:%s, fff:%s, ffff:%s, jj:%s, jjj:%s, kk:%s, kkk:%s, l:%s, ll:%s, lll:%s, llll:%s, lllll:%s, m:%s, mm:%s, mmm:%s, mmmm:%s, s:%s, ss:%s, sss:%s, ssss:%s, sssss:%s}"
    local result = string.format(jsonTemplate, self.a, self.aa, self.aaa, self.aaaa, self.b, self.bb, self.bbb, self.bbbb, self.c, self.cc, self.ccc, self.cccc, self.d, self.dd, self.e, self.ee, self.eee, self.eeee, self.f, self.ff, self.fff, self.ffff, self.jj, self.jjj, self.kk, self.kkk, self.l, self.ll, self.lll, self.llll, self.lllll, self.m, self.mm, self.mmm, self.mmmm, self.s, self.ss, self.sss, self.ssss, self.sssss)
    return result
end

function Protocols.WebSocketObjectA:protocolId()
    return 2071
end

function Protocols.WebSocketObjectA:protocolName()
    return Protocols.WebSocketObjectA
end

function Protocols.WebSocketObjectA:__tostring()
    local jsonTemplate = "{a:%s, objectB:%s}"
    local result = string.format(jsonTemplate, self.a, self.objectB)
    return result
end

function Protocols.WebSocketObjectB:protocolId()
    return 2072
end

function Protocols.WebSocketObjectB:protocolName()
    return Protocols.WebSocketObjectB
end

function Protocols.WebSocketObjectB:__tostring()
    local jsonTemplate = "{flag:%s}"
    local result = string.format(jsonTemplate, self.flag)
    return result
end

function Protocols.GatewayToProviderRequest:protocolId()
    return 5000
end

function Protocols.GatewayToProviderRequest:protocolName()
    return Protocols.GatewayToProviderRequest
end

function Protocols.GatewayToProviderRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function Protocols.GatewayToProviderResponse:protocolId()
    return 5001
end

function Protocols.GatewayToProviderResponse:protocolName()
    return Protocols.GatewayToProviderResponse
end

function Protocols.GatewayToProviderResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

