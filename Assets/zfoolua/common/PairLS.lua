
local PairLS = {}

function PairLS:new()
    local obj = {
        key = 0, -- long
        value = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function PairLS:protocolId()
    return 113
end

function PairLS:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.key)
    buffer:writeString(packet.value)
end

function PairLS:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairLS:new()
    local result0 = buffer:readLong()
    packet.key = result0
    local result1 = buffer:readString()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return PairLS
