using System;
using System.Collections.Generic;

namespace zfoocs
{
    
    public class WebSocketPacketRequest
    {
        public byte a;
        public byte aa;
        public byte[] aaa;
        public byte[] aaaa;
        public short b;
        public short bb;
        public short[] bbb;
        public short[] bbbb;
        public int c;
        public int cc;
        public int[] ccc;
        public int[] cccc;
        public long d;
        public long[] dd;
        public float e;
        public float ee;
        public float[] eee;
        public float[] eeee;
        public double f;
        public double ff;
        public double[] fff;
        public double[] ffff;
        public string jj;
        public string[] jjj;
        public WebSocketObjectA kk;
        public WebSocketObjectA[] kkk;
        public List<int> l;
        public List<List<List<int>>> ll;
        public List<List<WebSocketObjectA>> lll;
        public List<string> llll;
        public List<Dictionary<int, string>> lllll;
        public Dictionary<int, string> m;
        public Dictionary<int, WebSocketObjectA> mm;
        public Dictionary<WebSocketObjectA, List<int>> mmm;
        public Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>> mmmm;
        public HashSet<int> s;
        public HashSet<HashSet<List<int>>> ss;
        public HashSet<HashSet<WebSocketObjectA>> sss;
        public HashSet<string> ssss;
        public HashSet<Dictionary<int, string>> sssss;

        public static WebSocketPacketRequest ValueOf(byte a, byte aa, byte[] aaa, byte[] aaaa, short b, short bb, short[] bbb, short[] bbbb, int c, int cc, int[] ccc, int[] cccc, long d, long[] dd, float e, float ee, float[] eee, float[] eeee, double f, double ff, double[] fff, double[] ffff, string jj, string[] jjj, WebSocketObjectA kk, WebSocketObjectA[] kkk, List<int> l, List<List<List<int>>> ll, List<List<WebSocketObjectA>> lll, List<string> llll, List<Dictionary<int, string>> lllll, Dictionary<int, string> m, Dictionary<int, WebSocketObjectA> mm, Dictionary<WebSocketObjectA, List<int>> mmm, Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>> mmmm, HashSet<int> s, HashSet<HashSet<List<int>>> ss, HashSet<HashSet<WebSocketObjectA>> sss, HashSet<string> ssss, HashSet<Dictionary<int, string>> sssss)
        {
            var packet = new WebSocketPacketRequest();
            packet.a = a;
            packet.aa = aa;
            packet.aaa = aaa;
            packet.aaaa = aaaa;
            packet.b = b;
            packet.bb = bb;
            packet.bbb = bbb;
            packet.bbbb = bbbb;
            packet.c = c;
            packet.cc = cc;
            packet.ccc = ccc;
            packet.cccc = cccc;
            packet.d = d;
            packet.dd = dd;
            packet.e = e;
            packet.ee = ee;
            packet.eee = eee;
            packet.eeee = eeee;
            packet.f = f;
            packet.ff = ff;
            packet.fff = fff;
            packet.ffff = ffff;
            packet.jj = jj;
            packet.jjj = jjj;
            packet.kk = kk;
            packet.kkk = kkk;
            packet.l = l;
            packet.ll = ll;
            packet.lll = lll;
            packet.llll = llll;
            packet.lllll = lllll;
            packet.m = m;
            packet.mm = mm;
            packet.mmm = mmm;
            packet.mmmm = mmmm;
            packet.s = s;
            packet.ss = ss;
            packet.sss = sss;
            packet.ssss = ssss;
            packet.sssss = sssss;
            return packet;
        }
    }


    public class WebSocketPacketRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 2070;
        }

        public void Write(ByteBuffer buffer, object packet)
        {
            if (packet == null)
            {
                buffer.WriteInt(0);
                return;
            }
            WebSocketPacketRequest message = (WebSocketPacketRequest) packet;
            buffer.WriteInt(-1);
            buffer.WriteByte(message.a);
            buffer.WriteByte(message.aa);
            buffer.WriteByteArray(message.aaa);
            buffer.WriteByteArray(message.aaaa);
            buffer.WriteShort(message.b);
            buffer.WriteShort(message.bb);
            buffer.WriteShortArray(message.bbb);
            buffer.WriteShortArray(message.bbbb);
            buffer.WriteInt(message.c);
            buffer.WriteInt(message.cc);
            buffer.WriteIntArray(message.ccc);
            buffer.WriteIntArray(message.cccc);
            buffer.WriteLong(message.d);
            buffer.WriteLongArray(message.dd);
            buffer.WriteFloat(message.e);
            buffer.WriteFloat(message.ee);
            buffer.WriteFloatArray(message.eee);
            buffer.WriteFloatArray(message.eeee);
            buffer.WriteDouble(message.f);
            buffer.WriteDouble(message.ff);
            buffer.WriteDoubleArray(message.fff);
            buffer.WriteDoubleArray(message.ffff);
            buffer.WriteString(message.jj);
            buffer.WriteStringArray(message.jjj);
            buffer.WritePacket(message.kk, 2071);
            buffer.WritePacketArray<WebSocketObjectA>(message.kkk, 2071);
            buffer.WriteIntList(message.l);
            if (message.ll == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.ll.Count);
                int length0 = message.ll.Count;
                for (int i1 = 0; i1 < length0; i1++)
                {
                    var element2 = message.ll[i1];
                    if (element2 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(element2.Count);
                        int length3 = element2.Count;
                        for (int i4 = 0; i4 < length3; i4++)
                        {
                            var element5 = element2[i4];
                            buffer.WriteIntList(element5);
                        }
                    }
                }
            }
            if (message.lll == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.lll.Count);
                int length6 = message.lll.Count;
                for (int i7 = 0; i7 < length6; i7++)
                {
                    var element8 = message.lll[i7];
                    buffer.WritePacketList(element8, 2071);
                }
            }
            buffer.WriteStringList(message.llll);
            if (message.lllll == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.lllll.Count);
                int length9 = message.lllll.Count;
                for (int i10 = 0; i10 < length9; i10++)
                {
                    var element11 = message.lllll[i10];
                    buffer.WriteIntStringMap(element11);
                }
            }
            buffer.WriteIntStringMap(message.m);
            buffer.WriteIntPacketMap(message.mm, 2071);
            if ((message.mmm == null) || (message.mmm.Count == 0))
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.mmm.Count);
                foreach (var i12 in message.mmm)
                {
                    var keyElement13 = i12.Key;
                    var valueElement14 = i12.Value;
                    buffer.WritePacket(keyElement13, 2071);
                    buffer.WriteIntList(valueElement14);
                }
            }
            if ((message.mmmm == null) || (message.mmmm.Count == 0))
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.mmmm.Count);
                foreach (var i15 in message.mmmm)
                {
                    var keyElement16 = i15.Key;
                    var valueElement17 = i15.Value;
                    if (keyElement16 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(keyElement16.Count);
                        int length18 = keyElement16.Count;
                        for (int i19 = 0; i19 < length18; i19++)
                        {
                            var element20 = keyElement16[i19];
                            buffer.WritePacketList(element20, 2071);
                        }
                    }
                    if (valueElement17 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(valueElement17.Count);
                        int length21 = valueElement17.Count;
                        for (int i22 = 0; i22 < length21; i22++)
                        {
                            var element23 = valueElement17[i22];
                            if (element23 == null)
                            {
                                buffer.WriteInt(0);
                            }
                            else
                            {
                                buffer.WriteInt(element23.Count);
                                int length24 = element23.Count;
                                for (int i25 = 0; i25 < length24; i25++)
                                {
                                    var element26 = element23[i25];
                                    buffer.WriteIntList(element26);
                                }
                            }
                        }
                    }
                }
            }
            buffer.WriteIntSet(message.s);
            if (message.ss == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.ss.Count);
                foreach (var i27 in message.ss)
                {
                    if (i27 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(i27.Count);
                        foreach (var i28 in i27)
                        {
                            buffer.WriteIntList(i28);
                        }
                    }
                }
            }
            if (message.sss == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.sss.Count);
                foreach (var i29 in message.sss)
                {
                    buffer.WritePacketSet(i29, 2071);
                }
            }
            buffer.WriteStringSet(message.ssss);
            if (message.sssss == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.sssss.Count);
                foreach (var i30 in message.sssss)
                {
                    buffer.WriteIntStringMap(i30);
                }
            }
        }

        public object Read(ByteBuffer buffer)
        {
            int length = buffer.ReadInt();
            if (length == 0)
            {
                return null;
            }
            int beforeReadIndex = buffer.ReadOffset();
            WebSocketPacketRequest packet = new WebSocketPacketRequest();
            byte result31 = buffer.ReadByte();
            packet.a = result31;
            byte result32 = buffer.ReadByte();
            packet.aa = result32;
            var array33 = buffer.ReadByteArray();
            packet.aaa = array33;
            var array34 = buffer.ReadByteArray();
            packet.aaaa = array34;
            short result35 = buffer.ReadShort();
            packet.b = result35;
            short result36 = buffer.ReadShort();
            packet.bb = result36;
            var array37 = buffer.ReadShortArray();
            packet.bbb = array37;
            var array38 = buffer.ReadShortArray();
            packet.bbbb = array38;
            int result39 = buffer.ReadInt();
            packet.c = result39;
            int result40 = buffer.ReadInt();
            packet.cc = result40;
            var array41 = buffer.ReadIntArray();
            packet.ccc = array41;
            var array42 = buffer.ReadIntArray();
            packet.cccc = array42;
            long result43 = buffer.ReadLong();
            packet.d = result43;
            var array44 = buffer.ReadLongArray();
            packet.dd = array44;
            float result45 = buffer.ReadFloat();
            packet.e = result45;
            float result46 = buffer.ReadFloat();
            packet.ee = result46;
            var array47 = buffer.ReadFloatArray();
            packet.eee = array47;
            var array48 = buffer.ReadFloatArray();
            packet.eeee = array48;
            double result49 = buffer.ReadDouble();
            packet.f = result49;
            double result50 = buffer.ReadDouble();
            packet.ff = result50;
            var array51 = buffer.ReadDoubleArray();
            packet.fff = array51;
            var array52 = buffer.ReadDoubleArray();
            packet.ffff = array52;
            string result53 = buffer.ReadString();
            packet.jj = result53;
            var array54 = buffer.ReadStringArray();
            packet.jjj = array54;
            WebSocketObjectA result55 = buffer.ReadPacket<WebSocketObjectA>(2071);
            packet.kk = result55;
            var array56 = buffer.ReadPacketArray<WebSocketObjectA>(2071);
            packet.kkk = array56;
            var list57 = buffer.ReadIntList();
            packet.l = list57;
            int size60 = buffer.ReadInt();
            var result58 = new List<List<List<int>>>(size60);
            if (size60 > 0)
            {
                for (int index59 = 0; index59 < size60; index59++)
                {
                    int size63 = buffer.ReadInt();
                    var result61 = new List<List<int>>(size63);
                    if (size63 > 0)
                    {
                        for (int index62 = 0; index62 < size63; index62++)
                        {
                            var list64 = buffer.ReadIntList();
                            result61.Add(list64);
                        }
                    }
                    result58.Add(result61);
                }
            }
            packet.ll = result58;
            int size67 = buffer.ReadInt();
            var result65 = new List<List<WebSocketObjectA>>(size67);
            if (size67 > 0)
            {
                for (int index66 = 0; index66 < size67; index66++)
                {
                    var list68 = buffer.ReadPacketList<WebSocketObjectA>(2071);
                    result65.Add(list68);
                }
            }
            packet.lll = result65;
            var list69 = buffer.ReadStringList();
            packet.llll = list69;
            int size72 = buffer.ReadInt();
            var result70 = new List<Dictionary<int, string>>(size72);
            if (size72 > 0)
            {
                for (int index71 = 0; index71 < size72; index71++)
                {
                    var map73 = buffer.ReadIntStringMap();
                    result70.Add(map73);
                }
            }
            packet.lllll = result70;
            var map74 = buffer.ReadIntStringMap();
            packet.m = map74;
            var map75 = buffer.ReadIntPacketMap<WebSocketObjectA>(2071);
            packet.mm = map75;
            int size77 = buffer.ReadInt();
            var result76 = new Dictionary<WebSocketObjectA, List<int>>(size77);
            if (size77 > 0)
            {
                for (var index78 = 0; index78 < size77; index78++)
                {
                    WebSocketObjectA result79 = buffer.ReadPacket<WebSocketObjectA>(2071);
                    var list80 = buffer.ReadIntList();
                    result76[result79] = list80;
                }
            }
            packet.mmm = result76;
            int size82 = buffer.ReadInt();
            var result81 = new Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>>(size82);
            if (size82 > 0)
            {
                for (var index83 = 0; index83 < size82; index83++)
                {
                    int size86 = buffer.ReadInt();
                    var result84 = new List<List<WebSocketObjectA>>(size86);
                    if (size86 > 0)
                    {
                        for (int index85 = 0; index85 < size86; index85++)
                        {
                            var list87 = buffer.ReadPacketList<WebSocketObjectA>(2071);
                            result84.Add(list87);
                        }
                    }
                    int size90 = buffer.ReadInt();
                    var result88 = new List<List<List<int>>>(size90);
                    if (size90 > 0)
                    {
                        for (int index89 = 0; index89 < size90; index89++)
                        {
                            int size93 = buffer.ReadInt();
                            var result91 = new List<List<int>>(size93);
                            if (size93 > 0)
                            {
                                for (int index92 = 0; index92 < size93; index92++)
                                {
                                    var list94 = buffer.ReadIntList();
                                    result91.Add(list94);
                                }
                            }
                            result88.Add(result91);
                        }
                    }
                    result81[result84] = result88;
                }
            }
            packet.mmmm = result81;
            var set95 = buffer.ReadIntSet();
            packet.s = set95;
            int size98 = buffer.ReadInt();
            var result96 = new HashSet<HashSet<List<int>>>();
            if (size98 > 0)
            {
                for (int index97 = 0; index97 < size98; index97++)
                {
                    int size101 = buffer.ReadInt();
                    var result99 = new HashSet<List<int>>();
                    if (size101 > 0)
                    {
                        for (int index100 = 0; index100 < size101; index100++)
                        {
                            var list102 = buffer.ReadIntList();
                            result99.Add(list102);
                        }
                    }
                    result96.Add(result99);
                }
            }
            packet.ss = result96;
            int size105 = buffer.ReadInt();
            var result103 = new HashSet<HashSet<WebSocketObjectA>>();
            if (size105 > 0)
            {
                for (int index104 = 0; index104 < size105; index104++)
                {
                    var set106 = buffer.ReadPacketSet<WebSocketObjectA>(2071);
                    result103.Add(set106);
                }
            }
            packet.sss = result103;
            var set107 = buffer.ReadStringSet();
            packet.ssss = set107;
            int size110 = buffer.ReadInt();
            var result108 = new HashSet<Dictionary<int, string>>();
            if (size110 > 0)
            {
                for (int index109 = 0; index109 < size110; index109++)
                {
                    var map111 = buffer.ReadIntStringMap();
                    result108.Add(map111);
                }
            }
            packet.sssss = result108;
            if (length > 0) {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}
