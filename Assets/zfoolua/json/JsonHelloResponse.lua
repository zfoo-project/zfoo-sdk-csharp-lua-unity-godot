
local JsonHelloResponse = {}

function JsonHelloResponse:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function JsonHelloResponse:protocolId()
    return 1601
end

function JsonHelloResponse:protocolName()
    return JsonHelloResponse
end

function JsonHelloResponse:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function JsonHelloResponse:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function JsonHelloResponse:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = JsonHelloResponse:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return JsonHelloResponse
