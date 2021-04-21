using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static int BitCount = 26;
    public static string FacilityBits = "00110011";
    public static int FacilityBitCount = 8;
    public static int FacilityStartBit = 1;
    public static string InternalNumberBits = "0000001100001111";
    public static int InternalNumberBitCount = 16;
    public static int InternalNumberStartBit = 9;
    public static int NumberOfEvenParityBits = 13;
    public static int EvenParityStartBit = 0;
    public static int NumberOfoddParityBits = 13;
    public static int OddParityStartBit = 13;

    public static string Encode()
            {
                StringBuilder sbits = new StringBuilder(new string('0', BitCount));

                if (FacilityBitCount > 0 && BitCount >= FacilityStartBit + FacilityBitCount)
                    sbits.Replace(new string('0', FacilityBitCount), FacilityBits, FacilityStartBit, FacilityBitCount);

                if (InternalNumberBitCount > 0 && BitCount >= InternalNumberStartBit + InternalNumberBitCount)
                    sbits.Replace(new string('0', InternalNumberBitCount), InternalNumberBits, InternalNumberStartBit, InternalNumberBitCount);

                if (NumberOfEvenParityBits > 0 && sbits.Length >= EvenParityStartBit + NumberOfEvenParityBits)
                {
                    int evenParityCount = 0;

                    for (int i = EvenParityStartBit; i < EvenParityStartBit + NumberOfEvenParityBits; i++)
                        if (sbits[i].Equals('1'))
                            evenParityCount++;

                    if (evenParityCount % 2 != 0)
                        sbits.Replace('0', '1', EvenParityStartBit, 1);
                }

                if (NumberOfoddParityBits > 0 && sbits.Length >= OddParityStartBit + NumberOfoddParityBits)
                {
                    int oddParityCount = 0;

                    for (int i = OddParityStartBit; i < OddParityStartBit + NumberOfoddParityBits; i++)
                        if (sbits[i].Equals('1'))
                            oddParityCount++;

                    if (oddParityCount % 2 == 0)
                        sbits.Replace('0', '1', OddParityStartBit + NumberOfoddParityBits - 1, 1);
                }

                return sbits.ToString();
            }
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        var value1 = "00011001100000011000101000";
        var value2 = Encode();
        Console.WriteLine(value2);
        Console.WriteLine(value1 == value2);
    }
}