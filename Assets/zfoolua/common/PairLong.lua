
local PairLong = {}

function PairLong:new()
    local obj = {
        key = 0, -- long
        value = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function PairLong:protocolId()
    return 111
end

function PairLong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.key)
    buffer:writeLong(packet.value)
end

function PairLong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairLong:new()
    local result0 = buffer:readLong()
    packet.key = result0
    local result1 = buffer:readLong()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return PairLong
