
local WebsocketHelloResponse = {}

function WebsocketHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function WebsocketHelloResponse:protocolId()
    return 1401
end

function WebsocketHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function WebsocketHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebsocketHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return WebsocketHelloResponse
