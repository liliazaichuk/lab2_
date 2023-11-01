using System;
namespace lab2_task2
{
    class MyFrac
    {
        public long nom, _denom;
        public MyFrac(long nom, long denom)
        {
            long nsd = FindNSD(nom, denom);
            this.nom = nom / nsd;
            this.denom = denom / nsd;
        }
        public long denom
        {
            get { return _denom; }
            set
            {
                if (value > 0)
                {
                    _denom = value;
                }
                else
                {
                    nom = -nom;
                    _denom = -value;
                }
            }
        }
        static long FindNSD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            long nsd = a + b;
            return nsd;
        }
        public override string ToString()
        {
            return "(" + nom + "/" + denom + ")";
        }
        public static string ToStringWithIntegerPart(MyFrac f)
        {
            long nom = f.nom;
            long denom = f.denom;
            if (nom % denom == 0)
            {
                return $"Цiла частина: {nom / denom}";
            }
            else
            {
                long integerPart = Math.Abs(nom / denom);
                if (nom < 0)
                    return $"Дрiб з видiленою цiлою частиною: \n-({integerPart}+{Math.Abs(nom) % denom}/{denom})";
                else
                    return $"Дрiб з видiленою цiлою частиною: \n({integerPart}+{nom % denom}/{denom})";
            }
        }
        public static double DoubleValue(MyFrac f)
        {
            return Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom);
        }
        public static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }
        public static MyFrac CalcExpr1(int n)
        {
            MyFrac res = new MyFrac(0, 1);

            for (int i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i * (i + 1));
                res = Plus(res, add);
            }
            return res;
        }
        public static MyFrac CalcExpr2(int n)
        {
            MyFrac res = Minus(new MyFrac(1, 1), new MyFrac(1, 4));

            for (int i = 3; i <= n; i++)
            {
                MyFrac add = Minus(new MyFrac(1, 1), new MyFrac(1, i * i));
                res = Multiply(res, add);
            }
            return res;
        }
    }
}
