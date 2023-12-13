local Protocols = require("zfoolua.Protocols")

function Protocols.SignalAttachment:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeByte(packet.client)
    buffer:writeInt(packet.signalId)
    buffer:writeInt(packet.taskExecutorHash)
    buffer:writeLong(packet.timestamp)
end

function Protocols.Message:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.code)
    buffer:writeString(packet.message)
    buffer:writeByte(packet.module)
end

function Protocols.Error:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.errorCode)
    buffer:writeString(packet.errorMessage)
    buffer:writeInt(packet.module)
end

function Protocols.Heartbeat:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
end

function Protocols.Ping:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
end

function Protocols.Pong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.time)
end

function Protocols.PairIntLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.key)
    buffer:writeLong(packet.value)
end

function Protocols.PairLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.key)
    buffer:writeLong(packet.value)
end

function Protocols.PairString:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.key)
    buffer:writeString(packet.value)
end

function Protocols.PairLS:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.key)
    buffer:writeString(packet.value)
end

function Protocols.TripleLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.left)
    buffer:writeLong(packet.middle)
    buffer:writeLong(packet.right)
end

function Protocols.TripleString:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.left)
    buffer:writeString(packet.middle)
    buffer:writeString(packet.right)
end

function Protocols.TripleLSS:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.left)
    buffer:writeString(packet.middle)
    buffer:writeString(packet.right)
end

function Protocols.UdpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.UdpHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.TcpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.TcpHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.WebsocketHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.WebsocketHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.JProtobufHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.JProtobufHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.JsonHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.JsonHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.HttpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.HttpHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.WebSocketPacketRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeByte(packet.a)
    buffer:writeByte(packet.aa)
    buffer:writeByteArray(packet.aaa)
    buffer:writeByteArray(packet.aaaa)
    buffer:writeShort(packet.b)
    buffer:writeShort(packet.bb)
    buffer:writeShortArray(packet.bbb)
    buffer:writeShortArray(packet.bbbb)
    buffer:writeInt(packet.c)
    buffer:writeInt(packet.cc)
    buffer:writeIntArray(packet.ccc)
    buffer:writeIntArray(packet.cccc)
    buffer:writeLong(packet.d)
    buffer:writeLongArray(packet.dd)
    buffer:writeFloat(packet.e)
    buffer:writeFloat(packet.ee)
    buffer:writeFloatArray(packet.eee)
    buffer:writeFloatArray(packet.eeee)
    buffer:writeDouble(packet.f)
    buffer:writeDouble(packet.ff)
    buffer:writeDoubleArray(packet.fff)
    buffer:writeDoubleArray(packet.ffff)
    buffer:writeString(packet.jj)
    buffer:writeStringArray(packet.jjj)
    buffer:writePacket(packet.kk, 2071)
    buffer:writePacketArray(packet.kkk, 2071)
    buffer:writeIntArray(packet.l)
    if packet.ll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.ll)
        for index0, element1 in pairs(packet.ll) do
            if element1 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#element1)
                for index2, element3 in pairs(element1) do
                    buffer:writeIntArray(element3)
                end
            end
        end
    end
    if packet.lll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.lll)
        for index4, element5 in pairs(packet.lll) do
            buffer:writePacketArray(element5, 2071)
        end
    end
    buffer:writeStringArray(packet.llll)
    if packet.lllll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.lllll)
        for index6, element7 in pairs(packet.lllll) do
            buffer:writeIntStringMap(element7)
        end
    end
    buffer:writeIntStringMap(packet.m)
    buffer:writeIntPacketMap(packet.mm, 2071)
    if packet.mmm == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(table.mapSize(packet.mmm))
        for key8, value9 in pairs(packet.mmm) do
            buffer:writePacket(key8, 2071)
            buffer:writeIntArray(value9)
        end
    end
    if packet.mmmm == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(table.mapSize(packet.mmmm))
        for key10, value11 in pairs(packet.mmmm) do
            if key10 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#key10)
                for index12, element13 in pairs(key10) do
                    buffer:writePacketArray(element13, 2071)
                end
            end
            if value11 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#value11)
                for index14, element15 in pairs(value11) do
                    if element15 == null then
                        buffer:writeInt(0)
                    else
                        buffer:writeInt(#element15)
                        for index16, element17 in pairs(element15) do
                            buffer:writeIntArray(element17)
                        end
                    end
                end
            end
        end
    end
    buffer:writeIntArray(packet.s)
    if packet.ss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.ss)
        for index18, element19 in pairs(packet.ss) do
            if element19 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#element19)
                for index20, element21 in pairs(element19) do
                    buffer:writeIntArray(element21)
                end
            end
        end
    end
    if packet.sss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.sss)
        for index22, element23 in pairs(packet.sss) do
            buffer:writePacketArray(element23, 2071)
        end
    end
    buffer:writeStringArray(packet.ssss)
    if packet.sssss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.sssss)
        for index24, element25 in pairs(packet.sssss) do
            buffer:writeIntStringMap(element25)
        end
    end
end

function Protocols.WebSocketObjectA:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.a)
    buffer:writePacket(packet.objectB, 2072)
end

function Protocols.WebSocketObjectB:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeBoolean(packet.flag)
end

function Protocols.GatewayToProviderRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function Protocols.GatewayToProviderResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

