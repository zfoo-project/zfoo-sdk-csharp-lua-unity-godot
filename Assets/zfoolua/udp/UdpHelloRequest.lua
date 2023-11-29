
local UdpHelloRequest = {}

function UdpHelloRequest:new()
    local obj = {
        message = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function UdpHelloRequest:protocolId()
    return 1200
end

function UdpHelloRequest:protocolName()
    return UdpHelloRequest
end

function UdpHelloRequest:__tostring()
    local jsonTemplate = "{message:%s}"
    local result = string.format(jsonTemplate, self.message)
    return result
end

function UdpHelloRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.message)
end

function UdpHelloRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = UdpHelloRequest:new()
    local result0 = buffer:readString()
    packet.message = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return UdpHelloRequest
