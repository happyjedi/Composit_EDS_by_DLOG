using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEGSA_Server
{
  class Sign
  {
    public static BigInteger BI_Generate_P()
    {
      BigInteger result_P = 0;
      BigInteger min_P = new BigInteger(1);
      min_P = min_P << 1020;

      while (true)
      {
        Random rand = new Random();
        result_P = BigInteger.genPseudoPrime(1024, 10, rand);
        if (result_P > min_P) break;
      }
      return result_P;
    }

    public static BigInteger BI_Generate_Q(BigInteger argP)
    {
      BigInteger min_Q = new BigInteger(1);
      min_Q = min_Q << 254;

      BigInteger sub_P = argP - 1;
      BigInteger result_Q;
      while (true)
      {
        Random rand = new Random();
        result_Q = BigInteger.genPseudoPrime(256, 10, rand);
        if (result_Q > min_Q) break;
       // if (((sub_P % result_Q) == 0) &&  (result_Q > min_Q)) break;
      }
      return result_Q;

    }

    public static BigInteger BI_Generate_G(
                              BigInteger argP,
                              BigInteger argQ
                                                     )
    {
      BigInteger result_G;
      BigInteger var_Qt;
      BigInteger var_Gt;
      while (true)
      {
        Random rand = new Random();
        var_Gt = BigInteger.genPseudoPrime(1024, 10, rand);
        if (var_Gt == 1) continue;
        var_Qt = (argP - 1) / argQ;
        result_G = var_Gt.modPow(var_Qt, argP);
        if ((result_G > 1) && (result_G < (argP - 1)))
          break;
      }
      return result_G;
    }

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


    public static BigInteger Calculate_R(
                                         BigInteger[] Ri,
                                         BigInteger argP
                                        )
    {

      BigInteger result_R = 1;
      for (int i = 0; i < Ri.Length; i++)
      {
        result_R *= Ri[i].modPow(1, argP);
        result_R = result_R.modPow(1, argP);
      }
      return result_R;
    }

    public static BigInteger Calculate_E(
                                         BigInteger argR,
                                         BigInteger argQ
                                        )
    {
      return argR.modPow(1, argQ);
    }

    public static BigInteger Calculate_S(
                                         BigInteger[] argSi,
                                         BigInteger argQ
                                        )
    {
      BigInteger sum = 0;
      for (int i = 0; i < argSi.Length; i++)
        sum += argSi[i];
      return sum.modPow(1, argQ);
    }



    public static BigInteger Calculate_Y(
                                         BigInteger[] argYi,
                                         BigInteger[] argHi,
                                         BigInteger argP
                                        )
    {
      BigInteger varY = 1;
      for (int i = 0; i < argYi.Length; i++)
      {
        varY *= (argYi[i].modPow(argHi[i], argP));
        varY = varY.modPow(1, argP);
      }
      return varY;

    }
    public static bool Verify_Sign(
                                   BigInteger argY,
                                   BigInteger argE,
                                   BigInteger argS,
                                   BigInteger argP,
                                   BigInteger argQ,
                                   BigInteger argG
                                  )
    {
      BigInteger R = (argY.modPow(argE, argP) * argG.modPow(argS, argP)).modPow(1, argP);
      BigInteger E = R.modPow(1, argQ);
      if (argE == E)
        return true;
      else
        return false;
    }
  }
}
