
local Heartbeat = {}

function Heartbeat:new()
    local obj = {
        
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function Heartbeat:protocolId()
    return 102
end

function Heartbeat:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
end

function Heartbeat:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Heartbeat:new()
    
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return Heartbeat
