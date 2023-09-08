using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class WebSocketPacketRequest : IProtocol
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
        public char g;
        public char[] gg;
        public List<char> ggg;
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

        public static WebSocketPacketRequest ValueOf(byte a, byte aa, byte[] aaa, byte[] aaaa, short b, short bb, short[] bbb, short[] bbbb, int c, int cc, int[] ccc, int[] cccc, long d, long[] dd, float e, float ee, float[] eee, float[] eeee, double f, double ff, double[] fff, double[] ffff, char g, char[] gg, List<char> ggg, string jj, string[] jjj, WebSocketObjectA kk, WebSocketObjectA[] kkk, List<int> l, List<List<List<int>>> ll, List<List<WebSocketObjectA>> lll, List<string> llll, List<Dictionary<int, string>> lllll, Dictionary<int, string> m, Dictionary<int, WebSocketObjectA> mm, Dictionary<WebSocketObjectA, List<int>> mmm, Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>> mmmm, HashSet<int> s, HashSet<HashSet<List<int>>> ss, HashSet<HashSet<WebSocketObjectA>> sss, HashSet<string> ssss, HashSet<Dictionary<int, string>> sssss)
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
            packet.g = g;
            packet.gg = gg;
            packet.ggg = ggg;
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


        public short ProtocolId()
        {
            return 2070;
        }
    }


    public class WebSocketPacketRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 2070;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            WebSocketPacketRequest message = (WebSocketPacketRequest) packet;
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
            buffer.WriteChar(message.g);
            buffer.WriteCharArray(message.gg);
            if (message.ggg == null)
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.ggg.Count);
                int length0 = message.ggg.Count;
                for (int i1 = 0; i1 < length0; i1++)
                {
                    var element2 = message.ggg[i1];
                    buffer.WriteChar(element2);
                }
            }
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
                int length3 = message.ll.Count;
                for (int i4 = 0; i4 < length3; i4++)
                {
                    var element5 = message.ll[i4];
                    if (element5 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(element5.Count);
                        int length6 = element5.Count;
                        for (int i7 = 0; i7 < length6; i7++)
                        {
                            var element8 = element5[i7];
                            buffer.WriteIntList(element8);
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
                int length9 = message.lll.Count;
                for (int i10 = 0; i10 < length9; i10++)
                {
                    var element11 = message.lll[i10];
                    buffer.WritePacketList(element11, 2071);
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
                int length12 = message.lllll.Count;
                for (int i13 = 0; i13 < length12; i13++)
                {
                    var element14 = message.lllll[i13];
                    buffer.WriteIntStringMap(element14);
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
                foreach (var i15 in message.mmm)
                {
                    var keyElement16 = i15.Key;
                    var valueElement17 = i15.Value;
                    buffer.WritePacket(keyElement16, 2071);
                    buffer.WriteIntList(valueElement17);
                }
            }
            if ((message.mmmm == null) || (message.mmmm.Count == 0))
            {
                buffer.WriteInt(0);
            }
            else
            {
                buffer.WriteInt(message.mmmm.Count);
                foreach (var i18 in message.mmmm)
                {
                    var keyElement19 = i18.Key;
                    var valueElement20 = i18.Value;
                    if (keyElement19 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(keyElement19.Count);
                        int length21 = keyElement19.Count;
                        for (int i22 = 0; i22 < length21; i22++)
                        {
                            var element23 = keyElement19[i22];
                            buffer.WritePacketList(element23, 2071);
                        }
                    }
                    if (valueElement20 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(valueElement20.Count);
                        int length24 = valueElement20.Count;
                        for (int i25 = 0; i25 < length24; i25++)
                        {
                            var element26 = valueElement20[i25];
                            if (element26 == null)
                            {
                                buffer.WriteInt(0);
                            }
                            else
                            {
                                buffer.WriteInt(element26.Count);
                                int length27 = element26.Count;
                                for (int i28 = 0; i28 < length27; i28++)
                                {
                                    var element29 = element26[i28];
                                    buffer.WriteIntList(element29);
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
                foreach (var i30 in message.ss)
                {
                    if (i30 == null)
                    {
                        buffer.WriteInt(0);
                    }
                    else
                    {
                        buffer.WriteInt(i30.Count);
                        foreach (var i31 in i30)
                        {
                            buffer.WriteIntList(i31);
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
                foreach (var i32 in message.sss)
                {
                    buffer.WritePacketSet(i32, 2071);
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
                foreach (var i33 in message.sssss)
                {
                    buffer.WriteIntStringMap(i33);
                }
            }
        }

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            WebSocketPacketRequest packet = new WebSocketPacketRequest();
            byte result34 = buffer.ReadByte();
            packet.a = result34;
            byte result35 = buffer.ReadByte();
            packet.aa = result35;
            var array36 = buffer.ReadByteArray();
            packet.aaa = array36;
            var array37 = buffer.ReadByteArray();
            packet.aaaa = array37;
            short result38 = buffer.ReadShort();
            packet.b = result38;
            short result39 = buffer.ReadShort();
            packet.bb = result39;
            var array40 = buffer.ReadShortArray();
            packet.bbb = array40;
            var array41 = buffer.ReadShortArray();
            packet.bbbb = array41;
            int result42 = buffer.ReadInt();
            packet.c = result42;
            int result43 = buffer.ReadInt();
            packet.cc = result43;
            var array44 = buffer.ReadIntArray();
            packet.ccc = array44;
            var array45 = buffer.ReadIntArray();
            packet.cccc = array45;
            long result46 = buffer.ReadLong();
            packet.d = result46;
            var array47 = buffer.ReadLongArray();
            packet.dd = array47;
            float result48 = buffer.ReadFloat();
            packet.e = result48;
            float result49 = buffer.ReadFloat();
            packet.ee = result49;
            var array50 = buffer.ReadFloatArray();
            packet.eee = array50;
            var array51 = buffer.ReadFloatArray();
            packet.eeee = array51;
            double result52 = buffer.ReadDouble();
            packet.f = result52;
            double result53 = buffer.ReadDouble();
            packet.ff = result53;
            var array54 = buffer.ReadDoubleArray();
            packet.fff = array54;
            var array55 = buffer.ReadDoubleArray();
            packet.ffff = array55;
            char result56 = buffer.ReadChar();
            packet.g = result56;
            var array57 = buffer.ReadCharArray();
            packet.gg = array57;
            int size60 = buffer.ReadInt();
            var result58 = new List<char>(size60);
            if (size60 > 0)
            {
                for (int index59 = 0; index59 < size60; index59++)
                {
                    char result61 = buffer.ReadChar();
                    result58.Add(result61);
                }
            }
            packet.ggg = result58;
            string result62 = buffer.ReadString();
            packet.jj = result62;
            var array63 = buffer.ReadStringArray();
            packet.jjj = array63;
            WebSocketObjectA result64 = buffer.ReadPacket<WebSocketObjectA>(2071);
            packet.kk = result64;
            var array65 = buffer.ReadPacketArray<WebSocketObjectA>(2071);
            packet.kkk = array65;
            var list66 = buffer.ReadIntList();
            packet.l = list66;
            int size69 = buffer.ReadInt();
            var result67 = new List<List<List<int>>>(size69);
            if (size69 > 0)
            {
                for (int index68 = 0; index68 < size69; index68++)
                {
                    int size72 = buffer.ReadInt();
                    var result70 = new List<List<int>>(size72);
                    if (size72 > 0)
                    {
                        for (int index71 = 0; index71 < size72; index71++)
                        {
                            var list73 = buffer.ReadIntList();
                            result70.Add(list73);
                        }
                    }
                    result67.Add(result70);
                }
            }
            packet.ll = result67;
            int size76 = buffer.ReadInt();
            var result74 = new List<List<WebSocketObjectA>>(size76);
            if (size76 > 0)
            {
                for (int index75 = 0; index75 < size76; index75++)
                {
                    var list77 = buffer.ReadPacketList<WebSocketObjectA>(2071);
                    result74.Add(list77);
                }
            }
            packet.lll = result74;
            var list78 = buffer.ReadStringList();
            packet.llll = list78;
            int size81 = buffer.ReadInt();
            var result79 = new List<Dictionary<int, string>>(size81);
            if (size81 > 0)
            {
                for (int index80 = 0; index80 < size81; index80++)
                {
                    var map82 = buffer.ReadIntStringMap();
                    result79.Add(map82);
                }
            }
            packet.lllll = result79;
            var map83 = buffer.ReadIntStringMap();
            packet.m = map83;
            var map84 = buffer.ReadIntPacketMap<WebSocketObjectA>(2071);
            packet.mm = map84;
            int size86 = buffer.ReadInt();
            var result85 = new Dictionary<WebSocketObjectA, List<int>>(size86);
            if (size86 > 0)
            {
                for (var index87 = 0; index87 < size86; index87++)
                {
                    WebSocketObjectA result88 = buffer.ReadPacket<WebSocketObjectA>(2071);
                    var list89 = buffer.ReadIntList();
                    result85[result88] = list89;
                }
            }
            packet.mmm = result85;
            int size91 = buffer.ReadInt();
            var result90 = new Dictionary<List<List<WebSocketObjectA>>, List<List<List<int>>>>(size91);
            if (size91 > 0)
            {
                for (var index92 = 0; index92 < size91; index92++)
                {
                    int size95 = buffer.ReadInt();
                    var result93 = new List<List<WebSocketObjectA>>(size95);
                    if (size95 > 0)
                    {
                        for (int index94 = 0; index94 < size95; index94++)
                        {
                            var list96 = buffer.ReadPacketList<WebSocketObjectA>(2071);
                            result93.Add(list96);
                        }
                    }
                    int size99 = buffer.ReadInt();
                    var result97 = new List<List<List<int>>>(size99);
                    if (size99 > 0)
                    {
                        for (int index98 = 0; index98 < size99; index98++)
                        {
                            int size102 = buffer.ReadInt();
                            var result100 = new List<List<int>>(size102);
                            if (size102 > 0)
                            {
                                for (int index101 = 0; index101 < size102; index101++)
                                {
                                    var list103 = buffer.ReadIntList();
                                    result100.Add(list103);
                                }
                            }
                            result97.Add(result100);
                        }
                    }
                    result90[result93] = result97;
                }
            }
            packet.mmmm = result90;
            var set104 = buffer.ReadIntSet();
            packet.s = set104;
            int size107 = buffer.ReadInt();
            var result105 = new HashSet<HashSet<List<int>>>();
            if (size107 > 0)
            {
                for (int index106 = 0; index106 < size107; index106++)
                {
                    int size110 = buffer.ReadInt();
                    var result108 = new HashSet<List<int>>();
                    if (size110 > 0)
                    {
                        for (int index109 = 0; index109 < size110; index109++)
                        {
                            var list111 = buffer.ReadIntList();
                            result108.Add(list111);
                        }
                    }
                    result105.Add(result108);
                }
            }
            packet.ss = result105;
            int size114 = buffer.ReadInt();
            var result112 = new HashSet<HashSet<WebSocketObjectA>>();
            if (size114 > 0)
            {
                for (int index113 = 0; index113 < size114; index113++)
                {
                    var set115 = buffer.ReadPacketSet<WebSocketObjectA>(2071);
                    result112.Add(set115);
                }
            }
            packet.sss = result112;
            var set116 = buffer.ReadStringSet();
            packet.ssss = set116;
            int size119 = buffer.ReadInt();
            var result117 = new HashSet<Dictionary<int, string>>();
            if (size119 > 0)
            {
                for (int index118 = 0; index118 < size119; index118++)
                {
                    var map120 = buffer.ReadIntStringMap();
                    result117.Add(map120);
                }
            }
            packet.sssss = result117;
            return packet;
        }
    }
}
