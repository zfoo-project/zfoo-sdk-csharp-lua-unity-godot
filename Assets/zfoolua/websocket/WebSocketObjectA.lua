
local WebSocketObjectA = {}

function WebSocketObjectA:new()
    local obj = {
        a = 0, -- int
        objectB = nil -- WebSocketObjectB
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function WebSocketObjectA:protocolId()
    return 2071
end

function WebSocketObjectA:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.a)
    buffer:writePacket(packet.objectB, 2072)
end

function WebSocketObjectA:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebSocketObjectA:new()
    local result0 = buffer:readInt()
    packet.a = result0
    local result1 = buffer:readPacket(2072)
    packet.objectB = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return WebSocketObjectA
