
local JsonHelloRequest = {}

function JsonHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function JsonHelloRequest:protocolId()
    return 1600
end

function JsonHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function JsonHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = JsonHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return JsonHelloRequest
