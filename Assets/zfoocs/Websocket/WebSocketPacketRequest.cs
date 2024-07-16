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
            int beforeReadIndex = buffer.GetReadOffset();
            WebSocketPacketRequest packet = new WebSocketPacketRequest();
            byte result0 = buffer.ReadByte();
            packet.a = result0;
            byte result1 = buffer.ReadByte();
            packet.aa = result1;
            var array2 = buffer.ReadByteArray();
            packet.aaa = array2;
            var array3 = buffer.ReadByteArray();
            packet.aaaa = array3;
            short result4 = buffer.ReadShort();
            packet.b = result4;
            short result5 = buffer.ReadShort();
            packet.bb = result5;
            var array6 = buffer.ReadShortArray();
            packet.bbb = array6;
            var array7 = buffer.ReadShortArray();
            packet.bbbb = array7;
            int result8 = buffer.ReadInt();
            packet.c = result8;
            int result9 = buffer.ReadInt();
            packet.cc = result9;
            var array10 = buffer.ReadIntArray();
            packet.ccc = array10;
            var array11 = buffer.ReadIntArray();
            packet.cccc = array11;
            long result12 = buffer.ReadLong();
            packet.d = result12;
            var array13 = buffer.ReadLongArray();
            packet.dd = array13;
            float result14 = buffer.ReadFloat();
            packet.e = result14;
            float result15 = buffer.ReadFloat();
            packet.ee = result15;
            var array16 = buffer.ReadFloatArray();
            packet.eee = array16;
            var array17 = buffer.ReadFloatArray();
            packet.eeee = array17;
            double result18 = buffer.ReadDouble();
            packet.f = result18;
            double result19 = buffer.ReadDouble();
            packet.ff = result19;
            var array20 = buffer.ReadDoubleArray();
            packet.fff = array20;
            var array21 = buffer.ReadDoubleArray();
            packet.ffff = array21;
            string result22 = buffer.ReadString();
            packet.jj = result22;
            var array23 = buffer.ReadStringArray();
            packet.jjj = array23;
            WebSocketObjectA result24 = buffer.ReadPacket<WebSocketObjectA>(2071);
            packet.kk = result24;
            var array25 = buffer.ReadPacketArray<WebSocketObjectA>(2071);
            packet.kkk = array25;
            var list26 = buffer.ReadIntList();
            packet.l = list26;
            int size29 = buffer.ReadInt();
            var result27 = new List<List<List<int>>>(size29);
            if (size29 > 0)
            {
                for (int index28 = 0; index28 < size29; index28++)
                {
                    int size32 = buffer.ReadInt();
                    var result30 = new List<List<int>>(size32);
                    if (size32 > 0)
                    {
                        for (int index31 = 0; index31 < size32; index31++)
                        {
                            var list33 = buffer.ReadIntList();
                            result30.Add(list33);
                        }
                    }
                    result27.Add(result30);
                }
            }
            packet.ll = result27;
            int size36 = buffer.ReadInt();
            var result34 = new List<List<WebSocketObjectA>>(size36);
            if (size36 > 0)
            {
                for (int index35 = 0; index35 < size36; index35++)
                {
                    var list37 = buffer.ReadPacketList<WebSocketObjectA>(2071);
                    result34.Add(list37);
                }
            }
            packet.lll = result34;
            var list38 = buffer.ReadStringList();
            packet.llll = list38;
            int size41 = buffer.ReadInt();
            var result39 = new List<Dictionary<int, string>>(size41);
            if (size41 > 0)
            {
                for (int index40 = 0; index40 < size41; index40++)
                {
                    var map42 = buffer.ReadIntStringMap();
                    result39.Add(map42);
                }
            }
            packet.lllll = result39;
            var map43 = buffer.ReadIntStringMap();
            packet.m = map43;
            var map44 = buffer.ReadIntPacketMap<WebSocketObjectA>(2071);
            packet.mm = map44;
            int size46 = buffer.ReadInt();
            var result45 = new Dictionary<WebSocketObjectA, List<int>>(size46);
            if (size46 > 0)
            {
                for (var index47 = 0; index47 < size46; index47++)
                {
                    WebSocketObjectA result48 = buffer.ReadPacket<WebSocketObjectA>(2071);
                    var list49 = buffer.ReadIntList();
                    result45[result48] = list49;
                }
            }
            packet.mmm = result45;
            int size51 = buffer.ReadInt();
            var result50 = new Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>>(size51);
            if (size51 > 0)
            {
                for (var index52 = 0; index52 < size51; index52++)
                {
                    int size55 = buffer.ReadInt();
                    var result53 = new List<List<WebSocketObjectA>>(size55);
                    if (size55 > 0)
                    {
                        for (int index54 = 0; index54 < size55; index54++)
                        {
                            var list56 = buffer.ReadPacketList<WebSocketObjectA>(2071);
                            result53.Add(list56);
                        }
                    }
                    int size59 = buffer.ReadInt();
                    var result57 = new List<List<List<int>>>(size59);
                    if (size59 > 0)
                    {
                        for (int index58 = 0; index58 < size59; index58++)
                        {
                            int size62 = buffer.ReadInt();
                            var result60 = new List<List<int>>(size62);
                            if (size62 > 0)
                            {
                                for (int index61 = 0; index61 < size62; index61++)
                                {
                                    var list63 = buffer.ReadIntList();
                                    result60.Add(list63);
                                }
                            }
                            result57.Add(result60);
                        }
                    }
                    result50[result53] = result57;
                }
            }
            packet.mmmm = result50;
            var set64 = buffer.ReadIntSet();
            packet.s = set64;
            int size67 = buffer.ReadInt();
            var result65 = new HashSet<HashSet<List<int>>>();
            if (size67 > 0)
            {
                for (int index66 = 0; index66 < size67; index66++)
                {
                    int size70 = buffer.ReadInt();
                    var result68 = new HashSet<List<int>>();
                    if (size70 > 0)
                    {
                        for (int index69 = 0; index69 < size70; index69++)
                        {
                            var list71 = buffer.ReadIntList();
                            result68.Add(list71);
                        }
                    }
                    result65.Add(result68);
                }
            }
            packet.ss = result65;
            int size74 = buffer.ReadInt();
            var result72 = new HashSet<HashSet<WebSocketObjectA>>();
            if (size74 > 0)
            {
                for (int index73 = 0; index73 < size74; index73++)
                {
                    var set75 = buffer.ReadPacketSet<WebSocketObjectA>(2071);
                    result72.Add(set75);
                }
            }
            packet.sss = result72;
            var set76 = buffer.ReadStringSet();
            packet.ssss = set76;
            int size79 = buffer.ReadInt();
            var result77 = new HashSet<Dictionary<int, string>>();
            if (size79 > 0)
            {
                for (int index78 = 0; index78 < size79; index78++)
                {
                    var map80 = buffer.ReadIntStringMap();
                    result77.Add(map80);
                }
            }
            packet.sssss = result77;
            if (length > 0)
            {
                buffer.SetReadOffset(beforeReadIndex + length);
            }
            return packet;
        }
    }
}