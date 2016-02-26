using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FriendlyRobot;

namespace UnitTestProject1
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      string[] allInst = new string[] {
      "UULRRLLL",
      "ULDR",
      "ULDR",
      "ULDRRLRUDUDLURLUDRUDL",
      "LRLDRURDRDUDDDDRLLRUUDURURDRRDRULRDLLDDDDRLRRLLRRDDLRURLRULLLLLRRRDULRULULRLRDLLDDLLRDLUUDUURRULUDUDURULULLDRUDUUURRRURUULRLDLRRRDLLDLRDUULUURUDRURRLURLDLDDUUURRURRLRDLDDULLUDLUDULRDLDUURLUUUURRLRURRDLRRLLLRDRDUUUDRRRDLDRRUUDUDDUDDRLUDDULRURRDRUDLDLLLDLUDDRLURLDUDRUDDDDURLUUUDRLURDDDDLDDRDLUDDLDLURR"
      };

      int[] allChangesAllowed = new int[] { 1, 0, 2, 4, 47 };

      int[] allMaxRets = new int[] { 3, 1, 2, 8, 94 };

      Program p = new Program();
      int length = allInst.Length;
      for (int i = 0; i < length; i++)
      {
        string instructions = allInst[i];
        int changesAllowed = allChangesAllowed[i];
        int actual = p.findMaximumReturns(instructions, changesAllowed);
        int expected = allMaxRets[i];
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
