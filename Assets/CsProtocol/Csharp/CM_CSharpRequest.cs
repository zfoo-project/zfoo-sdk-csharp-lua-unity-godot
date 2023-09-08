using System;
using System.Collections.Generic;
using CsProtocol.Buffer;

namespace CsProtocol
{
    
    public class CM_CSharpRequest : IProtocol
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
        public long dd;
        public long[] ddd;
        public long[] dddd;
        public float e;
        public float ee;
        public float[] eee;
        public float[] eeee;
        public double f;
        public double ff;
        public double[] fff;
        public double[] ffff;
        public bool g;
        public bool gg;
        public bool[] ggg;
        public bool[] gggg;
        public char h;
        public char hh;
        public char[] hhh;
        public char[] hhhh;
        public string jj;
        public string[] jjj;
        public CSharpObjectA objectA;
        public CSharpObjectA[] objectArray;
        public List<int> l;
        public List<List<List<int>>> ll;
        public List<List<CSharpObjectA>> lll;
        public List<string> llll;
        public List<Dictionary<int, string>> lllll;
        public Dictionary<int, string> m;
        public Dictionary<int, CSharpObjectA> mm;
        public Dictionary<CSharpObjectA, List<int>> mmm;
        public Dictionary<List<List<CSharpObjectA>>, List<List<List<int>>>> mmmm;
        public HashSet<int> s;
        public HashSet<HashSet<List<int>>> ss;
        public HashSet<HashSet<CSharpObjectA>> sss;
        public HashSet<string> ssss;
        public HashSet<Dictionary<int, string>> sssss;

        public static CM_CSharpRequest ValueOf(byte a, byte aa, byte[] aaa, byte[] aaaa, short b, short bb, short[] bbb, short[] bbbb, int c, int cc, int[] ccc, int[] cccc, long d, long dd, long[] ddd, long[] dddd, float e, float ee, float[] eee, float[] eeee, double f, double ff, double[] fff, double[] ffff, bool g, bool gg, bool[] ggg, bool[] gggg, char h, char hh, char[] hhh, char[] hhhh, string jj, string[] jjj, List<int> l, List<List<List<int>>> ll, List<List<CSharpObjectA>> lll, List<string> llll, List<Dictionary<int, string>> lllll, Dictionary<int, string> m, Dictionary<int, CSharpObjectA> mm, Dictionary<CSharpObjectA, List<int>> mmm, Dictionary<List<List<CSharpObjectA>>, List<List<List<int>>>> mmmm, CSharpObjectA objectA, CSharpObjectA[] objectArray, HashSet<int> s, HashSet<HashSet<List<int>>> ss, HashSet<HashSet<CSharpObjectA>> sss, HashSet<string> ssss, HashSet<Dictionary<int, string>> sssss)
        {
            var packet = new CM_CSharpRequest();
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
            packet.ddd = ddd;
            packet.dddd = dddd;
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
            packet.gggg = gggg;
            packet.h = h;
            packet.hh = hh;
            packet.hhh = hhh;
            packet.hhhh = hhhh;
            packet.jj = jj;
            packet.jjj = jjj;
            packet.l = l;
            packet.ll = ll;
            packet.lll = lll;
            packet.llll = llll;
            packet.lllll = lllll;
            packet.m = m;
            packet.mm = mm;
            packet.mmm = mmm;
            packet.mmmm = mmmm;
            packet.objectA = objectA;
            packet.objectArray = objectArray;
            packet.s = s;
            packet.ss = ss;
            packet.sss = sss;
            packet.ssss = ssss;
            packet.sssss = sssss;
            return packet;
        }


        public short ProtocolId()
        {
            return 1165;
        }
    }


    public class CM_CSharpRequestRegistration : IProtocolRegistration
    {
        public short ProtocolId()
        {
            return 1165;
        }

        public void Write(ByteBuffer buffer, IProtocol packet)
        {
            if (buffer.WritePacketFlag(packet))
            {
                return;
            }
            CM_CSharpRequest message = (CM_CSharpRequest) packet;
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
            buffer.WriteLong(message.dd);
            buffer.WriteLongArray(message.ddd);
            buffer.WriteLongArray(message.dddd);
            buffer.WriteFloat(message.e);
            buffer.WriteFloat(message.ee);
            buffer.WriteFloatArray(message.eee);
            buffer.WriteFloatArray(message.eeee);
            buffer.WriteDouble(message.f);
            buffer.WriteDouble(message.ff);
            buffer.WriteDoubleArray(message.fff);
            buffer.WriteDoubleArray(message.ffff);
            buffer.WriteBool(message.g);
            buffer.WriteBool(message.gg);
            buffer.WriteBooleanArray(message.ggg);
            buffer.WriteBooleanArray(message.gggg);
            buffer.WriteChar(message.h);
            buffer.WriteChar(message.hh);
            buffer.WriteCharArray(message.hhh);
            buffer.WriteCharArray(message.hhhh);
            buffer.WriteString(message.jj);
            buffer.WriteStringArray(message.jjj);
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
                    buffer.WritePacketList(element8, 1166);
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
            buffer.WriteIntPacketMap(message.mm, 1166);
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
                    buffer.WritePacket(keyElement13, 1166);
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
                            buffer.WritePacketList(element20, 1166);
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
            buffer.WritePacket(message.objectA, 1166);
            buffer.WritePacketArray<CSharpObjectA>(message.objectArray, 1166);
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
                    buffer.WritePacketSet(i29, 1166);
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

        public IProtocol Read(ByteBuffer buffer)
        {
            if (!buffer.ReadBool())
            {
                return null;
            }
            CM_CSharpRequest packet = new CM_CSharpRequest();
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
            long result44 = buffer.ReadLong();
            packet.dd = result44;
            var array45 = buffer.ReadLongArray();
            packet.ddd = array45;
            var array46 = buffer.ReadLongArray();
            packet.dddd = array46;
            float result47 = buffer.ReadFloat();
            packet.e = result47;
            float result48 = buffer.ReadFloat();
            packet.ee = result48;
            var array49 = buffer.ReadFloatArray();
            packet.eee = array49;
            var array50 = buffer.ReadFloatArray();
            packet.eeee = array50;
            double result51 = buffer.ReadDouble();
            packet.f = result51;
            double result52 = buffer.ReadDouble();
            packet.ff = result52;
            var array53 = buffer.ReadDoubleArray();
            packet.fff = array53;
            var array54 = buffer.ReadDoubleArray();
            packet.ffff = array54;
            bool result55 = buffer.ReadBool();
            packet.g = result55;
            bool result56 = buffer.ReadBool();
            packet.gg = result56;
            var array57 = buffer.ReadBooleanArray();
            packet.ggg = array57;
            var array58 = buffer.ReadBooleanArray();
            packet.gggg = array58;
            char result59 = buffer.ReadChar();
            packet.h = result59;
            char result60 = buffer.ReadChar();
            packet.hh = result60;
            var array61 = buffer.ReadCharArray();
            packet.hhh = array61;
            var array62 = buffer.ReadCharArray();
            packet.hhhh = array62;
            string result63 = buffer.ReadString();
            packet.jj = result63;
            var array64 = buffer.ReadStringArray();
            packet.jjj = array64;
            var list65 = buffer.ReadIntList();
            packet.l = list65;
            int size68 = buffer.ReadInt();
            var result66 = new List<List<List<int>>>(size68);
            if (size68 > 0)
            {
                for (int index67 = 0; index67 < size68; index67++)
                {
                    int size71 = buffer.ReadInt();
                    var result69 = new List<List<int>>(size71);
                    if (size71 > 0)
                    {
                        for (int index70 = 0; index70 < size71; index70++)
                        {
                            var list72 = buffer.ReadIntList();
                            result69.Add(list72);
                        }
                    }
                    result66.Add(result69);
                }
            }
            packet.ll = result66;
            int size75 = buffer.ReadInt();
            var result73 = new List<List<CSharpObjectA>>(size75);
            if (size75 > 0)
            {
                for (int index74 = 0; index74 < size75; index74++)
                {
                    var list76 = buffer.ReadPacketList<CSharpObjectA>(1166);
                    result73.Add(list76);
                }
            }
            packet.lll = result73;
            var list77 = buffer.ReadStringList();
            packet.llll = list77;
            int size80 = buffer.ReadInt();
            var result78 = new List<Dictionary<int, string>>(size80);
            if (size80 > 0)
            {
                for (int index79 = 0; index79 < size80; index79++)
                {
                    var map81 = buffer.ReadIntStringMap();
                    result78.Add(map81);
                }
            }
            packet.lllll = result78;
            var map82 = buffer.ReadIntStringMap();
            packet.m = map82;
            var map83 = buffer.ReadIntPacketMap<CSharpObjectA>(1166);
            packet.mm = map83;
            int size85 = buffer.ReadInt();
            var result84 = new Dictionary<CSharpObjectA, List<int>>(size85);
            if (size85 > 0)
            {
                for (var index86 = 0; index86 < size85; index86++)
                {
                    CSharpObjectA result87 = buffer.ReadPacket<CSharpObjectA>(1166);
                    var list88 = buffer.ReadIntList();
                    result84[result87] = list88;
                }
            }
            packet.mmm = result84;
            int size90 = buffer.ReadInt();
            var result89 = new Dictionary<List<List<CSharpObjectA>>, List<List<List<int>>>>(size90);
            if (size90 > 0)
            {
                for (var index91 = 0; index91 < size90; index91++)
                {
                    int size94 = buffer.ReadInt();
                    var result92 = new List<List<CSharpObjectA>>(size94);
                    if (size94 > 0)
                    {
                        for (int index93 = 0; index93 < size94; index93++)
                        {
                            var list95 = buffer.ReadPacketList<CSharpObjectA>(1166);
                            result92.Add(list95);
                        }
                    }
                    int size98 = buffer.ReadInt();
                    var result96 = new List<List<List<int>>>(size98);
                    if (size98 > 0)
                    {
                        for (int index97 = 0; index97 < size98; index97++)
                        {
                            int size101 = buffer.ReadInt();
                            var result99 = new List<List<int>>(size101);
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
                    result89[result92] = result96;
                }
            }
            packet.mmmm = result89;
            CSharpObjectA result103 = buffer.ReadPacket<CSharpObjectA>(1166);
            packet.objectA = result103;
            var array104 = buffer.ReadPacketArray<CSharpObjectA>(1166);
            packet.objectArray = array104;
            var set105 = buffer.ReadIntSet();
            packet.s = set105;
            int size108 = buffer.ReadInt();
            var result106 = new HashSet<HashSet<List<int>>>();
            if (size108 > 0)
            {
                for (int index107 = 0; index107 < size108; index107++)
                {
                    int size111 = buffer.ReadInt();
                    var result109 = new HashSet<List<int>>();
                    if (size111 > 0)
                    {
                        for (int index110 = 0; index110 < size111; index110++)
                        {
                            var list112 = buffer.ReadIntList();
                            result109.Add(list112);
                        }
                    }
                    result106.Add(result109);
                }
            }
            packet.ss = result106;
            int size115 = buffer.ReadInt();
            var result113 = new HashSet<HashSet<CSharpObjectA>>();
            if (size115 > 0)
            {
                for (int index114 = 0; index114 < size115; index114++)
                {
                    var set116 = buffer.ReadPacketSet<CSharpObjectA>(1166);
                    result113.Add(set116);
                }
            }
            packet.sss = result113;
            var set117 = buffer.ReadStringSet();
            packet.ssss = set117;
            int size120 = buffer.ReadInt();
            var result118 = new HashSet<Dictionary<int, string>>();
            if (size120 > 0)
            {
                for (int index119 = 0; index119 < size120; index119++)
                {
                    var map121 = buffer.ReadIntStringMap();
                    result118.Add(map121);
                }
            }
            packet.sssss = result118;
            return packet;
        }
    }
}
