
local WebSocketPacketRequest = {}

function WebSocketPacketRequest:new()
    local obj = {
        a = 0, -- byte
        aa = 0, -- byte
        aaa = {}, -- byte[]
        aaaa = {}, -- byte[]
        b = 0, -- short
        bb = 0, -- short
        bbb = {}, -- short[]
        bbbb = {}, -- short[]
        c = 0, -- int
        cc = 0, -- int
        ccc = {}, -- int[]
        cccc = {}, -- int[]
        d = 0, -- long
        dd = {}, -- long[]
        e = 0, -- float
        ee = 0, -- float
        eee = {}, -- float[]
        eeee = {}, -- float[]
        f = 0, -- double
        ff = 0, -- double
        fff = {}, -- double[]
        ffff = {}, -- double[]
        jj = "", -- string
        jjj = {}, -- string[]
        kk = nil, -- WebSocketObjectA
        kkk = {}, -- WebSocketObjectA[]
        l = {}, -- List<int>
        ll = {}, -- List<List<List<int>>>
        lll = {}, -- List<List<WebSocketObjectA>>
        llll = {}, -- List<string>
        lllll = {}, -- List<Dictionary<int, string>>
        m = {}, -- Dictionary<int, string>
        mm = {}, -- Dictionary<int, WebSocketObjectA>
        mmm = {}, -- Dictionary<WebSocketObjectA, List<int>>
        mmmm = {}, -- Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>>
        s = {}, -- HashSet<int>
        ss = {}, -- HashSet<HashSet<List<int>>>
        sss = {}, -- HashSet<HashSet<WebSocketObjectA>>
        ssss = {}, -- HashSet<string>
        sssss = {} -- HashSet<Dictionary<int, string>>
    }
    setmetatable(obj, self)
    self.__index = self
    return obj
end

function WebSocketPacketRequest:protocolId()
    return 2070
end

function WebSocketPacketRequest:protocolName()
    return WebSocketPacketRequest
end

function WebSocketPacketRequest:__tostring()
    local jsonTemplate = "{a:%s, aa:%s, aaa:%s, aaaa:%s, b:%s, bb:%s, bbb:%s, bbbb:%s, c:%s, cc:%s, ccc:%s, cccc:%s, d:%s, dd:%s, e:%s, ee:%s, eee:%s, eeee:%s, f:%s, ff:%s, fff:%s, ffff:%s, jj:%s, jjj:%s, kk:%s, kkk:%s, l:%s, ll:%s, lll:%s, llll:%s, lllll:%s, m:%s, mm:%s, mmm:%s, mmmm:%s, s:%s, ss:%s, sss:%s, ssss:%s, sssss:%s}"
    local result = string.format(jsonTemplate, self.a, self.aa, self.aaa, self.aaaa, self.b, self.bb, self.bbb, self.bbbb, self.c, self.cc, self.ccc, self.cccc, self.d, self.dd, self.e, self.ee, self.eee, self.eeee, self.f, self.ff, self.fff, self.ffff, self.jj, self.jjj, self.kk, self.kkk, self.l, self.ll, self.lll, self.llll, self.lllll, self.m, self.mm, self.mmm, self.mmmm, self.s, self.ss, self.sss, self.ssss, self.sssss)
    return result
end

function WebSocketPacketRequest:write(buffer, packet)
    if packet == nil then
        buffer:writeInt(0)
        return
    end
    buffer:writeInt(-1)
    buffer:writeByte(packet.a)
    buffer:writeByte(packet.aa)
    buffer:writeByteArray(packet.aaa)
    buffer:writeByteArray(packet.aaaa)
    buffer:writeShort(packet.b)
    buffer:writeShort(packet.bb)
    buffer:writeShortArray(packet.bbb)
    buffer:writeShortArray(packet.bbbb)
    buffer:writeInt(packet.c)
    buffer:writeInt(packet.cc)
    buffer:writeIntArray(packet.ccc)
    buffer:writeIntArray(packet.cccc)
    buffer:writeLong(packet.d)
    buffer:writeLongArray(packet.dd)
    buffer:writeFloat(packet.e)
    buffer:writeFloat(packet.ee)
    buffer:writeFloatArray(packet.eee)
    buffer:writeFloatArray(packet.eeee)
    buffer:writeDouble(packet.f)
    buffer:writeDouble(packet.ff)
    buffer:writeDoubleArray(packet.fff)
    buffer:writeDoubleArray(packet.ffff)
    buffer:writeString(packet.jj)
    buffer:writeStringArray(packet.jjj)
    buffer:writePacket(packet.kk, 2071)
    buffer:writePacketArray(packet.kkk, 2071)
    buffer:writeIntArray(packet.l)
    if packet.ll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.ll)
        for index0, element1 in pairs(packet.ll) do
            if element1 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#element1)
                for index2, element3 in pairs(element1) do
                    buffer:writeIntArray(element3)
                end
            end
        end
    end
    if packet.lll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.lll)
        for index4, element5 in pairs(packet.lll) do
            buffer:writePacketArray(element5, 2071)
        end
    end
    buffer:writeStringArray(packet.llll)
    if packet.lllll == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.lllll)
        for index6, element7 in pairs(packet.lllll) do
            buffer:writeIntStringMap(element7)
        end
    end
    buffer:writeIntStringMap(packet.m)
    buffer:writeIntPacketMap(packet.mm, 2071)
    if packet.mmm == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(table.mapSize(packet.mmm))
        for key8, value9 in pairs(packet.mmm) do
            buffer:writePacket(key8, 2071)
            buffer:writeIntArray(value9)
        end
    end
    if packet.mmmm == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(table.mapSize(packet.mmmm))
        for key10, value11 in pairs(packet.mmmm) do
            if key10 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#key10)
                for index12, element13 in pairs(key10) do
                    buffer:writePacketArray(element13, 2071)
                end
            end
            if value11 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#value11)
                for index14, element15 in pairs(value11) do
                    if element15 == null then
                        buffer:writeInt(0)
                    else
                        buffer:writeInt(#element15)
                        for index16, element17 in pairs(element15) do
                            buffer:writeIntArray(element17)
                        end
                    end
                end
            end
        end
    end
    buffer:writeIntArray(packet.s)
    if packet.ss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.ss)
        for index18, element19 in pairs(packet.ss) do
            if element19 == null then
                buffer:writeInt(0)
            else
                buffer:writeInt(#element19)
                for index20, element21 in pairs(element19) do
                    buffer:writeIntArray(element21)
                end
            end
        end
    end
    if packet.sss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.sss)
        for index22, element23 in pairs(packet.sss) do
            buffer:writePacketArray(element23, 2071)
        end
    end
    buffer:writeStringArray(packet.ssss)
    if packet.sssss == null then
        buffer:writeInt(0)
    else
        buffer:writeInt(#packet.sssss)
        for index24, element25 in pairs(packet.sssss) do
            buffer:writeIntStringMap(element25)
        end
    end
end

function WebSocketPacketRequest:read(buffer)
    local length = buffer:readInt()
    if length == 0 then
        return nil
    end
    local beforeReadIndex = buffer:getReadOffset()
    local packet = WebSocketPacketRequest:new()
    local result26 = buffer:readByte()
    packet.a = result26
    local result27 = buffer:readByte()
    packet.aa = result27
    local array28 = buffer:readByteArray()
    packet.aaa = array28
    local array29 = buffer:readByteArray()
    packet.aaaa = array29
    local result30 = buffer:readShort()
    packet.b = result30
    local result31 = buffer:readShort()
    packet.bb = result31
    local array32 = buffer:readShortArray()
    packet.bbb = array32
    local array33 = buffer:readShortArray()
    packet.bbbb = array33
    local result34 = buffer:readInt()
    packet.c = result34
    local result35 = buffer:readInt()
    packet.cc = result35
    local array36 = buffer:readIntArray()
    packet.ccc = array36
    local array37 = buffer:readIntArray()
    packet.cccc = array37
    local result38 = buffer:readLong()
    packet.d = result38
    local array39 = buffer:readLongArray()
    packet.dd = array39
    local result40 = buffer:readFloat()
    packet.e = result40
    local result41 = buffer:readFloat()
    packet.ee = result41
    local array42 = buffer:readFloatArray()
    packet.eee = array42
    local array43 = buffer:readFloatArray()
    packet.eeee = array43
    local result44 = buffer:readDouble()
    packet.f = result44
    local result45 = buffer:readDouble()
    packet.ff = result45
    local array46 = buffer:readDoubleArray()
    packet.fff = array46
    local array47 = buffer:readDoubleArray()
    packet.ffff = array47
    local result48 = buffer:readString()
    packet.jj = result48
    local array49 = buffer:readStringArray()
    packet.jjj = array49
    local result50 = buffer:readPacket(2071)
    packet.kk = result50
    local array51 = buffer:readPacketArray(2071)
    packet.kkk = array51
    local list52 = buffer:readIntArray()
    packet.l = list52
    local result53 = {}
    local size54 = buffer:readInt()
    if size54 > 0 then
        for index55 = 1, size54 do
            local result56 = {}
            local size57 = buffer:readInt()
            if size57 > 0 then
                for index58 = 1, size57 do
                    local list59 = buffer:readIntArray()
                    table.insert(result56, list59)
                end
            end
            table.insert(result53, result56)
        end
    end
    packet.ll = result53
    local result60 = {}
    local size61 = buffer:readInt()
    if size61 > 0 then
        for index62 = 1, size61 do
            local list63 = buffer:readPacketArray(2071)
            table.insert(result60, list63)
        end
    end
    packet.lll = result60
    local list64 = buffer:readStringArray()
    packet.llll = list64
    local result65 = {}
    local size66 = buffer:readInt()
    if size66 > 0 then
        for index67 = 1, size66 do
            local map68 = buffer:readIntStringMap()
            table.insert(result65, map68)
        end
    end
    packet.lllll = result65
    local map69 = buffer:readIntStringMap()
    packet.m = map69
    local map70 = buffer:readIntPacketMap(2071)
    packet.mm = map70
    local result71 = {}
    local size72 = buffer:readInt()
    if size72 > 0 then
        for index73 = 1, size72 do
            local result74 = buffer:readPacket(2071)
            local list75 = buffer:readIntArray()
            result71[result74] = list75
        end
    end
    packet.mmm = result71
    local result76 = {}
    local size77 = buffer:readInt()
    if size77 > 0 then
        for index78 = 1, size77 do
            local result79 = {}
            local size80 = buffer:readInt()
            if size80 > 0 then
                for index81 = 1, size80 do
                    local list82 = buffer:readPacketArray(2071)
                    table.insert(result79, list82)
                end
            end
            local result83 = {}
            local size84 = buffer:readInt()
            if size84 > 0 then
                for index85 = 1, size84 do
                    local result86 = {}
                    local size87 = buffer:readInt()
                    if size87 > 0 then
                        for index88 = 1, size87 do
                            local list89 = buffer:readIntArray()
                            table.insert(result86, list89)
                        end
                    end
                    table.insert(result83, result86)
                end
            end
            result76[result79] = result83
        end
    end
    packet.mmmm = result76
    local set90 = buffer:readIntArray()
    packet.s = set90
    local result91 = {}
    local size92 = buffer:readInt()
    if size92 > 0 then
        for index93 = 1, size92 do
            local result94 = {}
            local size95 = buffer:readInt()
            if size95 > 0 then
                for index96 = 1, size95 do
                    local list97 = buffer:readIntArray()
                    table.insert(result94, list97)
                end
            end
            table.insert(result91, result94)
        end
    end
    packet.ss = result91
    local result98 = {}
    local size99 = buffer:readInt()
    if size99 > 0 then
        for index100 = 1, size99 do
            local set101 = buffer:readPacketArray(2071)
            table.insert(result98, set101)
        end
    end
    packet.sss = result98
    local set102 = buffer:readStringArray()
    packet.ssss = set102
    local result103 = {}
    local size104 = buffer:readInt()
    if size104 > 0 then
        for index105 = 1, size104 do
            local map106 = buffer:readIntStringMap()
            table.insert(result103, map106)
        end
    end
    packet.sssss = result103
    if length > 0 then
        buffer:setReadOffset(beforeReadIndex + length)
    end
    return packet
end

return WebSocketPacketRequest
