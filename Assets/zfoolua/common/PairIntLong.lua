
local PairIntLong = {}

function PairIntLong:new()
    local obj = {
        key = 0, -- int
        value = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function PairIntLong:protocolId()
    return 110
end

function PairIntLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.key)
    buffer:writeLong(packet.value)
end

function PairIntLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairIntLong:new()
    local result0 = buffer:readInt()
    packet.key = result0
    local result1 = buffer:readLong()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return PairIntLong
