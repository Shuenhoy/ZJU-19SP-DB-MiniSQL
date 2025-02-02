using System;
using HYBase.RecordManager;
using System.Text;
namespace HYBase
{

    public static class BytesComp
    {
        public static int Comp(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b, AttrType attrType)
        {
            switch (attrType)
            {
                case AttrType.Int:
                    {
                        int aa = BitConverter.ToInt32(a);
                        int bb = BitConverter.ToInt32(b);
                        return aa - bb;
                    }
                case AttrType.Float:
                    {
                        float aa = BitConverter.ToSingle(a);
                        float bb = BitConverter.ToSingle(b);
                        float sub = aa - bb;
                        return Math.Abs(aa - bb) < 1e-9 ? 0 : aa - bb > 0 ? 1 : -1;
                    }
                case AttrType.String:
                    {

                        string aa = Utils.Utils.BytesToString(a.ToArray());
                        string bb = Utils.Utils.BytesToString(b.ToArray());
                        return String.Compare(aa, bb);
                    }
                default:
                    throw new NotImplementedException();
            }
        }
    }
}