
local Pong = {}

function Pong:new()
    local obj = {
        time = 0 -- long
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function Pong:protocolId()
    return 104
end

function Pong:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeLong(packet.time)
end

function Pong:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Pong:new()
    local result0 = buffer:readLong()
    packet.time = result0
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return Pong
