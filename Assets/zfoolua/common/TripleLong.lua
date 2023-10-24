
local TripleLong = {}

function TripleLong:new()
    local obj = {
        left = 0, -- long
        middle = 0, -- long
        right = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function TripleLong:protocolId()
    return 114
end

function TripleLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.left)
    buffer:writeLong(packet.middle)
    buffer:writeLong(packet.right)
end

function TripleLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = TripleLong:new()
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

return TripleLong
