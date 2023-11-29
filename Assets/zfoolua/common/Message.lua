
local Message = {}

function Message:new()
    local obj = {
        code = 0, -- int
        message = "", -- string
        module = 0 -- byte
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function Message:protocolId()
    return 100
end

function Message:protocolName()
    return Message
end

function Message:__tostring()
    local jsonTemplate = "{module:%s, code:%s, message:%s}"
    local result = string.format(jsonTemplate, self.module, self.code, self.message)
    return result
end

function Message:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeInt(packet.code)
    buffer:writeString(packet.message)
    buffer:writeByte(packet.module)
end

function Message:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = Message:new()
    local result0 = buffer:readInt()
    packet.code = result0
    local result1 = buffer:readString()
    packet.message = result1
    local result2 = buffer:readByte()
    packet.module = result2
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return Message
