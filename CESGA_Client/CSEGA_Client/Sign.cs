using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CESGA_Client
{
  class Sign
  {

    public static BigInteger BI_Generate_Ki()
    {
      BigInteger result_Ki;
      while (true)
      {
        Random rand = new Random();
        result_Ki = BigInteger.genPseudoPrime(256, 5, rand);
        if (result_Ki > 0)
          break;
      }
      return result_Ki;

    }

    public static BigInteger BI_Generate_Ti(BigInteger argQ)
    {
      BigInteger result_Ti;
      while (true)
      {
        Random rand = new Random();
        result_Ti = BigInteger.genPseudoPrime(256, 5, rand);
        if (result_Ti > argQ)
          break;
      }
      return result_Ti;

    }
    public static BigInteger BI_Generate_Yi(
                                             BigInteger argP,
                                             BigInteger argG,
                                             BigInteger argKi
                                            )
    {
      return argG.modPow(argKi, argP);
    }

    public static BigInteger Calculate_Ri(
                                          BigInteger argG,
                                          BigInteger argP,
                                          BigInteger argTi
                                         )
    {
      return argG.modPow(argTi, argP);
    }

    public static BigInteger Calculate_Si(
                                          BigInteger argTi,
                                          BigInteger argHi,
                                          BigInteger argKi,
                                          BigInteger argE,
                                          BigInteger argQ
                                         )
    {
      return (argTi - (argHi.modPow(1, argQ) * argKi.modPow(1, argQ) * argE.modPow(1, argQ)).modPow(1, argQ));
    }
  }
}
