local Protocols = require("zfoolua.Protocols")

function Protocols.SignalAttachment:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.SignalAttachment:new()
    local result0 = buffer:readByte()
    packet.client = result0
    local result1 = buffer:readInt()
    packet.signalId = result1
    local result2 = buffer:readInt()
    packet.taskExecutorHash = result2
    local result3 = buffer:readLong()
    packet.timestamp = result3
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.Message:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.Message:new()
    local result0 = buffer:readInt()
    packet.code = result0
    local result1 = buffer:readString()
    packet.message = result1
    local result2 = buffer:readByte()
    packet.module = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.Error:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.Error:new()
    local result0 = buffer:readInt()
    packet.errorCode = result0
    local result1 = buffer:readString()
    packet.errorMessage = result1
    local result2 = buffer:readInt()
    packet.module = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.Heartbeat:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.Heartbeat:new()
    
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.Ping:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.Ping:new()
    
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.Pong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.Pong:new()
    local result0 = buffer:readLong()
    packet.time = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.PairIntLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.PairIntLong:new()
    local result0 = buffer:readInt()
    packet.key = result0
    local result1 = buffer:readLong()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.PairLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.PairLong:new()
    local result0 = buffer:readLong()
    packet.key = result0
    local result1 = buffer:readLong()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.PairString:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.PairString:new()
    local result0 = buffer:readString()
    packet.key = result0
    local result1 = buffer:readString()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.PairLS:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.PairLS:new()
    local result0 = buffer:readLong()
    packet.key = result0
    local result1 = buffer:readString()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.TripleLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.TripleLong:new()
    local result0 = buffer:readLong()
    packet.left = result0
    local result1 = buffer:readLong()
    packet.middle = result1
    local result2 = buffer:readLong()
    packet.right = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.TripleString:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.TripleString:new()
    local result0 = buffer:readString()
    packet.left = result0
    local result1 = buffer:readString()
    packet.middle = result1
    local result2 = buffer:readString()
    packet.right = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.TripleLSS:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.TripleLSS:new()
    local result0 = buffer:readLong()
    packet.left = result0
    local result1 = buffer:readString()
    packet.middle = result1
    local result2 = buffer:readString()
    packet.right = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.UdpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.UdpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.UdpHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.UdpHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.TcpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.TcpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.TcpHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.TcpHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.WebsocketHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.WebsocketHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.WebsocketHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.WebsocketHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.JProtobufHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.JProtobufHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.JProtobufHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.JProtobufHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.JsonHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.JsonHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.JsonHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.JsonHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.HttpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.HttpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.HttpHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.HttpHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.WebSocketPacketRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.WebSocketPacketRequest:new()
    local result26 = buffer:readByte()
    packet.a = result26
    local result27 = buffer:readByte()
    packet.aa = result27
    local array28 = buffer:readByteArray()
    packet.aaa = array28
    local array29 = buffer:readByteArray()
    packet.aaaa = array29
    local result30 = buffer:readShort()
    packet.b = result30
    local result31 = buffer:readShort()
    packet.bb = result31
    local array32 = buffer:readShortArray()
    packet.bbb = array32
    local array33 = buffer:readShortArray()
    packet.bbbb = array33
    local result34 = buffer:readInt()
    packet.c = result34
    local result35 = buffer:readInt()
    packet.cc = result35
    local array36 = buffer:readIntArray()
    packet.ccc = array36
    local array37 = buffer:readIntArray()
    packet.cccc = array37
    local result38 = buffer:readLong()
    packet.d = result38
    local array39 = buffer:readLongArray()
    packet.dd = array39
    local result40 = buffer:readFloat()
    packet.e = result40
    local result41 = buffer:readFloat()
    packet.ee = result41
    local array42 = buffer:readFloatArray()
    packet.eee = array42
    local array43 = buffer:readFloatArray()
    packet.eeee = array43
    local result44 = buffer:readDouble()
    packet.f = result44
    local result45 = buffer:readDouble()
    packet.ff = result45
    local array46 = buffer:readDoubleArray()
    packet.fff = array46
    local array47 = buffer:readDoubleArray()
    packet.ffff = array47
    local result48 = buffer:readString()
    packet.jj = result48
    local array49 = buffer:readStringArray()
    packet.jjj = array49
    local result50 = buffer:readPacket(2071)
    packet.kk = result50
    local array51 = buffer:readPacketArray(2071)
    packet.kkk = array51
    local list52 = buffer:readIntArray()
    packet.l = list52
    local result53 = {}
    local size54 = buffer:readInt()
    if size54 > 0 then
        for index55 = 1, size54 do
            local result56 = {}
            local size57 = buffer:readInt()
            if size57 > 0 then
                for index58 = 1, size57 do
                    local list59 = buffer:readIntArray()
                    table.insert(result56, list59)
                end
            end
            table.insert(result53, result56)
        end
    end
    packet.ll = result53
    local result60 = {}
    local size61 = buffer:readInt()
    if size61 > 0 then
        for index62 = 1, size61 do
            local list63 = buffer:readPacketArray(2071)
            table.insert(result60, list63)
        end
    end
    packet.lll = result60
    local list64 = buffer:readStringArray()
    packet.llll = list64
    local result65 = {}
    local size66 = buffer:readInt()
    if size66 > 0 then
        for index67 = 1, size66 do
            local map68 = buffer:readIntStringMap()
            table.insert(result65, map68)
        end
    end
    packet.lllll = result65
    local map69 = buffer:readIntStringMap()
    packet.m = map69
    local map70 = buffer:readIntPacketMap(2071)
    packet.mm = map70
    local result71 = {}
    local size72 = buffer:readInt()
    if size72 > 0 then
        for index73 = 1, size72 do
            local result74 = buffer:readPacket(2071)
            local list75 = buffer:readIntArray()
            result71[result74] = list75
        end
    end
    packet.mmm = result71
    local result76 = {}
    local size77 = buffer:readInt()
    if size77 > 0 then
        for index78 = 1, size77 do
            local result79 = {}
            local size80 = buffer:readInt()
            if size80 > 0 then
                for index81 = 1, size80 do
                    local list82 = buffer:readPacketArray(2071)
                    table.insert(result79, list82)
                end
            end
            local result83 = {}
            local size84 = buffer:readInt()
            if size84 > 0 then
                for index85 = 1, size84 do
                    local result86 = {}
                    local size87 = buffer:readInt()
                    if size87 > 0 then
                        for index88 = 1, size87 do
                            local list89 = buffer:readIntArray()
                            table.insert(result86, list89)
                        end
                    end
                    table.insert(result83, result86)
                end
            end
            result76[result79] = result83
        end
    end
    packet.mmmm = result76
    local set90 = buffer:readIntArray()
    packet.s = set90
    local result91 = {}
    local size92 = buffer:readInt()
    if size92 > 0 then
        for index93 = 1, size92 do
            local result94 = {}
            local size95 = buffer:readInt()
            if size95 > 0 then
                for index96 = 1, size95 do
                    local list97 = buffer:readIntArray()
                    table.insert(result94, list97)
                end
            end
            table.insert(result91, result94)
        end
    end
    packet.ss = result91
    local result98 = {}
    local size99 = buffer:readInt()
    if size99 > 0 then
        for index100 = 1, size99 do
            local set101 = buffer:readPacketArray(2071)
            table.insert(result98, set101)
        end
    end
    packet.sss = result98
    local set102 = buffer:readStringArray()
    packet.ssss = set102
    local result103 = {}
    local size104 = buffer:readInt()
    if size104 > 0 then
        for index105 = 1, size104 do
            local map106 = buffer:readIntStringMap()
            table.insert(result103, map106)
        end
    end
    packet.sssss = result103
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.WebSocketObjectA:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.WebSocketObjectA:new()
    local result0 = buffer:readInt()
    packet.a = result0
    local result1 = buffer:readPacket(2072)
    packet.objectB = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.WebSocketObjectB:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.WebSocketObjectB:new()
    local result0 = buffer:readBoolean()
    packet.flag = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.GatewayToProviderRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.GatewayToProviderRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

function Protocols.GatewayToProviderResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Protocols.GatewayToProviderResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

