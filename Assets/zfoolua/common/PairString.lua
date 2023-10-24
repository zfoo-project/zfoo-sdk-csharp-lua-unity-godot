
local PairString = {}

function PairString:new()
    local obj = {
        key = "", -- string
        value = "" -- string
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function PairString:protocolId()
    return 112
end

function PairString:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeString(packet.key)
    buffer:writeString(packet.value)
end

function PairString:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = PairString:new()
    local result0 = buffer:readString()
    packet.key = result0
    local result1 = buffer:readString()
    packet.value = result1
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return PairString
