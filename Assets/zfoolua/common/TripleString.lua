
local TripleString = {}

function TripleString:new()
    local obj = {
        left = "", -- string
        middle = "", -- string
        right = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function TripleString:protocolId()
    return 115
end

function TripleString:protocolName()
    return TripleString
end

function TripleString:__tostring()
    local jsonTemplate = "{left:%s, middle:%s, right:%s}"
    local result = string.format(jsonTemplate, self.left, self.middle, self.right)
    return result
end

function TripleString:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.left)
    buffer:writeString(packet.middle)
    buffer:writeString(packet.right)
end

function TripleString:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TripleString:new()
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

return TripleString
