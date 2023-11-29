
local WebsocketHelloRequest = {}

function WebsocketHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function WebsocketHelloRequest:protocolId()
    return 1400
end

function WebsocketHelloRequest:protocolName()
    return WebsocketHelloRequest
end

function WebsocketHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function WebsocketHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function WebsocketHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebsocketHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return WebsocketHelloRequest
