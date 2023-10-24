
local Ping = {}

function Ping:new()
    local obj = {
        
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function Ping:protocolId()
    return 103
end

function Ping:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
end

function Ping:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Ping:new()
    
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return Ping
