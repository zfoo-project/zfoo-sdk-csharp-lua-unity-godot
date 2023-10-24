
local TripleLSS = {}

function TripleLSS:new()
    local obj = {
        left = 0, -- long
        middle = "", -- string
        right = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function TripleLSS:protocolId()
    return 116
end

function TripleLSS:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.left)
    buffer:writeString(packet.middle)
    buffer:writeString(packet.right)
end

function TripleLSS:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TripleLSS:new()
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

return TripleLSS
